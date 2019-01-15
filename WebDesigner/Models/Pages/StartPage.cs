using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "Start", 
        GroupName = SiteGroupNames.Specialized, 
        Order = 10, 
        GUID = "54cc15bb-df6a-4b00-a243-c9791476b250", 
        Description = "The home page for a website with an area for blocks and partial pages.")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public class StartPage : SitePageData
    {     
        [CultureSpecific]
        [Display(Name = "Footer text",
            Description = "The footer text will be shown at the bottom of every page.",
            GroupName = SiteTabNames.SiteSettings, Order = 20)]
        public virtual string FooterText { get; set; }

        [CultureSpecific]
        [Display(Name = "Company name",
            Description = "Company name will be shown in the top left corner of every page",
            GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string CompanyName { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop images, blocks, folders, and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData),
                      typeof(ImageData), typeof(ContentFolder))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Background image",
           GroupName = SystemTabNames.Content, Order = 30)]
        [UIHint(UIHint.Image)] // filters to only show images
        public virtual ContentReference BackgroundImage { get; set; }
  
        [Display(Name = "Slider content area",
          Description = "Drag and drop images, blocks and pages with partial templates.",
          GroupName = SystemTabNames.Content,
          Order = 40)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData),
                    typeof(ImageData))]
        public virtual ContentArea SliderContentArea { get; set; }

        [Display(Name = "Related content area",
          Description = "Drag and drop images, blocks and pages with partial templates.",
          GroupName = SystemTabNames.Content,
          Order = 50)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData),
                    typeof(ImageData))]
        public virtual ContentArea RelatedContentArea { get; set; }


    }
}