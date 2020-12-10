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

namespace BlazorLocal.Pages.Kunde
{
    public class KundeViewModel : BaseViewModel
    {
        protected List<KundeItemViewModel> Model { get; set; } = new List<KundeItemViewModel>();
        protected KundeItemViewModel currentItem;
        [Inject] protected KundeService Service { get; set; }
        [Inject] IMatDialogService MatDialogService { get; set; }

        protected EditDialogKundeViewModel EditViewModel = new EditDialogKundeViewModel();
        protected bool IsFailed { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Service.GetAll();

            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: KundePage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        public void CreateItem()
        {
            currentItem = new KundeItemViewModel();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

        protected void Save(KundeItemViewModel item)
        {
            try
            {
                if (item.KundeId > 0)
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.KundeId == this.currentItem.KundeId);
                    Model[index] = item;
                    StateHasChanged();

                }
                else
                {
                    if (Model.Count() > 0)
                    {
                        item.KundeId = Model.Select(r => r.KundeId).Max() + 1;
                    }
                    else
                    {
                        item.KundeId = 1;
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
                Logger.LogError(e, $"{GetUserName()}*Error: KundePage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(KundeItemViewModel r)
        {
            currentItem = (KundeItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected async Task OpenConfirmServiceRemove(KundeItemViewModel item)
        {
            var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
            if (result == "Yes")
            {
                try
                {
                    Service.Delete(item);
                    Model.Remove(item);
                }

                catch (Exception e)
                {
                    Logger.LogError(e, $"{GetUserName()}*Error: KundePage/Remove");
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
