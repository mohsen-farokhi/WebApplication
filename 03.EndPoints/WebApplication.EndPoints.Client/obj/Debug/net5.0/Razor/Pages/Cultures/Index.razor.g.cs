#pragma checksum "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72487c77e85b31d84d6e1d2be2a2b6ccf1aa1568"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApplication.EndPoints.Client.Pages.Cultures
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using WebApplication.EndPoints.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using WebApplication.EndPoints.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Infrastructures;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using Infrastructures.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\_Imports.razor"
using MudBlazor.Dialog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
using ViewModels.Culture;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/cultures")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
  
    string strTitle =
        string.Format("{0} {1}",
        Resources.Actions.ListOf,
        Resources.Models.Cultures.EntityName);

    string strCreate =
        string.Format("{0} {1}",
        Resources.Actions.CreateOf,
        Resources.Models.Cultures.EntityName);

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-12 grid-margin");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "card");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card-body");
            __builder.OpenElement(6, "h4");
            __builder.AddAttribute(7, "class", "card-title");
            __builder.AddContent(8, 
#nullable restore
#line 19 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                    strTitle

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "<p class=\"card-description\"></p>");
#nullable restore
#line 20 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
             if (cultures == null)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(10, "p");
            __builder.OpenElement(11, "em");
            __builder.AddContent(12, 
#nullable restore
#line 22 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                        Resources.DataDictionary.Loading

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 23 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "p");
            __builder.AddAttribute(14, "class", "card-description");
            __builder.OpenElement(15, "a");
            __builder.AddAttribute(16, "class", "btn btn-primary btn-fw");
            __builder.AddAttribute(17, "href", "/Culture/Create");
            __builder.AddContent(18, 
#nullable restore
#line 27 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                                                              strCreate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "table-responsive");
            __builder.OpenElement(22, "table");
            __builder.AddAttribute(23, "class", "table table-bordered table-hover");
            __builder.OpenElement(24, "thead");
            __builder.OpenElement(25, "tr");
            __builder.OpenElement(26, "th");
            __builder.AddContent(27, 
#nullable restore
#line 33 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                      Resources.DataDictionary.IsActive

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                                ");
            __builder.OpenElement(29, "th");
            __builder.AddContent(30, 
#nullable restore
#line 34 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                      Resources.DataDictionary.Lcid

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                                ");
            __builder.OpenElement(32, "th");
            __builder.AddContent(33, 
#nullable restore
#line 35 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                      Resources.DataDictionary.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                                ");
            __builder.OpenElement(35, "th");
            __builder.AddContent(36, 
#nullable restore
#line 36 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                      Resources.Models.Cultures.NativeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                                ");
            __builder.OpenElement(38, "th");
            __builder.AddContent(39, 
#nullable restore
#line 37 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                      Resources.DataDictionary.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                                <th></th>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n                        ");
            __builder.OpenElement(42, "tbody");
#nullable restore
#line 42 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                             foreach (var item in cultures)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(43, "tr");
            __builder.OpenElement(44, "td");
            __builder.AddContent(45, 
#nullable restore
#line 46 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                         item.IsActive

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n                                    ");
            __builder.OpenElement(47, "td");
            __builder.AddContent(48, 
#nullable restore
#line 49 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                         item.Lcid

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n                                    ");
            __builder.OpenElement(50, "td");
            __builder.AddContent(51, 
#nullable restore
#line 52 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                         item.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n                                    ");
            __builder.OpenElement(53, "td");
            __builder.AddContent(54, 
#nullable restore
#line 55 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                         item.NativeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                                    ");
            __builder.OpenElement(56, "td");
            __builder.AddContent(57, 
#nullable restore
#line 58 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                         item.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                                    ");
            __builder.OpenElement(59, "td");
            __builder.OpenElement(60, "a");
            __builder.AddAttribute(61, "href", "javascript:void(0)");
            __builder.AddAttribute(62, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 61 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                                                                               () => Remove(item.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(63, "<i class=\"mdi mdi-delete\" data-name=\"mdi-delete\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 66 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 70 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 75 "H:\MohsenPrograming\2020\CMS_WebApplication\WebApplication\03.EndPoints\WebApplication.EndPoints.Client\Pages\Cultures\Index.razor"
       
    private IndexViewModel[] cultures;
    protected override async Task OnInitializedAsync()
    {
        cultures =
            await client.GetFromJsonAsync<IndexViewModel[]>
                ("Cultures");
    }

    private async Task Remove(int cultureId)
    {
        await client.DeleteAsync($"Cultures?cultureId={cultureId}");
        await OnInitializedAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient client { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
