using System.Collections.Generic;
using Domain.App;

namespace WebApp.ViewModels.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class TestViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<PropertyType> PropertyTypes { get; set; } = default!;
    }
}