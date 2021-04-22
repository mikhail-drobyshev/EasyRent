using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUserPictures
{
    /// <summary>
    /// 
    /// </summary>
    public class ErUserPicturesCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ErUserPicture ErUserPicture { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErUserSelectList { get; set; }
    }
}