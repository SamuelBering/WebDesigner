using WebDesigner.Business.ExtensionMethods;
using WebDesigner.Models.Pages;
using WebDesigner.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        protected readonly IContentLoader loader;
        protected readonly ISiteDefinitionResolver siteDefinitionResolver;

        public PageControllerBase(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver)
        {
            this.siteDefinitionResolver = siteDefinitionResolver;
            this.loader = loader;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        protected IPageViewModel<TPage> CreatePageViewModel<TPage>(TPage currentPage)
                    where TPage : SitePageData
        {
            var viewmodel = PageViewModel.Create(currentPage);
            viewmodel.SiteDefinition = this.siteDefinitionResolver.GetByContent(ContentReference.StartPage, false);
            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);
            //viewmodel.MenuPages = FilterForVisitor
            //    .Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
            //    .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.MenuPages = FilterForVisitor
                .Filter(loader.GetChildren<SitePageData>(currentPage.ContentLink))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);
            viewmodel.Section = currentPage.ContentLink.GetSection();
            return viewmodel;
        }
    }
}