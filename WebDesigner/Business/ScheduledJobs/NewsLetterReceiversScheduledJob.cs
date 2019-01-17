using WebDesigner.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Forms.Core.Data;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using System.Linq;
using EPiServer.Forms.Implementation.Elements;
using System;
using System.Collections.Generic;
using EPiServer.Forms.Core.Models;
using System.Threading;

namespace WebDesigner.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "Update newsletter receivers list",
    Description = "Update newsletter receivers list on services-page.")]
    public class NewsLetterReceiversScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;
        public NewsLetterReceiversScheduledJob()
        {
            IsStoppable = true;
        }
        public override void Stop()
        {
            _stopSignaled = true;
        }
        public override string Execute()
        {
            OnStatusChanged(string.Format(
                "Starting execution of {0}", this.GetType()));

            var finder = ServiceLocator.Current
                .GetInstance<IPageCriteriaQueryService>();

            var language = Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2);

            var criteria = new PropertyCriteriaCollection();

            if (language == "en")
            {
                criteria.Add(new PropertyCriteria
                {
                    Type = PropertyDataType.LongString,
                    Name = "PageName",
                    Condition = EPiServer.Filters.CompareCondition.Equal,
                    Value = "Services"
                });
            }
            else if (language == "sv")
            {
                criteria.Add(new PropertyCriteria
                {
                    Type = PropertyDataType.LongString,
                    Name = "PageName",
                    Condition = EPiServer.Filters.CompareCondition.Equal,
                    Value = "Tjänster"
                });
            }
            else
                throw new InvalidOperationException($"No suppor for language branch: {language}");

            var servicesPage = finder.FindPagesWithCriteria(
                    ContentReference.RootPage as PageReference, criteria, language)[0] as ServicesPage;

            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            if (servicesPage != null && servicesPage.MainContentArea != null && servicesPage.MainContentArea.Items.Any())
            {
                int count = 0;
                FormContainerBlock formContainerBlock = null;

                foreach (var item in servicesPage.MainContentArea.Items)
                {
                    try
                    {
                        formContainerBlock = loader.Get<FormContainerBlock>(item.ContentLink);
                    }
                    catch (TypeMismatchException)
                    {
                        if (count >= servicesPage.MainContentArea.Items.Count)
                            throw;
                    }
                    if (_stopSignaled)
                    {
                        return "Stop of job was called";
                    }
                    count++;
                }

                if (formContainerBlock != null)
                {
                    var formDataRepository = ServiceLocator.Current.GetInstance<IFormDataRepository>();

                    List<Submission> submittedData = formDataRepository.GetSubmissionData(
                        new FormIdentity(formContainerBlock.Form.FormGuid, servicesPage.Language.Name),
                        DateTime.Now.AddDays(-100), DateTime.Now)
                        .ToList();

                    if (submittedData.Count > 0)
                    {
                        var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
                        var clone = servicesPage.CreateWritableClone() as ServicesPage;
                        var editString = servicesPage.MainBody.ToHtmlString();
                        int length = editString.IndexOf("<div id=\"newsletter-receivers\">");

                        editString = editString.Substring(0, length == -1 ? editString.Length : length);
                        editString += "<div id=\"newsletter-receivers\"><ul style='color:black;'>";
                        count = 0;

                        foreach (var submission in submittedData)
                        {
                            string email;
                            if (language == "en")
                                email = submission.Data["__field_40"] as string;
                            else
                                email = submission.Data["__field_36"] as string;

                            editString += $"<li>{email}</li>";
                            if (_stopSignaled)
                            {
                                return "Stop of job was called";
                            }
                            count++;
                        }
                        editString += "</ul></div>";
                        clone.MainBody = new XhtmlString(editString);
                        repo.Save(clone, EPiServer.DataAccess.SaveAction.CheckIn,
                            EPiServer.Security.AccessLevel.NoAccess);

                        return $"The newsletter receivers list on the services-page has been updated and now contains {count} customer(s) in total.";
                    }
                    return "No submitted data was found";
                }
                return "No form container block was found";
            }
            return "No services page with the page name: 'Services' was found or services page was found but MainContentArea was empty.";
        }
    }
}