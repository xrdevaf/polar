using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorLocal.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BlazorLocal.PageModels
{
    public class BaseViewModel : ComponentBase, IDisposable
    {
        [Inject] protected ILogger Logger { get; set; }

        [Inject] protected NavigationManager UriHelper { get; set; }
        [CascadingParameter] protected Task<AuthenticationState> authenticationStateTask { get; set; }           

        protected bool IsFailed { get; set; } = false;
        protected string MsgError { get; set; }
        protected string ContextError { get; set; }
        public string RedirectUrl { get; set; }
        public ErrorComponentModel ErrorModel { get; set; } = new ErrorComponentModel();

        bool disposed = false;

        public async Task<string> GetUserNameAsync()
        {
            var user = (await authenticationStateTask).User;
            return user?.Identity?.Name ?? "";
        }
        public string GetUserName()
        {
            var task = Task.Run(async () => await GetUserNameAsync());    
            return task.Result;            
        }
        public async Task<string> GetStandortIdAsync()
        {
            var user = (await authenticationStateTask).User;
            return user?.Claims.FirstOrDefault(r => r.Type == "StandortId")?.Value ?? "0";
        }

        public string GetStandortId()
        {
            var task = Task.Run(async () => await GetStandortIdAsync());
            return task.Result;
        }

        public ClaimsPrincipal GetUser()
        {
            var task = Task.Run(async () => await authenticationStateTask);
            return task.Result.User;
        }
        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
            //GC.Collect(2);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BaseViewModel()
        {
            Dispose(false);
        }

    }
}
