using System;

namespace WebApp.Helpers
{
    public class Scoped : IDiScoped
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();   
    }
}