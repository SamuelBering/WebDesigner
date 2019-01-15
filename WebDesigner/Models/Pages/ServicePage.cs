using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
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
    }
}