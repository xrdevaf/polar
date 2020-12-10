using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal.Shared
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            NavigationManager.NavigateTo(NavigationManager.BaseUri + "Identity/Account/Login", true);
        }
    }
}
