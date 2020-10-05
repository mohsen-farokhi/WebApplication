using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Infrastructures.TagHelpers
{
    [HtmlTargetElement("panel")]
    public class PanelTagHelper : TagHelper
    {
        public string PanelTitle { get; set; }
        public string PanelDescription { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            output.TagName = "div";
            output.AddClass("col-12", HtmlEncoder.Default);
            output.AddClass("grid-margin", HtmlEncoder.Default);

            var preContent = new StringBuilder();
            preContent.Append("<div class=\"card\"><div class=\"card-body\">");
            preContent.Append($"<h4 class=\"card-title\">{PanelTitle}</h4>");
            preContent.Append($"<p class=\"card-description\">{PanelDescription}</p>");

            var postContent = new StringBuilder();
            postContent.Append("</div></div>");

            output.PreContent.SetHtmlContent(preContent.ToString());
            output.PostContent.SetHtmlContent(postContent.ToString());

            output.Content.SetHtmlContent(content.GetContent());
        }
    }
}
