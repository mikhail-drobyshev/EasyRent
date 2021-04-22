using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Properties
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertiesCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Property Property { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? PropertyTypeSelectList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErUserSelectList { get; set; }
    }
}