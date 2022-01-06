using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC.Modules.Domain.Entities;

namespace POC.Adapters.MySqlDataAccess.Model
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnType("char(36)");


            builder.OwnsOne(user => user.Name,
                             navigationBuilder =>
                             {
                                 navigationBuilder.Property(n => n.FirstName)
                                                  .HasColumnName("FirstName");
                                 navigationBuilder.Property(n => n.LastName)
                                                  .HasColumnName("LastName");
                             });

            builder.OwnsOne(user => user.Cpf,
                           navigationBuilder =>
                           {
                               navigationBuilder.Property(n => n.Number)
                                                .HasColumnName("Number");                            
                           });


            builder.OwnsOne(user => user.Email,
                         navigationBuilder =>
                         {
                             navigationBuilder.Property(n => n.Address)
                                              .HasColumnName("Address");
                         });

            builder.Property(user => user.Phone)
                 .HasColumnName("Phone");

        }
    }
}
