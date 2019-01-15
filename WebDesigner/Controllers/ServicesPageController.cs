using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class ServicesPageController : PageControllerBase<ServicesPage>
    {
        public ServicesPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(ServicesPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}