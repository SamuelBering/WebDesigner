using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDesigner.Models.Pages;

namespace WebDesigner.Models.ViewModels
{

    public class AboutUsPageViewModel<T> : PageViewModel<T> where T : SitePageData
    {
        public AboutUsPageViewModel(T currentPage) : base(currentPage)
        {
            this.AllStaffContentArea = new ContentArea();          
        }

        public ContentArea AllStaffContentArea { get; set; }
    }
}