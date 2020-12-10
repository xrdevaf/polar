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
        protected EmailComponentModel EmailComponentModel = new EmailComponentModel();
        protected bool IsFailed { get; set; }
        protected bool isLoadingFinished = true;
        protected string selectedFahrzeugstatus = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Service.GetAll();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AuftragPage/OnInitializedAsync");
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

        protected async Task Save(AuftragItemViewModel item)
        {
            try
            {
                if (item.AuftragId > 0)
                {
                    Service.Update(item);
                }
                else
                {
                    Service.Create(item);
                }

                Model = await Service.GetAll();
                StateHasChanged();
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: AuftragPage/Save");
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
        
        protected async Task OpenSendMail(AuftragItemViewModel auftrag)
        {
            EmailComponentModel.DefaultFrom = GetUserName();
            EmailComponentModel.DefaultBodyText = auftrag.AuftragId + " " + auftrag.KundeItem?.KundeName.Trim() + " " + auftrag.Laufnummer?.Trim();
            EmailComponentModel.IsOpen = true;
        }

        protected async Task SendMail(EmailModel emailModel)
        {
            isLoadingFinished = false;
            await Task.Delay(1);
            try
            {
                var result = MailingService.SendMessage(emailModel);

                if (result)
                {
                    await MatDialogService.AlertAsync("The message sent.");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"{GetUserName()}*Error: Zugangsdaten/SendMail");
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
            var result = await MatDialogService.AskAsync($"Möchten Sie den Datensatz {auftrag.Laufnummer} wirklich löschen?", new string[] { "Löschen", "Abbrechen" });
            if (result == "Löschen")
            {
                try
                {
                    Service.Delete(auftrag);
                    Model.Remove(auftrag);
                }

                catch (Exception e)
                {
                    Logger.LogError(e, $"{GetUserName()}*Error: AuftragPage/Remove");
                    ErrorModel.IsOpen = true;
                    ErrorModel.ErrorContext = e.StackTrace;
                    ErrorModel.ErrorMessage = e.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        }

        protected async Task ChooseFahrzeugstatus(ChangeEventArgs e)
        {
            selectedFahrzeugstatus = e.Value.ToString();
            Model = await Service.GetAll(selectedFahrzeugstatus);
            StateHasChanged();
        }

        protected async Task Generate()
        {
            isLoadingFinished = false;
            await Task.Delay(1);

            var y = 0;
            for (var i = 0; i < 5000; i++, y++)
            {
                while (y > 7)
                {
                    y = 0;
                }

                await Save(new AuftragItemViewModel()
                {
                    KundeId = y,
                    Laufnummer = i.ToString() + " nummer"
                });
            }

            Model = await Service.GetAll(selectedFahrzeugstatus);

            isLoadingFinished = true;
            StateHasChanged();
        }
    }
}
