using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "Staff",
        GroupName = SiteGroupNames.Specialized,
        GUID = "f85730bd-fa23-4a5b-a384-f5b1f7b48dbb",
        Order = 40,
        Description = "Use this page type unless you need a more specialized one.")]
    [SitePageIcon]
    public class StaffPage : StandardPage
    {
        [Display(Name = "Staff image",
         GroupName = SystemTabNames.Content, Order = 20)]
        [UIHint(UIHint.Image)] // filters to only show images
        public virtual ContentReference StaffImage { get; set; }

        [CultureSpecific]
        [Display(Name = "Staff full name",
            GroupName = SystemTabNames.Content, Order = 30)]
        public virtual string StaffName { get; set; }

        [CultureSpecific]
        [EmailAddress]
        [Display(Name = "Staff email",
            GroupName = SystemTabNames.Content, Order = 40)]
        public virtual string StaffEmail { get; set; }

        [CultureSpecific]
        [Display(Name = "Staff phone",
           GroupName = SystemTabNames.Content, Order = 50)]
        public virtual string StaffPhone { get; set; }

    }
}