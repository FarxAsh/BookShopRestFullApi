using WebTechnologyProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTechnologyProjectInfrastructure.Data.EntityTypeConfig
{
    public class AuthorEntityTypeConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.HasMany(author => author.Books).WithOne(book => book.Author).HasForeignKey(book => book.AuthorID);

            builder.Property(author => author.FirstName).IsRequired();
            builder.Property(author => author.LastName).IsRequired();
            builder.Property(author => author.ImagePath).IsRequired();
            builder.Property(author => author.Biography).HasAnnotation("MinLenght", 100)
                                                        .HasMaxLength(500)
                                                        .IsRequired();

        }
    }
}
