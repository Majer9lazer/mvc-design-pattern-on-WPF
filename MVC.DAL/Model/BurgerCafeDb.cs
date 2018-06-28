namespace MVC.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BurgerCafeDb : DbContext
    {
        public BurgerCafeDb()
            : base("name=BurgerCafeDb")
        {
        }

        public virtual DbSet<Burger> Burgers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>()
                .Property(e => e.BurgerName)
                .IsUnicode(false);

            modelBuilder.Entity<Burger>()
                .Property(e => e.BurgerComonents)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserWindowsAccountName)
                .IsUnicode(false);
        }
    }
}
