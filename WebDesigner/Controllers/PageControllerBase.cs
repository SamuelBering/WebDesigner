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
using System.Collections.Generic;

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

        protected void InitPageViewModel(IPageViewModel<T> viewmodel, T currentPage)
        {
            viewmodel.Loader = loader;
            viewmodel.SiteDefinition = this.siteDefinitionResolver.GetByContent(ContentReference.StartPage, false);
            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor
                .Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.AncestorPages = FilterForVisitor
                .Filter(loader.GetAncestors(currentPage.ContentLink))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            if (viewmodel.AncestorPages.Count() <= 1)
                viewmodel.SubMenuRootPage = currentPage;
            else
                viewmodel.SubMenuRootPage = viewmodel.AncestorPages.FirstOrDefault();

            viewmodel.SubMenuRootPage = loader.Get<SitePageData>(viewmodel.SubMenuRootPage.ContentLink, viewmodel.CurrentPage.Language);

            viewmodel.SubMenuPages = FilterForVisitor
               .Filter(loader.GetChildren<SitePageData>(viewmodel.SubMenuRootPage.ContentLink))
               .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.Section = currentPage.ContentLink.GetSection();
        }

        protected IPageViewModel<T> CreatePageViewModel(T currentPage)
                    
        {
            var viewmodel = PageViewModel.Create(currentPage);

            InitPageViewModel(viewmodel, currentPage);

            //viewmodel.Loader = loader;
            //viewmodel.SiteDefinition = this.siteDefinitionResolver.GetByContent(ContentReference.StartPage, false);
            //viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            //viewmodel.MenuPages = FilterForVisitor
            //    .Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
            //    .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            //viewmodel.AncestorPages = FilterForVisitor
            //    .Filter(loader.GetAncestors(currentPage.ContentLink))
            //    .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            //if (viewmodel.AncestorPages.Count() <= 1)
            //    viewmodel.SubMenuRootPage = currentPage;
            //else
            //    viewmodel.SubMenuRootPage = viewmodel.AncestorPages.FirstOrDefault();

            //viewmodel.SubMenuRootPage = loader.Get<SitePageData>(viewmodel.SubMenuRootPage.ContentLink, viewmodel.CurrentPage.Language);

            //viewmodel.SubMenuPages = FilterForVisitor
            //   .Filter(loader.GetChildren<SitePageData>(viewmodel.SubMenuRootPage.ContentLink))
            //   .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            //viewmodel.Section = currentPage.ContentLink.GetSection();
            return viewmodel;
        }
    }
}