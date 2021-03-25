using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyLocations
{
    public class PropertyLocationsCreatEditViewModel
    {
        public PropertyLocation PropertyLocation { get; set; } = default!;
        public SelectList? PropertySelectList { get; set; }
    }
}