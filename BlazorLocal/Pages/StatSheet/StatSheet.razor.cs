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

namespace BlazorLocal.Pages.StatSheet
{
    public class StatSheetViewModel : BaseViewModel
    {
        [Inject] protected StatSheetService Service { get; set; }
        //[Inject] protected MailingService MailingService { get; set; }
        //[Inject] IMatDialogService MatDialogService { get; set; }

        protected List<StatSheetItemViewModel> Model { get; set; } = new List<StatSheetItemViewModel>();
        protected StatSheetItemViewModel currentItem;

        // protected EditDialogStatSheetViewModel EditViewModel = new EditDialogStatSheetViewModel();      
        protected bool isLoadingFinished = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    isLoadingFinished = false;
                    StateHasChanged();

                    Model = await Service.GetAll();

                    isLoadingFinished = true;
                    StateHasChanged();
                }
                catch (Exception e)
                {
                    Logger.LogError(e, $"{GetUserName()}*Error: StatSheetViewModel/OnAfterRenderAsync");
                    ErrorModel.IsOpen = true;
                    ErrorModel.ErrorContext = e.StackTrace;
                    ErrorModel.ErrorMessage = e.Message;
                    IsFailed = true;
                    StateHasChanged();
                }
            }
        }

        /*  public void CreateItem()
          {
              currentItem = new StatSheetItemViewModel();
              EditViewModel.Model = currentItem;
              EditViewModel.DialogIsOpen = true;
          } */

        protected void Sort(KeyValuePair<string, string> pair)
        {
            Model = pair.Value == "desc" ? Model.OrderByDescending(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList()
                : Model.OrderBy(x => x.GetType().GetProperty(pair.Key).GetValue(x, null)).ToList();
            StateHasChanged();
        }

        /*  protected void Save(StatSheetItemViewModel item)
          {
              try
              {
                  if (item.StatSheetId > 0)
                  {
                      Service.Update(item);
                      var index = Model.FindIndex(x => x.StatSheetId == this.currentItem.StatSheetId);
                      Model[index] = item;
                      StateHasChanged();

                  }
                  else
                  {
                      if (Model.Count() > 0)
                      {
                          item.StatSheetId = Model.Select(r => r.StatSheetId).Max() + 1;
                      }
                      else
                      {
                          item.StatSheetId = 1;
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
                  //Logger.LogError(e, $"{GetUserName}*Error: StatSheetPage/Save");
                  ErrorModel.IsOpen = true;
                  ErrorModel.ErrorContext = e.StackTrace;
                  ErrorModel.ErrorMessage = e.Message;
                  IsFailed = true;
                  StateHasChanged();
              }
          }
          protected void Edit(StatSheetItemViewModel r)
          {
              currentItem = (StatSheetItemViewModel)r.Clone();
              EditViewModel.Model = currentItem;
              EditViewModel.DialogIsOpen = true;
          }

          protected void Remove(StatSheetItemViewModel item)
          {
              try
              {
                  Service.Delete(item);
                  Model.Remove(item);
              }

              catch (Exception e)
              {
                  //Logger.LogError(e, $"{GetUserName}*Error: StatSheetPage/Remove");
                  ErrorModel.IsOpen = true;
                  ErrorModel.ErrorContext = e.StackTrace;
                  ErrorModel.ErrorMessage = e.Message;
                  IsFailed = true;
                  StateHasChanged();
              }
          }

          protected async Task SendMail(StatSheetItemViewModel StatSheet)
          {
              isLoadingFinished = false;
              await Task.Delay(1);
              try
              {
                  var result = MailingService.SendMessage(StatSheet, GetUserName());

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

          protected async Task OpenConfirmServiceRemove(StatSheetItemViewModel StatSheet)
          {
              var result = await MatDialogService.AskAsync("Are you sure?", new string[] { "Yes", "No" });
              if (result == "Yes")
              {
                  try
                  {
                      Service.Delete(StatSheet);
                      Model.Remove(StatSheet);
                  }

                  catch (Exception e)
                  {
                      //Logger.LogError(e, $"{GetUserName}*Error: StatSheetPage/Remove");
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
