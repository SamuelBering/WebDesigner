using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace WebDesigner.Models.Media
{
    [ContentType(DisplayName = "Image File", GUID = "0f9ebd84-65c9-4c7b-aa8a-c1989cd67a16", 
        Description = "Use this to upload image files.")]
    [MediaDescriptor(ExtensionString = "png,gif,jpg,jpeg")]
    public class ImageFile : ImageData
    {

        [CultureSpecific]
        [Editable(true)]
        public virtual string Description { get; set; }

    }
}