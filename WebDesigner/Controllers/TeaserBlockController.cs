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
}