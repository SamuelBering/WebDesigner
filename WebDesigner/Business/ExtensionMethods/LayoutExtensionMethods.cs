using WebDesigner.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System.Web.Mvc;
using System.Text;

namespace WebDesigner.Business.ExtensionMethods
{
    public static class LayoutExtensionMethods
    {
        private static void RenderFooterText( StringBuilder stringBuilder)
        {

        }

        public static string RenderFooterText(this HtmlHelper helper, IContentLoader loader)
        {
            //StringBuilder stringBuilder = new StringBuilder();
            
            var startPage = loader.Get<StartPage>(ContentReference.StartPage);
            //stringBuilder.Append($"{startPage.Name}");
            
            //RenderFooterText(stringBuilder)
            return startPage.FooterText;
        }
    }
}