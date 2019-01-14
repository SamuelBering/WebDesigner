using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using WebDesigner.Models.ViewModels;

namespace WebDesigner.Controllers
{
    public class StaffPagePartialController : PartialContentController<StaffPage>
    {
        public override ActionResult Index(StaffPage currentPage)
        {
            return PartialView(PageViewModel.Create(currentPage));
        }
    }
}