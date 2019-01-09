﻿using WebDesigner.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System.Web.Mvc;

namespace WebDesigner.Business.ExtensionMethods
{
    public static class LayoutExtensionMethods
    {
        public static string RenderFooterText(this HtmlHelper helper)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = loader.Get<StartPage>(ContentReference.StartPage);
            return startPage.FooterText;
        }
    }
}