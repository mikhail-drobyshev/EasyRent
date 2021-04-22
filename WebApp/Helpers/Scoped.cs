using System;

namespace WebApp.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class Scoped : IDiScoped
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();   
    }
}