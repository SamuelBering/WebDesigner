using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public StartPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }
        public ActionResult Index(StartPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}