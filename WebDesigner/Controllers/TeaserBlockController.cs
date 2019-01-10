using WebDesigner.Models.Blocks;
using WebDesigner.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System;
using System.Web.Mvc;

namespace WebDesigner.Controllers
{
    [TemplateDescriptor(Tags = new[] { TeaserTags.Big },
    AvailableWithoutTag = true)]
    public class TeaserBlockController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            var viewmodel = new TeaserBlockViewModel
            {
                CurrentBlock = currentBlock,                
            };
            return PartialView(viewmodel);
        }
    }
    //[TemplateDescriptor(Tags = new[] { SiteTags.Wide })]
    //public class TeaserBlockWideController : BlockController<TeaserBlock>
    //{
    //    public override ActionResult Index(TeaserBlock currentBlock)
    //    {
    //        var viewmodel = new TeaserBlockViewModel
    //        {
    //            CurrentBlock = currentBlock,
    //            TodaysVisitorCount = (new Random()).Next(300, 900)
    //        };
    //        return PartialView(viewmodel);
    //    }
    //}
    //[TemplateDescriptor(Tags = new[] { SiteTags.Narrow })]
    //public class TeaserBlockNarrowController : BlockController<TeaserBlock>
    //{
    //    public override ActionResult Index(TeaserBlock currentBlock)
    //    {
    //        var viewmodel = new TeaserBlockViewModel
    //        {
    //            CurrentBlock = currentBlock,
    //            TodaysVisitorCount = (new Random()).Next(300, 900)
    //        };
    //        return PartialView(viewmodel);
    //    }
    //}
}