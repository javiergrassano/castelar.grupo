using System.Data.Entity;

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
            //modelBuilder.Entity<Artist>()
            //    .HasMany(e => e.Products)
            //    .WithRequired(e => e.Artist)
            ////    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Cart>()
            //    .HasMany(e => e.CartItems)
            //    .WithRequired(e => e.Cart)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderDetails)
            //    .WithRequired(e => e.Order)
            //    .WillCascadeOnDelete(false);

            ////modelBuilder.Entity<Product>()
            ////    .HasMany(e => e.OrderDetails)
            ////    .WithRequired(e => e.Product)
            ////    .WillCascadeOnDelete(false);

            ////modelBuilder.Entity<Product>()
            ////    .HasMany(e => e.Ratings)
            ////    .WithRequired(e => e.Product)
            ////    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Orders)
            //    .WithRequired(e => e.User)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Ratings)
            //    .WithRequired(e => e.User)
            //    .WillCascadeOnDelete(false);
        }
    }
}
