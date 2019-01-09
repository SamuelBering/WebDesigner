﻿using WebDesigner.Models.Pages;
using EPiServer;
using System.Web.Mvc;
namespace WebDesigner.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public StartPageController(IContentLoader loader) : base(loader)
        {
        }
        public ActionResult Index(StartPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}