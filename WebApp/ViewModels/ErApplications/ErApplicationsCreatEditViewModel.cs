using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErApplications
{
    public class ErApplicationsCreatEditViewModel
    {
        public ErApplication ErApplication { get; set; } = default!;
        public SelectList? ErUserSelectList { get; set; }
        public SelectList? PropertySelectList { get; set; }
    }
}