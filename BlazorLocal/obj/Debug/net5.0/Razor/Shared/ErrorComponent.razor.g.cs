#pragma checksum "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be3d5a029d522cdb50ca397885f2db5b3cd19537"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorLocal.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using BlazorLocal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using BlazorLocal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
    public partial class ErrorComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MatBlazor.MatDialog>(0);
            __builder.AddAttribute(1, "CanBeClosed", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
                                                     false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "IsOpen", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
                          Model.IsOpen

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "IsOpenChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Model.IsOpen = __value, Model.IsOpen))));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MatBlazor.MatDialogTitle>(5);
                __builder2.AddAttribute(6, "Class", "diHeader");
                __builder2.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(8, "<h3>Info zum aufgetretenen Systemfehler</h3>\r\n        ");
                    __builder3.OpenElement(9, "div");
                    __builder3.AddAttribute(10, "class", "btn-group");
                    __builder3.OpenElement(11, "button");
                    __builder3.AddAttribute(12, "class", "btn btn-nav");
                    __builder3.AddAttribute(13, "type", "button");
                    __builder3.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
                                                                 CloseDialog

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddMarkupContent(15, "<i class=\"glyphicon glyphicon-remove\"></i>");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(16, "\r\n        <hr>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n    ");
                __builder2.OpenComponent<MatBlazor.MatDialogContent>(18);
                __builder2.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(20, "div");
                    __builder3.AddAttribute(21, "class", "h-100");
#nullable restore
#line 16 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
             if (!IsSendMessage)
            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(22, "div");
                    __builder3.AddMarkupContent(23, "<h3 class=\"d-inline-block\">Exception: </h3>");
                    __builder3.OpenElement(24, "span");
                    __builder3.AddAttribute(25, "style", "color: red");
                    __builder3.AddContent(26, 
#nullable restore
#line 19 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
                                                                                         Model.ErrorMessage

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
                    __builder3.CloseElement();
#nullable restore
#line 30 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
                                 
            }
            else
            {

#line default
#line hidden
#nullable disable
                    __builder3.AddMarkupContent(27, "<div>\r\n                    Vielen Dank für Ihre Nachricht, sie wurde erfolgreich übermittelt.\r\n                </div>");
#nullable restore
#line 37 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
            }

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\ErrorComponent.razor"
       
    [CascadingParameter] Task<AuthenticationState> authenticationStateTask { get; set; }

    [Parameter] public ErrorComponentModel Model { get; set; }

    //public LogMessageEntry ModelMsg { get; set; }
    private bool IsSendMessage { get; set; } = false;
    private string MainUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //ModelMsg = new LogMessageEntry();
        //ModelMsg.ErrorMsg = Model.ErrorMessage;
        //ModelMsg.ErrorContext = Model.ErrorContext;
        MainUrl = UriHelper.BaseUri;
    }

    //private async void SendMessage()
    //{
    //    var authState = await authenticationStateTask;
    //    var user = authState.User;
    //    ModelMsg.UserData = !user.Identity.IsAuthenticated ? "Unknown" : user.Identity.Name;
    //    var dataAsString = JsonConvert.SerializeObject(ModelMsg);
    //    var content = new StringContent(dataAsString);
    //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    await Http.PostAsync(UriHelper.BaseUri + "Message/SendMessage", content);
    //    IsSendMessage = true;
    //    StateHasChanged();
    //}

    private void CloseDialog()
    {
        Model.IsOpen = false;
        var navUrl = String.IsNullOrEmpty(Model.RedirectUrl) ? MainUrl : Model.RedirectUrl;
        UriHelper.NavigateTo(navUrl, true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UriHelper { get; set; }
    }
}
#pragma warning restore 1591
