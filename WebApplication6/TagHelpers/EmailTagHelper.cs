using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication6.TagHelpers
{
    [HtmlTargetElement("input-email",TagStructure = TagStructure.NormalOrSelfClosing)]
    public class EmailTagHelper :TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Append(MailTo);
            output.Content.AppendHtml("input");

            //var address = MailTo + "@";
            //output.Attributes.SetAttribute("href", "mailto:" + address);
            //output.Content.SetContent(address);
        }
    }
}
