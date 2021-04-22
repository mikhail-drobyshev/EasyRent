using System;

namespace WebApp.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class Transient : IDiTransient
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}