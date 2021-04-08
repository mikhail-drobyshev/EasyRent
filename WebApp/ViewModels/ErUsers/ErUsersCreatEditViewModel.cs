using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.ErUsers
{
    public class ErUsersCreatEditViewModel
    {
        public ErUser ErUser { get; set; } = default!;
        public SelectList? GenderSelectList { get; set; }
    }
}