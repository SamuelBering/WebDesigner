using System.Collections.Generic;
using WebDesigner.Models.Pages;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer;

namespace WebDesigner.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; set; }
        public SiteDefinition SiteDefinition { get; set; }
        public StartPage StartPage { get; set; }
        public SitePageData SubMenuRootPage { get; set; }
        public IEnumerable<SitePageData> MenuPages { get; set; }
        public IEnumerable<SitePageData> SubMenuPages { get; set; }
        public IEnumerable<SitePageData> AncestorPages { get; set; }
        public IContentLoader Loader { get; set; }

        public IContent Section { get; set; }
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
    }
    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T currentPage) where T : SitePageData
        {
            return new PageViewModel<T>(currentPage);
        }
    }
}