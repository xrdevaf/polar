#pragma checksum "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "772f3bdfdfbc00779dc0bd93f53b8beb65350efd"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorLocal.Pages.StatSheet
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/StatSheet")]
    public partial class StatSheet : BlazorLocal.Pages.StatSheet.StatSheetViewModel
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
 if (!isLoadingFinished)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<span class=\"spinner-border spinner-border-sm centerSpinner\" role=\"status\" aria-hidden=\"true\"></span>\r\n    <div class=\"overlay\"></div>");
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
 if (!IsFailed)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "mt-2");
            __builder.AddMarkupContent(3, "<span class=\"glyphicon glyphicon-filter\"></span>");
            __builder.AddContent(4, 
#nullable restore
#line 13 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                          Model?.Count ?? 0

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(5, " Treffer\r\n    ");
            __builder.CloseElement();
            __builder.OpenElement(6, "table");
            __builder.AddAttribute(7, "class", "table table-sm col-12");
            __builder.OpenElement(8, "thead");
            __builder.OpenElement(9, "tr");
            __builder.OpenElement(10, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(11);
            __builder.AddAttribute(12, "Column", "Allorders");
            __builder.AddAttribute(13, "Title", "All orders");
            __builder.AddAttribute(14, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 23 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                           Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(17);
            __builder.AddAttribute(18, "Column", "Shoporders");
            __builder.AddAttribute(19, "Title", "SW orders");
            __builder.AddAttribute(20, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 26 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                           Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.OpenElement(22, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(23);
            __builder.AddAttribute(24, "Column", "Mangalisterorders");
            __builder.AddAttribute(25, "Title", "Mangalister orders");
            __builder.AddAttribute(26, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 29 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                                           Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                ");
            __builder.OpenElement(28, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(29);
            __builder.AddAttribute(30, "Column", "Soldproducts");
            __builder.AddAttribute(31, "Title", "Sold products");
            __builder.AddAttribute(32, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 32 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                                 Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                ");
            __builder.OpenElement(34, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(35);
            __builder.AddAttribute(36, "Column", "Soldproductssw");
            __builder.AddAttribute(37, "Title", "Sold products SW");
            __builder.AddAttribute(38, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 35 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                                      Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                ");
            __builder.OpenElement(40, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(41);
            __builder.AddAttribute(42, "Column", "Soldproductsmangalister");
            __builder.AddAttribute(43, "Title", "Sold products mangalister");
            __builder.AddAttribute(44, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 38 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
                                                                                                        Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                <th></th>");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(46, "tr");
            __builder.OpenElement(47, "td");
            __builder.AddContent(48, 
#nullable restore
#line 47 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.allorders

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n        ");
            __builder.OpenElement(50, "td");
            __builder.AddContent(51, 
#nullable restore
#line 48 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.sworders

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n        ");
            __builder.OpenElement(53, "td");
            __builder.AddContent(54, 
#nullable restore
#line 49 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.mangalisterorders

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.OpenElement(56, "td");
            __builder.AddContent(57, 
#nullable restore
#line 50 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.soldproducts

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n        ");
            __builder.OpenElement(59, "td");
            __builder.AddContent(60, 
#nullable restore
#line 51 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.soldproductssw

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n        ");
            __builder.OpenElement(62, "td");
            __builder.AddContent(63, 
#nullable restore
#line 52 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
             item.soldproductsmangalister

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 59 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 61 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\StatSheet\StatSheet.razor"
}
    

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
