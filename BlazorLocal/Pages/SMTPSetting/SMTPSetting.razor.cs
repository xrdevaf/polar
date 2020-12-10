using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data;
using BlazorLocal.Data.Services;
using BlazorLocal.PageModels;
using BlazorLocal.Shared;
using MatBlazor;

namespace BlazorLocal.Pages.SMTPSetting
{
    public class SMTPSettingViewModel : BaseViewModel
    {
        protected List<SMTPSettingItemViewModel> Model { get; set; } = new List<SMTPSettingItemViewModel>();
        protected SMTPSettingItemViewModel currentItem;
        [Inject] protected SMTPSettingService Service { get; set; }
        [Inject] IMatDialogService MatDialogService { get; set; }

        protected EditDialogSMTPSettingViewModel EditViewModel = new EditDialogSMTPSettingViewModel();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Service.GetAll();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: SMTPSettingPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        public void CreateItem()
        {
            currentItem = new SMTPSettingItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

        protected void Save(SMTPSettingItemViewModel item)
        {
            try
            {
                if (item.SMTPSettingId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.SMTPSettingId == this.currentItem.SMTPSettingId);
                    Model[index] = item;
                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.SMTPSettingId = Model.Select(r => r.SMTPSettingId).Max() + 1;
                    }
                    else
                    {
                        item.SMTPSettingId = 1;
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
                Logger.LogError(e, $"{GetUserName()}*Error: SMTPSettingPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(SMTPSettingItemViewModel r)
        {
            currentItem = (SMTPSettingItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected async Task Remove(SMTPSettingItemViewModel item)
        {
            var result = await MatDialogService.AskAsync($"Möchten Sie den Datensatz wirklich löschen?", new string[] { "Löschen", "Abbrechen" });

            if (result == "Löschen")
            {
                try
                {
                    Service.Delete(item);
                    Model.Remove(item);
                }

                catch (Exception e)
                {
                    Logger.LogError(e, $"{GetUserName()}*Error: SMTPSettingPage/Remove");
                    ErrorModel.IsOpen = true;
                    ErrorModel.ErrorContext = e.StackTrace;
                    ErrorModel.ErrorMessage = e.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        }
    }
}
