using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUserReviews
{
    /// <summary>
    /// 
    /// </summary>
    public class ErUserReviewsCreatEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ErUserReview ErUserReview { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public SelectList? ErUserSelectList { get; set; }
    }
}