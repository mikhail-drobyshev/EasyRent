
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Disputes
{
    /// <summary>
    /// 
    /// </summary>
    public class DisputesCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Dispute Dispute { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? DisputeStatusSelectList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErApplicationSelectList { get; set; }
    }
}