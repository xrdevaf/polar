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

namespace BlazorLocal.Pages.Auftrag
{
    public class AuftragViewModel : BaseViewModel
    {
        [Inject] protected AuftragService Service { get; set; }
        [Inject] protected MailingService MailingService { get; set; }
        [Inject] IMatDialogService MatDialogService { get; set; }

        protected List<AuftragItemViewModel> Model { get; set; } = new List<AuftragItemViewModel>();
        protected AuftragItemViewModel currentItem;

        protected EditDialogAuftragViewModel EditViewModel = new EditDialogAuftragViewModel();
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
                //Logger.LogError(e, $"{GetUserName}*Error: AuftragPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        public void CreateItem()
        {
            currentItem = new AuftragItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

        protected void Save(AuftragItemViewModel item)
        {
            try
            {
                if (item.AuftragId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.AuftragId == this.currentItem.AuftragId);
                    Model[index] = item;
                    StateHasChanged();

                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.AuftragId = Model.Select(r => r.AuftragId).Max() + 1;
                    }
                    else
                    {
                        item.AuftragId = 1;
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
                //Logger.LogError(e, $"{GetUserName}*Error: AuftragPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(AuftragItemViewModel r)
        {
            currentItem = (AuftragItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Remove(AuftragItemViewModel item)
        {
            try
            {
                Service.Delete(item);
                Model.Remove(item);
            }

            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: AuftragPage/Remove");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected async Task SendMail(AuftragItemViewModel auftrag)
        {
            isLoadingFinished = false;
            await Task.Delay(1);
            try
            {
                var result = MailingService.SendMessage(auftrag, GetUserName());

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

        protected async Task OpenConfirmServiceRemove(AuftragItemViewModel auftrag)
        {
            var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
            if (result == "Yes")
            {
                try
                {
                    Service.Delete(auftrag);
                    Model.Remove(auftrag);
                }

                catch (Exception e)
                {
                    //Logger.LogError(e, $"{GetUserName}*Error: AuftragPage/Remove");
                    //ErrorModel.IsOpen = true;
                    //ErrorModel.ErrorContext = e.StackTrace;
                    //ErrorModel.ErrorMessage = e.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        }
    }
}
