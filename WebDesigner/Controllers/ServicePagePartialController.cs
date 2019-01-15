using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using WebDesigner.Models.ViewModels;

namespace WebDesigner.Controllers
{
    public class ServicePagePartialController : PartialContentController<ServicePage>
    {
        public override ActionResult Index(ServicePage currentPage)
        {
            return PartialView(PageViewModel.Create(currentPage));
        }
    }
}