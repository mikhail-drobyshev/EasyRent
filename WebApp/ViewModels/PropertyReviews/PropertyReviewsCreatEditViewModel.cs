using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyReviews
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyReviewsCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyReview PropertyReview { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? PropertySelectList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErUserSelectList { get; set; }
    }
}