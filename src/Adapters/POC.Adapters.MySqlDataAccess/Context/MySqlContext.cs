using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.ValueObjects;

namespace POC.Adapters.MySqlDataAccess.Context
{
    public class MySqlContext: DbContext
    {       

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<NameVo> Names { get; set; }
        public DbSet<CpfVo> Cpfs { get; set; }
        public DbSet<EmailVo> Emails { get; set; }

        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);           
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnType("char(36)");
            
            modelBuilder.Entity<OrderItem>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderItem>().Property(o => o.Id).HasColumnType("char(36)");

            modelBuilder.Entity<Delivery>().HasKey(c => c.Id);
            modelBuilder.Entity<Delivery>().Property(d => d.Id).HasColumnType("char(36)");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnType("char(36)");

            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Address>().Property(a => a.Id).HasColumnType("char(36)");


            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
