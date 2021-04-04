using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Properties
{
    public class PropertiesCreatEditViewModel
    {
        public Property Property { get; set; } = default!;
        public SelectList? PropertyTypeSelectList { get; set; }
        public SelectList? ErUserSelectList { get; set; }
    }
}