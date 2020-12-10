using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.Services;
using BlazorLocal.PageModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BlazorLocal.Pages.SystemPage
{
    public class SystemErrorLogPageViewModel : BaseViewModel
    {
        protected List<ErrorLogModel> Model { get; set; } = new List<ErrorLogModel>();
        [Inject] protected SystemPageService Service { get; set; }
        [Inject] protected IJSRuntime Js { get; set; }
        [Inject] protected TestControlMailingService MailingService { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime EndDate { get; set; } = DateTime.Now;
        protected string ToEmail { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ErrorModel.RedirectUrl = UriHelper.Uri;
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    GetLogs();
                    StateHasChanged();
                }
                catch (Exception e)
                {
                    Logger.LogError(e, "Error: SystemErrorLogPageViewModel/OnInitializedAsync");
                    ErrorModel.IsOpen = true;
                    ErrorModel.ErrorContext = e.StackTrace;
                    ErrorModel.ErrorMessage = e.Message + "   " + e.InnerException?.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        }

        protected void GetLogs(FilterErrorLogModel filter=null)
        {
            Model = Service.GetModel(filter?.UserFltr??"", filter?.DateFltr, filter?.ErrorFltr ?? "");
            StateHasChanged();
        }

        protected async Task ExportErrors()
        {
            string FileName = $"export_{DateTime.Now.ToShortDateString()}.xlsx";
            var memory = new MemoryStream();
            IWorkbook workbook;
            workbook = new XSSFWorkbook();
            ISheet excelSheet = workbook.CreateSheet($"Errors_{DateTime.Now.ToShortDateString()}");
            IRow row = excelSheet.CreateRow(0);
            int counter = 1;
            row.CreateCell(0).SetCellValue("#");
            row.CreateCell(1).SetCellValue("Insert");
            row.CreateCell(2).SetCellValue("User");
            row.CreateCell(3).SetCellValue("Level");
            row.CreateCell(4).SetCellValue("Error");
            row.CreateCell(5).SetCellValue("Stack Trace");

            foreach (var item in Model.Where(r => r.InsertDate >= StartDate && r.InsertDate < EndDate))
            {
                row = excelSheet.CreateRow(counter);
                row.CreateCell(0).SetCellValue(item.Id);
                row.CreateCell(1).SetCellValue(item.InsertDate.ToString("dd.MM.yy hh:mm:ss"));
                row.CreateCell(2).SetCellValue(item.UserData);
                row.CreateCell(3).SetCellValue(item.ErrorLevel.ToString());
                row.CreateCell(4).SetCellValue(item.ErrorMsg);
                row.CreateCell(5).SetCellValue(item.ErrorContext);
                counter++;
            }
            workbook.Write(memory);
            var fileData = memory.ToArray();

            await Js.InvokeAsync<object>(
                       "saveAsFile",
                       FileName,
                       fileData);
        }

        protected async Task SendTestEmail()
        {
            try
            {
                MailingService.SendTestMail(string.IsNullOrWhiteSpace(ToEmail) ? GetUserName() : ToEmail, GetUserName());
                ToEmail = string.Empty;
                StateHasChanged();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: SystemErrorLogPage/SendTestEmail");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected override void Dispose(bool disposing)
        {
            Model?.Clear();
            Model = null;
            Service = null;
            ErrorModel = null;
           
        }
    }
}
