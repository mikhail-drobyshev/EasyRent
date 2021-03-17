using System;

namespace WebApp.Helpers
{
    public class Transient : IDiTransient
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}