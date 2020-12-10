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

namespace BlazorLocal.Pages.StatPolar
{
    public class StatPolarViewModel : BaseViewModel
    {
        [Inject] protected StatPolarService Service { get; set; }
        //[Inject] protected MailingService MailingService { get; set; }
        //[Inject] IMatDialogService MatDialogService { get; set; }

        protected List<StatPolarItemViewModel> Model { get; set; } = new List<StatPolarItemViewModel>();
        protected StatPolarItemViewModel currentItem;

       // protected EditDialogStatPolarViewModel EditViewModel = new EditDialogStatPolarViewModel();
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
                //Logger.LogError(e, $"{GetUserName}*Error: StatPolarPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

      /*  public void CreateItem()
        {
            currentItem = new StatPolarItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        } */

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

      /*  protected void Save(StatPolarItemViewModel item)
        {
            try
            {
                if (item.StatPolarId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.StatPolarId == this.currentItem.StatPolarId);
                    Model[index] = item;
                    StateHasChanged();

                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.StatPolarId = Model.Select(r => r.StatPolarId).Max() + 1;
                    }
                    else
                    {
                        item.StatPolarId = 1;
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
                //Logger.LogError(e, $"{GetUserName}*Error: StatPolarPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(StatPolarItemViewModel r)
        {
            currentItem = (StatPolarItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Remove(StatPolarItemViewModel item)
        {
            try
            {
                Service.Delete(item);
                Model.Remove(item);
            }

            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: StatPolarPage/Remove");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected async Task SendMail(StatPolarItemViewModel StatPolar)
        {
            isLoadingFinished = false;
            await Task.Delay(1);
            try
            {
                var result = MailingService.SendMessage(StatPolar, GetUserName());

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

        protected async Task OpenConfirmServiceRemove(StatPolarItemViewModel StatPolar)
        {
            var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
            if (result == "Yes")
            {
                try
                {
                    Service.Delete(StatPolar);
                    Model.Remove(StatPolar);
                }

                catch (Exception e)
                {
                    //Logger.LogError(e, $"{GetUserName}*Error: StatPolarPage/Remove");
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
