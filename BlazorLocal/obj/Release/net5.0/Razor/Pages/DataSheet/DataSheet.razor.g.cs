#pragma checksum "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb027a152461c7c0878d53cc03cacb79e5b4402b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorLocal.Pages.DataSheet
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/DataSheet")]
    public partial class DataSheet : BlazorLocal.Pages.DataSheet.DataSheetViewModel
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
 if (!isLoadingFinished)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<span class=\"spinner-border spinner-border-sm centerSpinner\" role=\"status\" aria-hidden=\"true\"></span>\r\n    <div class=\"overlay\"></div>");
#nullable restore
#line 8 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
 if (!IsFailed)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<h1>Aufträge</h1>\r\n    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "mt-2");
            __builder.AddMarkupContent(4, "<span class=\"glyphicon glyphicon-filter\"></span>");
            __builder.AddContent(5, 
#nullable restore
#line 14 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                          Model?.Count ?? 0

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(6, " Treffer\r\n    ");
            __builder.CloseElement();
            __builder.OpenElement(7, "table");
            __builder.AddAttribute(8, "class", "table table-sm col-12");
            __builder.OpenElement(9, "thead");
            __builder.OpenElement(10, "tr");
            __builder.OpenElement(11, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(12);
            __builder.AddAttribute(13, "Column", "Id");
            __builder.AddAttribute(14, "Title", "Id");
            __builder.AddAttribute(15, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 24 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                            Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.OpenElement(17, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(18);
            __builder.AddAttribute(19, "Column", "Ordernumber");
            __builder.AddAttribute(20, "Title", "Order number");
            __builder.AddAttribute(21, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 27 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                                               Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                ");
            __builder.OpenElement(23, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(24);
            __builder.AddAttribute(25, "Column", "Ordertime");
            __builder.AddAttribute(26, "Title", "Order time");
            __builder.AddAttribute(27, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 30 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                                           Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                ");
            __builder.OpenElement(29, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(30);
            __builder.AddAttribute(31, "Column", "Articleid");
            __builder.AddAttribute(32, "Title", "Article id");
            __builder.AddAttribute(33, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 33 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                                           Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "th");
            __builder.OpenComponent<BlazorLocal.Shared.SortIcon>(36);
            __builder.AddAttribute(37, "Column", "Articleordernumber");
            __builder.AddAttribute(38, "Title", "Article order number");
            __builder.AddAttribute(39, "Sort", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.KeyValuePair<System.String, System.String>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.KeyValuePair<System.String, System.String>>(this, 
#nullable restore
#line 36 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                                                                                              Sort

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                <th></th>");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 42 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(41, "tr");
            __builder.OpenElement(42, "td");
            __builder.AddContent(43, 
#nullable restore
#line 46 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                     item.id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                ");
            __builder.OpenElement(45, "td");
            __builder.AddContent(46, 
#nullable restore
#line 47 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                     item.ordernumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n                ");
            __builder.OpenElement(48, "td");
            __builder.AddContent(49, 
#nullable restore
#line 48 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                     item.ordertime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n                ");
            __builder.OpenElement(51, "td");
            __builder.AddContent(52, 
#nullable restore
#line 49 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                     item.articleid

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                ");
            __builder.OpenElement(54, "td");
            __builder.AddContent(55, 
#nullable restore
#line 50 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
                     item.articleordernumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 57 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 59 "D:\Repository\PolarEffektStats\BlazorLocal\Pages\DataSheet\DataSheet.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591