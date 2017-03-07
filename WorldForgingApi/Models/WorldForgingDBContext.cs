using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Comments;
using WorldForging.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenIddict;

namespace WorldForgingApi.Models
{
    public class WorldForgingDBContext : OpenIddictDbContext<ApplicationUser>
    {
        public WorldForgingDBContext(DbContextOptions<WorldForgingDBContext> options)
            : base(options)
        { }

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Articles).WithOne(i => i.Author);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Comments).WithOne(c => c.Author).HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Article>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Article>().HasOne(i => i.Author).WithMany(u => u.Articles);
            modelBuilder.Entity<Article>().HasMany(i => i.Comments).WithOne(c => c.Article);

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>().HasOne(c => c.Author).WithMany(u => u.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(c => c.Article).WithMany(i => i.Comments);
            modelBuilder.Entity<Comment>().HasOne(c => c.Parent).WithMany(c => c.Children);
            modelBuilder.Entity<Comment>().HasMany(c => c.Children).WithOne(c => c.Parent);
        }
        #endregion Methods

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

        public DbSet<WorldForging.Models.World> Worlds { get; set; }

        public DbSet<WorldForging.Models.Story> Stories { get; set; }

        public DbSet<WorldForging.Models.Faction> Factions { get; set; }

        public DbSet<WorldForging.Models.Character> Characters { get; set; }

        public DbSet<WorldForging.Models.Belief> Beliefs { get; set; }

        public DbSet<WorldForging.Models.Subject> Subjects { get; set; }

        public DbSet<WorldForging.Models.Culture> Cultures { get; set; }

        public DbSet<WorldForging.Models.Entity> Entities { get; set; }

        public DbSet<WorldForging.Models.Desire> Desires { get; set; }

        public DbSet<WorldForging.Models.WorldEvent> Events { get; set; }

        public DbSet<WorldForging.Models.Group> Groups { get; set; }

        public DbSet<WorldForging.Models.Location> Locations { get; set; }

        public DbSet<WorldForging.Models.Race> Races { get; set; }

        public DbSet<WorldForging.Models.Reason> Reasons { get; set; }

        public DbSet<WorldForging.Models.Religion> Religions { get; set; }

        public DbSet<WorldForging.Models.Convention> Conventions { get; set; }

        public DbSet<WorldForging.Models.Item> Items { get; set; }

        public DbSet<WorldForging.Models.EntityRelationship> EntityRelationships { get; set; }

        public DbSet<WorldForging.Models.Relationship> Relationships { get; set; }

        public DbSet<WorldForging.Models.EntityType> EntityTypes { get; set; }
    }

    public static class Extensions
    {
        public static TEntity Find<TEntity>(this DbSet<TEntity> set, params object[] keyValues) where TEntity : class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<DbContext>();

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = context.ChangeTracker.Entries<TEntity>();

            var i = 0;
            foreach (var property in key.Properties)
            {
                entries = Enumerable.Where(entries, e => e.Property(property.Name).CurrentValue == keyValues[i]);
                i++;
            }

            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }

            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = Queryable.Where(set, (Expression<Func<TEntity, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, "Id"),
                        Expression.Constant(keyValues[0])),
                    parameter));

            // Look in the database
            return query.FirstOrDefault();
        }
    }
}
