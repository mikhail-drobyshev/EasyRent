using System;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApp.Helpers
{
    public class Singleton : IDiSingleton
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}