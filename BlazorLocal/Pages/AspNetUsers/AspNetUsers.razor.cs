using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.Services;
using BlazorLocal.Data.Services.MailingServices;
using BlazorLocal.PageModels;
using MatBlazor;
using Microsoft.Extensions.Logging;

namespace BlazorLocal.Pages.AspNetUsers
{
    public class AspNetUsersViewModel : BaseViewModel
    {
        [Inject] IMatDialogService MatDialogService { get; set; }
        [Inject] protected AspNetUsersService Service { get; set; }

        protected List<AspNetUsersItemViewModel> Model { get; set; } = new List<AspNetUsersItemViewModel>();
        protected AspNetUsersItemViewModel currentItem;

        protected EditDialogAspNetUsersViewModel EditViewModel = new EditDialogAspNetUsersViewModel();
        protected EditPasswordViewModel EditPasswordViewModel = new EditPasswordViewModel();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Service.GetAll();

            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AspNetUsersPage/OnInitializedAsync");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        public void CreateItem()
        {
            currentItem = new AspNetUsersItemViewModel();
            currentItem.AspNetUsersId = null;
            EditViewModel.Model = currentItem;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

        protected async Task Save(AspNetUsersItemViewModel item)
        {
            try
            {
                item.EmailConfirmed = true;

                if (!string.IsNullOrEmpty(item.AspNetUsersId))
                {
                    Service.Update(item);
                    var index = Model.FindIndex(x => x.AspNetUsersId == this.currentItem.AspNetUsersId);
                    Model[index] = item;
                }
                else
                {
                    item.AspNetUsersId = Guid.NewGuid().ToString();
                    var newItem = await Service.Create(item);
                    if (newItem != null)
                    {
                        Model.Add(newItem);
                    }
                }

                StateHasChanged();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AspNetUsersPage/Save");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }
        protected void Edit(AspNetUsersItemViewModel r)
        {
            currentItem = (AspNetUsersItemViewModel)r.Clone();
            EditViewModel.Model = currentItem;
            EditViewModel.Model.Password = currentItem.PasswordHash;
            EditViewModel.DialogIsOpen = true;
        }

        protected void Remove(AspNetUsersItemViewModel item)
        {
            try
            {
                Service.Delete(item);
                Model.Remove(item);
            }

            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AspNetUsersPage/Remove");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected void EditPasswordOpenDialog(AspNetUsersItemViewModel item)
        {
            currentItem = (AspNetUsersItemViewModel)item.Clone();
            EditPasswordViewModel.User = currentItem;
            EditPasswordViewModel.Password = new PasswordModel();
            EditPasswordViewModel.ErrorMessage = null;
            EditPasswordViewModel.User.Password = currentItem.PasswordHash;
            EditPasswordViewModel.DialogIsOpen = true;
        }

        protected async Task EditPassword(PasswordModel model)
        {
            if (model == null)
            {
                EditPasswordViewModel.DialogIsOpen = false;
                return;
            }

            try
            {
                EditPasswordViewModel.ErrorMessage = await Service.UpdatePassword(currentItem, model.OldPassword, model.NewPassword);
                if (string.IsNullOrEmpty(EditPasswordViewModel.ErrorMessage))
                {
                    EditPasswordViewModel.DialogIsOpen = false;
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AspNetUsers/EditPassword");
                ErrorModel.IsOpen = true;
                ErrorModel.ErrorContext = e.StackTrace;
                ErrorModel.ErrorMessage = e.Message;
                IsFailed = true;
                StateHasChanged();
            }
        }

        protected async Task OpenConfirmServiceRemove(AspNetUsersItemViewModel item)
        {
            var result = await MatDialogService.AskAsync($"Möchten Sie den Datensatz {item.UserName} wirklich löschen?", new string[] { "Löschen", "Abbrechen" });
            if (result == "Löschen")
            {
                try
                {
                    Service.Delete(item);
                    Model.Remove(item);
                }
                catch (Exception e)
                {
                    Logger.LogError(e, $"{GetUserName()}*Error: AspNetUsers/OpenConfirmServiceRemove");
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
