using System;
using System.ComponentModel.DataAnnotations;
using AlloyTraining.Business.SelectionFactories;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebDesigner.Models.Pages
{
    [ContentType(DisplayName = "Service", 
        GroupName = SiteGroupNames.Common,          
        GUID = "6661489a-67e8-422e-8f34-cf9b97f2afaa", 
        Description = "Here you can present a specific service for your company.")]
    [SiteStartIcon]
    public class ServicePage : StandardPage
    {
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Symbol = "fa fa-pencil";
        }

        [SelectOne(SelectionFactoryType = typeof(SymbolSelectionFactory))]
        [Display(Name = "Symbol",
            GroupName = SystemTabNames.Content, Order = 20)]
        public virtual string Symbol { get; set; }
    }
}