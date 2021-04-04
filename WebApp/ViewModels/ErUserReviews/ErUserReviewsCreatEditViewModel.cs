using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUserReviews
{
    public class ErUserReviewsCreatEditViewModel
    {
        public ErUserReview ErUserReview { get; set; } = default!;
        public SelectList? ErUserSelectList { get; set; }
    }
}