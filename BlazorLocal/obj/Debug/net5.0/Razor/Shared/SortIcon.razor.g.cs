#pragma checksum "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9c217dd5cad30606e07b3d4891ad0b1d6f974f"
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
#line 1 "D:\Repository\PolarEffektStats\BlazorLocal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
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
    public partial class SortIcon : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "span");
            __builder.AddAttribute(1, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 1 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
                  () => OnClickSorting()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "class", "cursor");
#nullable restore
#line 2 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
     if (ChildContent != null)
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, 
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
         ChildContent

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
                     
    }
    else
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, 
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
         Title

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
              
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\Repository\PolarEffektStats\BlazorLocal\Shared\SortIcon.razor"
       
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string Column { get; set; }

    public bool IsDesc { get; set; } = true;

    [Parameter]
    public EventCallback<KeyValuePair<string, string>> Sort { get; set; }

    private void OnClickSorting()
    {
        Sort.InvokeAsync(new KeyValuePair<string, string>(Column, IsDesc ? "desc" : "asc"));

        IsDesc = !IsDesc;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
