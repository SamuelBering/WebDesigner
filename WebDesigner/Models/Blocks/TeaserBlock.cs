using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
namespace WebDesigner.Models.Blocks
{
    [ContentType(DisplayName = "Teaser",
        GUID = "fb9e0eb8-2b9a-4f0e-ba10-f23293eafcf9",
        GroupName = SiteGroupNames.Common,
        Description = " Use this for rich text with heading, image and page link that will be reused in multiple places.")]
    [SiteBlockIcon]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Heading", Order = 10,
            GroupName = SystemTabNames.PageHeader)]
        public virtual string TeaserHeading { get; set; }
        [CultureSpecific]
        [Display(Name = "Rich text", Order = 20)]
        public virtual XhtmlString TeaserText { get; set; }
        [Display(Name = "Image", Order = 30,
            GroupName = SystemTabNames.PageHeader)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }
        [Display(Name = "Link", Order = 40,
            GroupName = SystemTabNames.PageHeader)]
        public virtual PageReference TeaserLink { get; set; }
        [Display(Name = "Link text on button", Order = 50,
           GroupName = SystemTabNames.PageHeader)]
        public virtual string TeaserLinkText { get; set; }
    }
}