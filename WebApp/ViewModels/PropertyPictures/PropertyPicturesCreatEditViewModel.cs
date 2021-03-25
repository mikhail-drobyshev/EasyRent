using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyPictures
{
    public class PropertyPicturesCreatEditViewModel
    {
        public PropertyPicture PropertyPicture { get; set; } = default!;
        public SelectList? PropertySelectList { get; set; }
    }
}