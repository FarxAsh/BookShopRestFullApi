using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class BookEntityTypeConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.HasOne(book => book.Author).WithMany(author => author.Books).HasForeignKey(book => book.AuthorID);
            builder.HasMany(book => book.FeedBacks).WithOne(feedBack => feedBack.Book).HasForeignKey(book => book.BookID);

            builder.Property(book => book.Year).HasColumnName("Year_of_Publish");
            builder.Property(book => book.Description).HasAnnotation("MinLenght", 200).HasMaxLength(500);
            builder.Property(book => book.Title).IsRequired();
            builder.Property(book => book.ImagePath).IsRequired();

        }
    }
}
