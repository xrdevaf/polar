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

namespace BlazorLocal.Pages.ShopDiffPolar
{
    public class ShopDiffPolarViewModel : BaseViewModel
    {
        [Inject] protected ShopDiffPolarService Service { get; set; }
        //[Inject] protected MailingService MailingService { get; set; }
        //[Inject] IMatDialogService MatDialogService { get; set; }

        protected List<ShopDiffPolarItemViewModel> Model { get; set; } = new List<ShopDiffPolarItemViewModel>();
        protected ShopDiffPolarItemViewModel currentItem;

       // protected EditDialogShopDiffPolarViewModel EditViewModel = new EditDialogShopDiffPolarViewModel();
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
                //Logger.LogError(e, $"{GetUserName}*Error: ShopDiffPolarPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

      /*  public void CreateItem()
        {
            currentItem = new ShopDiffPolarItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        } */

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

      /*  protected void Save(ShopDiffPolarItemViewModel item)
        {
            try
            {
                if (item.ShopDiffPolarId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.ShopDiffPolarId == this.currentItem.ShopDiffPolarId);
                    Model[index] = item;
                    StateHasChanged();

                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.ShopDiffPolarId = Model.Select(r => r.ShopDiffPolarId).Max() + 1;
                    }
                    else
                    {
                        item.ShopDiffPolarId = 1;
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
                //Logger.LogError(e, $"{GetUserName}*Error: ShopDiffPolarPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(ShopDiffPolarItemViewModel r)
        {
            currentItem = (ShopDiffPolarItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Remove(ShopDiffPolarItemViewModel item)
        {
            try
            {
                Service.Delete(item);
                Model.Remove(item);
            }

            catch (Exception e)
            {
                //Logger.LogError(e, $"{GetUserName}*Error: ShopDiffPolarPage/Remove");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected async Task SendMail(ShopDiffPolarItemViewModel ShopDiffPolar)
        {
            isLoadingFinished = false;
            await Task.Delay(1);
            try
            {
                var result = MailingService.SendMessage(ShopDiffPolar, GetUserName());

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

        protected async Task OpenConfirmServiceRemove(ShopDiffPolarItemViewModel ShopDiffPolar)
        {
            var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
            if (result == "Yes")
            {
                try
                {
                    Service.Delete(ShopDiffPolar);
                    Model.Remove(ShopDiffPolar);
                }

                catch (Exception e)
                {
                    //Logger.LogError(e, $"{GetUserName}*Error: ShopDiffPolarPage/Remove");
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
