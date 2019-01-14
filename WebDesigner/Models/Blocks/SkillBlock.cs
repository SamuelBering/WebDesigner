using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
namespace WebDesigner.Models.Blocks
{
    [ContentType(DisplayName = "Skill",
        GUID = "bf594024-b729-43ba-bfa8-69ee97ca126f",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this for adding a skill")]
    [SiteBlockIcon]
    public class SkillBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Heading", Order = 10,
            GroupName = SystemTabNames.PageHeader)]
        public virtual string SkillHeading { get; set; }
        [CultureSpecific]
        [Display(Name = "Skill value", Order = 20,
             GroupName = SystemTabNames.PageHeader)]
        [Range(0, 100)]
        public virtual int? SkillValue { get; set; }
        [Display(Name = "Skill color", Order = 30,
            GroupName = SystemTabNames.PageHeader)]
        [ClientEditor(ClientEditingClass = "dijit/ColorPalette")]
        public virtual string SkillColor { get; set; }
    }
}