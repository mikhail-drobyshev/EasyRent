using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUserPictures
{
    public class ErUserPicturesCreatEditViewModel
    {
        public ErUserPicture ErUserPicture { get; set; } = default!;
        public SelectList? ErUserSelectList { get; set; }
    }
}