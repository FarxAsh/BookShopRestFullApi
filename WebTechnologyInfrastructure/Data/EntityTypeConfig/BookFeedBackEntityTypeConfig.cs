using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class BookFeedBackEntityTypeConfig : IEntityTypeConfiguration<BookFeedBack>
    {
        public void Configure(EntityTypeBuilder<BookFeedBack> builder)
        {
            builder.HasKey(bfd => bfd.Id);
            builder.HasOne(bfd => bfd.Book).WithMany(bfd => bfd.FeedBacks).HasForeignKey(bfd => bfd.BookID);

            builder.Property(bfd => bfd.Comment).IsRequired();
            builder.Property(bfd => bfd.Date).IsRequired();
            builder.Property(bfd => bfd.UserName).IsRequired();
        }
    }
}
