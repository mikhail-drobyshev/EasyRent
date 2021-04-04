using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.PropertyReviews
{
    public class PropertyReviewsCreatEditViewModel
    {
        public PropertyReview PropertyReview { get; set; } = default!;
        public SelectList? PropertySelectList { get; set; }
        public SelectList? ErUserSelectList { get; set; }
    }
}