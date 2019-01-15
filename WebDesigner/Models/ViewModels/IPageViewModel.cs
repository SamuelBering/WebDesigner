using WebDesigner.Models.Pages;
using EPiServer.Core;
using System.Collections.Generic;
using EPiServer.Web;
using EPiServer;

namespace WebDesigner.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        SiteDefinition SiteDefinition { get; set; }
        StartPage StartPage { get; }
        SitePageData SubMenuRootPage { get; }
        IEnumerable<SitePageData> MenuPages { get; }
        IEnumerable<SitePageData> SubMenuPages { get; }
        IEnumerable<SitePageData> AncestorPages { get; }
        IContent Section { get; }
        IContentLoader Loader { get; set; }
    }
}