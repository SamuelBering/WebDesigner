using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebDesigner.Models.Media
{
    [ContentType(DisplayName = "Any File", GUID = "78577daa-69b4-4493-a551-3a9a0f479565",
        Description = "Use this to upload any type of file.")]
    
    public class AnyFile : MediaData
    {
       
    }
}