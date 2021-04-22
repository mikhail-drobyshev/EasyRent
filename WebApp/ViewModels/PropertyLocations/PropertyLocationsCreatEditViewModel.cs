using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyLocations
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyLocationsCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyLocation PropertyLocation { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? PropertySelectList { get; set; }
    }
}