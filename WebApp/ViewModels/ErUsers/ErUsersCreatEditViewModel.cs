using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class ErUsersCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ErUser ErUser { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? GenderSelectList { get; set; }
    }
}