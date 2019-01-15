using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "Services", 
        GroupName = SiteGroupNames.Specialized, 
        Order = 30, 
        GUID = "f2e75963-ad4f-4401-add0-c7a5639a6f45", 
        Description = "Here you can present services for your company.")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(ServicePage) })]
    public class ServicesPage : StandardPage
    {             
        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop service pages here",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData),
                      typeof(ImageData), typeof(ContentFolder))]
        public virtual ContentArea MainContentArea { get; set; }


        [CultureSpecific]
        [Display(Name = "Main body heading",
           GroupName = SystemTabNames.Content, Order = 30)]
        public virtual string MainBodyHeading { get; set; }

    }
}