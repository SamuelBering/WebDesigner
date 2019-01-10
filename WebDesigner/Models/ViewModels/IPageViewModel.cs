using WebDesigner.Models.Pages;
using EPiServer.Core;
using System.Collections.Generic;
using EPiServer.Web;

namespace WebDesigner.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        SiteDefinition SiteDefinition { get; set; }
        StartPage StartPage { get; }
        IEnumerable<SitePageData> MenuPages { get; }
        IContent Section { get; }
    }
}