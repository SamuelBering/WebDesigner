using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class AboutUsPageController : PageControllerBase<AboutUsPage>
    {
        public AboutUsPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(AboutUsPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}