using System;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApp.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class Singleton : IDiSingleton
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}