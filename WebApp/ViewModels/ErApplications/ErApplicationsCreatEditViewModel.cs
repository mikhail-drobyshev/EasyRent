using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class ErApplicationsCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ErApplication ErApplication { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErUserSelectList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SelectList? PropertySelectList { get; set; }
    }
}