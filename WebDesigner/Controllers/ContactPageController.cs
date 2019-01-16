using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;

namespace WebDesigner.Controllers
{
    public class ContactPageController : PageControllerBase<ContactPage>
    {
        public ContactPageController(IContentLoader loader, ISiteDefinitionResolver siteDefinitionResolver) : base(loader, siteDefinitionResolver)
        {
        }

        public ActionResult Index(ContactPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}