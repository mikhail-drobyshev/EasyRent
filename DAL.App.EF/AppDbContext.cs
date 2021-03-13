using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext
    {
        
        public DbSet<ErUser> ErUsers { get; set; } = default!;
        public DbSet<Gender> Genders { get; set; } = default!;
        
        public DbSet<ErUserReview> ErUserReviews { get; set; } = default!;
        public DbSet<ErUserPicture> ErUserPictures { get; set; } = default!;
        
        public DbSet<Property> Properties { get; set; } = default!;
        public DbSet<PropertyType> PropertyTypes { get; set; } = default!;

        public DbSet<PropertyLocation> PropertyLocations { get; set; } = default!;
        public DbSet<PropertyPicture> PropertyPictures { get; set; } = default!;
        public DbSet<PropertyReview> PropertyReviews { get; set; } = default!;
        
        public DbSet<ErApplication> ErApplications { get; set; } = default!;
        public DbSet<ErApplicationStatus> ErApplicationStatuses { get; set; } = default!;
        public DbSet<Dispute> Disputes { get; set; } = default!;
        public DbSet<DisputeStatus> DisputeStatuses { get; set; } = default!;

        

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
        }

        /*
        builder.Entity<Contact>()
            .HasIndex(x => new {x.PersonId, x.ContactTypeId})
            .IsUnique();
*/

            // builder.Entity<Gender>()
            //     .HasMany(m => m.ErUsers)
            //     .WithOne(o => o.Gender!)
            //     .OnDelete(DeleteBehavior.Cascade);

            
            /*
            // You cannot have two delete paths in parallel!
            builder.Entity<ContactType>()
                .HasMany(m => m.SecondaryContacts)
                .WithOne(o => o.SecondaryContactType!)
                .OnDelete(DeleteBehavior.Cascade);
            */
            
            public override int SaveChanges(bool acceptAllChangesOnSuccess)
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }

            public override async Task<int> SaveChangesAsync(
                bool acceptAllChangesOnSuccess, 
                CancellationToken cancellationToken = default(CancellationToken)
            )
            {
                return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                    cancellationToken));
            }

           
            }
        }