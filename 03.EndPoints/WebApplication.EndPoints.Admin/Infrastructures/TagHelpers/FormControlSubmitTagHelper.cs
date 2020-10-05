using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Infrastructures.TagHelpers
{
    [HtmlTargetElement("form-control-submit")]
    public class FormControlSubmitTagHelper : TagHelper
    {
        private readonly CultureLocalizer _cultureLocalizer;

        public FormControlSubmitTagHelper(CultureLocalizer cultureLocalizer)
        {
            _cultureLocalizer = cultureLocalizer;
        }
        public string CancelUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();

            content.Append($"<button type=\"submit\" class=\"btn btn-success mr-2\">{_cultureLocalizer.Get("Save")}</button>");

            if (!string.IsNullOrWhiteSpace(CancelUrl))
                content.Append($"<a href=\"{CancelUrl}\" class=\"btn btn-light\">{_cultureLocalizer.Get("Cancel")}</a>");

            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
