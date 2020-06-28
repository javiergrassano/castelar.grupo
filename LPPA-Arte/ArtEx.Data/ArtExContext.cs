using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ArtEx.EF
{
    public partial class ArtExContext : DbContext
    {
        public ArtExContext()
            : base("name=ArtExDB")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderNumber> OrderNumbers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added ||
                            x.State == EntityState.Modified);

            var errors = new List<ValidationResult>();
            foreach (var e in changedEntities)
            {
                var vc = new ValidationContext(e.Entity, null, null);
                Validator.TryValidateObject(e.Entity, vc, errors, validateAllProperties: true);
            }

            return base.SaveChanges();
        }
    }
}
