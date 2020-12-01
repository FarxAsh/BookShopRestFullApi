using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class OrderEntityTypeConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasOne(order => order.OrderDetails).WithOne(od => od.Order);

            builder.Property(order => order.FirstName).IsRequired();
            builder.Property(order => order.LastName).IsRequired();
            builder.Property(order => order.TotalPrice).HasAnnotation("MinLenght", 0).IsRequired();
            builder.Property(order => order.Byer).IsRequired();
            builder.Property(order => order.Adress).IsRequired();
            builder.Property(order => order.ContactPhone).IsRequired();
            builder.Property(order => order.PaymentType).IsRequired();
            builder.Property(order => order.deleveryDateTime).IsRequired();
            builder.Property(order => order.orderDateTime).IsRequired();
        }
    }
}
