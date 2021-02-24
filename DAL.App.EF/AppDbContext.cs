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
        public DbSet<ErUserType> ErUserTypes { get; set; } = default!;
        public DbSet<ErUserPicture> ErUserPictures { get; set; } = default!;

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
                OnBeforeSaving();
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }

            public override async Task<int> SaveChangesAsync(
                bool acceptAllChangesOnSuccess, 
                CancellationToken cancellationToken = default(CancellationToken)
            )
            {
                OnBeforeSaving();
                return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                    cancellationToken));
            }

            private void OnBeforeSaving()
            {
                var entries = ChangeTracker.Entries();
                var utcNow = DateTime.UtcNow;

                foreach (var entry in entries)
                {
                    // for entities that inherit from BaseEntity,
                    // set UpdatedOn / CreatedOn appropriately
                    if (entry.Entity is BaseEntity trackable)
                    {
                        switch (entry.State)
                        {
                            case EntityState.Modified:
                                // set the updated date to "now"
                                trackable.UpdatedOn = utcNow;

                                // mark property as "don't touch"
                                // we don't want to update on a Modify operation
                                entry.Property("CreatedOn").IsModified = false;
                                break;

                            case EntityState.Added:
                                // set both updated and created date to "now"
                                trackable.CreatedOn = utcNow;
                                trackable.UpdatedOn = utcNow;
                                break;
                        }
                    }
                }
            }
        }
    }