using System;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext
    {
        
        public DbSet<ErUser> ErUsers { get; set; } = default!;
        public DbSet<Gender> Genders { get; set; } = default!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // disable cascade delete initially for everything
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            /*
            builder.Entity<Contact>()
                .HasIndex(x => new {x.PersonId, x.ContactTypeId})
                .IsUnique();
*/

            builder.Entity<Gender>()
                .HasMany(m => m.ErUsers)
                .WithOne(o => o.Gender!)
                .OnDelete(DeleteBehavior.Cascade);

            
            /*
            // You cannot have two delete paths in parallel!
            builder.Entity<ContactType>()
                .HasMany(m => m.SecondaryContacts)
                .WithOne(o => o.SecondaryContactType!)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }
    }
}