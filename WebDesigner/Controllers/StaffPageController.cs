using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class StaffPageController : PageControllerBase<StaffPage>
    {
        public StaffPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(StaffPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}