using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class BasketItemEntityTypeConfig : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasKey(bi => bi.Id);
            builder.HasOne(bi => bi.Book);
            builder.Property(bi => bi.basketGuid);
            
        }
    }
}
