using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class OrderDetailsEntityTypeConfig : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {

            builder.HasKey(od => od.Id);
            builder.HasMany(od => od.Books);
            builder.HasOne(od => od.Order).WithOne(order => order.OrderDetails);
            
        }
    }
}
