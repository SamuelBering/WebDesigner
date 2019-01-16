using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "Contact",
        GroupName = SiteGroupNames.Specialized,
        GUID = "ef3c5fee-3239-41c0-9952-33ea3ac4779e",
        Order = 50,
        Description = "Use this page for showing contact information and adding a contact form")]
    [SitePageIcon]
    public class ContactPage : StandardPage
    {
        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop your forms here",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentArea MainContentArea { get; set; }
    }
}