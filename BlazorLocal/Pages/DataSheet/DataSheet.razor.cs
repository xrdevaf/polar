using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data;
using BlazorLocal.Data.Services;
using BlazorLocal.Data.Services.MailingServices;
using BlazorLocal.PageModels;
using BlazorLocal.Shared;
using MatBlazor;

namespace BlazorLocal.Pages.DataSheet
{
    public class DataSheetViewModel : BaseViewModel
    {
        [Inject] protected DataSheetService Service { get; set; }
        //[Inject] protected MailingService MailingService { get; set; }
        //[Inject] IMatDialogService MatDialogService { get; set; }

        protected List<DataSheetItemViewModel> Model { get; set; } = new List<DataSheetItemViewModel>();
        protected DataSheetItemViewModel currentItem;

       // protected EditDialogDataSheetViewModel EditViewModel = new EditDialogDataSheetViewModel();
        protected bool IsFailed { get; set; }
        protected bool isLoadingFinished = true;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Service.GetAll();

            }
            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: DataSheetPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

      /*  public void CreateItem()
        {
            currentItem = new DataSheetItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        } */

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

      /*  protected void Save(DataSheetItemViewModel item)
        {
            try
            {
                if (item.DataSheetId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.DataSheetId == this.currentItem.DataSheetId);
                    Model[index] = item;
                    StateHasChanged();

                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.DataSheetId = Model.Select(r => r.DataSheetId).Max() + 1;
                    }
                    else
                    {
                        item.DataSheetId = 1;
                    }

                    var newItem = Service.Create(item);
                    if (newItem != null)
                    {
                        Model.Add(newItem);
                    }
                }
                StateHasChanged();
            }
            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: DataSheetPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(DataSheetItemViewModel r)
        {
            currentItem = (DataSheetItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Remove(DataSheetItemViewModel item)
        {
            try
            {
                Service.Delete(item);
                Model.Remove(item);
            }

            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: DataSheetPage/Remove");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected async Task SendMail(DataSheetItemViewModel DataSheet)
        {
            isLoadingFinished = false;
            await Task.Delay(1);
            try
            {
                var result = MailingService.SendMessage(DataSheet, GetUserName());

                if (result)
                {
                    await MatDialogService.AlertAsync("The message sent.");
                }
            }
            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName()}*Error: Zugangsdaten/SendMail");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
            finally
            {
                isLoadingFinished = true;
                StateHasChanged();
            }
        }

        protected async Task OpenConfirmServiceRemove(DataSheetItemViewModel DataSheet)
        {
            var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
            if (result == "Yes")
            {
                try
                {
                    Service.Delete(DataSheet);
                    Model.Remove(DataSheet);
                }

                catch (Exception e)
                {
                    //Logger.LogError(e, $"{GetUserName}*Error: DataSheetPage/Remove");
                    //ErrorModel.IsOpen = true;
                    //ErrorModel.ErrorContext = e.StackTrace;
                    //ErrorModel.ErrorMessage = e.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        } */
    } 
}
