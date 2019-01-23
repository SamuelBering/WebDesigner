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
        StartPage StartPage { get; set; }
        SitePageData SubMenuRootPage { get; set; }
        IEnumerable<SitePageData> MenuPages { get; set; }
        IEnumerable<SitePageData> SubMenuPages { get; set; }
        IEnumerable<SitePageData> AncestorPages { get; set; }
        IContent Section { get; set; }
        IContentLoader Loader { get; set; }
    }
}