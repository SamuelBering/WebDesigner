using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class ServicePageController : PageControllerBase<ServicePage>
    {
        public ServicePageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(ServicePage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}