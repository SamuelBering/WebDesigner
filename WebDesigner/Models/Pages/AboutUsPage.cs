using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "About us", 
        GroupName = SiteGroupNames.Specialized, 
        Order = 20, 
        GUID = "44fb66a6-d8a6-4546-9191-96534079cef5", 
        Description = "The about-us page for a website with two areas for blocks and partial pages.")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(StaffPage) })]
    public class AboutUsPage : StandardPage
    {             
        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop images, blocks, folders, and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData),
                      typeof(ImageData), typeof(ContentFolder))]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area heading",
            GroupName = SystemTabNames.Content, Order = 30)]
        public virtual string MainContentAreaHeading { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area intro",
          GroupName = SystemTabNames.Content, Order = 40)]
        public virtual string MainContentAreaIntro { get; set; }

        [CultureSpecific]
        [Display(Name = "Related content area",
          Description = "Drag and drop staff pages here",
          GroupName = SystemTabNames.Content,
          Order = 50)]
        [AllowedTypes(typeof(StaffPage))]
        public virtual ContentArea RelatedContentArea { get; set; }

        [CultureSpecific]
        [Display(Name = "Main body heading",
           GroupName = SystemTabNames.Content, Order = 60)]
        public virtual string MainBodyHeading { get; set; }

        [Display(Name = "Main body image",
          GroupName = SystemTabNames.Content, Order = 70)]
        [UIHint(UIHint.Image)] // filters to only show images
        public virtual ContentReference MainBodyImage { get; set; }
    }
}