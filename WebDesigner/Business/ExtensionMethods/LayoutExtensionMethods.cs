using WebDesigner.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System.Web.Mvc;
using System.Text;
using EPiServer.Filters;
using System.Linq;
using EPiServer.Web.Routing;

namespace WebDesigner.Business.ExtensionMethods
{
    public static class LayoutExtensionMethods
    {
        private static void RenderFooterText(StringBuilder stringBuilder, SitePageData page, IContentLoader loader)
        {
            stringBuilder.Append($"{CreateLink(page)}");
            var childPages = FilterForVisitor
               .Filter(loader.GetChildren<SitePageData>(page.ContentLink))
               .Cast<SitePageData>().Where(p => p.VisibleInMenu);

            if (childPages != null && childPages.Count() > 0)
            {
                stringBuilder.Append("<ul>");
                foreach(var childPage in childPages)
                {
                    stringBuilder.Append("<li>");
                    RenderFooterText(stringBuilder, childPage, loader);
                    stringBuilder.Append("</li>");
                }
                stringBuilder.Append("</ul>");
            }
        }

        private static string CreateLink(SitePageData page)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            return $"<a href='{urlResolver.GetUrl(page.ContentLink)}'>{page.Name}</a>";
        }

        public static MvcHtmlString RenderFooterText(this HtmlHelper helper, IContentLoader loader)
        {
            

            StringBuilder stringBuilder = new StringBuilder();
            var startPage = loader.Get<StartPage>(ContentReference.StartPage);
            stringBuilder.Append($"<div class='row'><div class='col-md-12'>{startPage.FooterText}</div></div><hr>");

            stringBuilder.Append($"<div class='row'><div class='col-md-2'>{CreateLink(startPage)}</div>");

            var childPages = FilterForVisitor
                .Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);
            if (childPages != null && childPages.Count() > 0)
            {
                foreach (var childPage in childPages)
                {                
                    stringBuilder.Append("<div class='col-md-2'>");
                    RenderFooterText(stringBuilder, childPage, loader);
                    stringBuilder.Append("</div>");
                }
            }
            stringBuilder.Append($"</div>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}