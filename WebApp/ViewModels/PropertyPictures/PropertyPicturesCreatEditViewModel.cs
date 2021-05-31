using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyPictures
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyPicturesCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyPicture PropertyPicture { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? PropertySelectList { get; set; }
    }
}