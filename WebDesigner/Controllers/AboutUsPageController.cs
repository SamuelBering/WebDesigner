using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;
using WebDesigner.Models.ViewModels;
using EPiServer.Core;

namespace WebDesigner.Controllers
{
    public class AboutUsPageController : PageControllerBase<AboutUsPage>
    {
        public AboutUsPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(AboutUsPage currentPage)
        {
            AboutUsPageViewModel<AboutUsPage> viewmodel = new AboutUsPageViewModel<AboutUsPage>(currentPage);

            InitPageViewModel(viewmodel, currentPage);

            foreach(var staffPage in viewmodel.SubMenuPages)
            {
                viewmodel.AllStaffContentArea.Items.Add(new ContentAreaItem { ContentLink=staffPage.ContentLink});
            }

            return View(viewmodel);

        }
    }
}