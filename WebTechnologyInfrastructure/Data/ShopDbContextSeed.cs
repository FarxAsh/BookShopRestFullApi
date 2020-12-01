using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Enums;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class ShopDbContextSeed
    {
        public static async Task SeedAsync(ShopDbContext dbContext)
        {
            if(!await dbContext.Authors.AnyAsync())
            {
                await dbContext.Authors.AddRangeAsync(
                     new Author
                     {
                         FirstName = "Leo",
                         LastName = "Tolstoy",
                         ImagePath = "/Images/Tolstoy.jpg",
                         Biography = "Born to an aristocratic Russian family in 1828,[3] he is best known for the novels " +
                                   "War and Peace (1869) and Anna Karenina (1877),[8] often cited as pinnacles of realist " +
                                   "fiction.He first achieved literary acclaim in his twenties with his semi-autobiographical trilogy, " +
                                   "Childhood, Boyhood, and Youth (1852–1856), and Sevastopol Sketches (1855)",
                         Genre = Genre.Fiction
                     },
                      new Author
                      {
                          FirstName = "George",
                          LastName = "Orwell",
                          ImagePath = "/Images/Orwell.jpg",
                          Biography = "Eric Arthur Blair (25 June 1903 – 21 January 1950),better known by his pen name George Orwell, " +
                                      "was an English novelist and essayist, journalist and critic.[2] His work is characterised" +
                                      " by lucid prose, biting social criticism, opposition to totalitarianism, and outspoken support " +
                                      "of democratic socialism",
                          Genre = Genre.Fantasy

                      }
                    );
                await dbContext.SaveChangesAsync();
            }

            if(!await dbContext.Books.AnyAsync())
            {
                await dbContext.Books.AddRangeAsync(
                        new Book
                        {
                            Title = "War and Peace",
                            Year = 2002,
                            Pages = 800,
                            Description = "War and Peace is a novel by the Russian author Leo Tolstoy, " +
                                     "published serially, then in its entirety in 1869. It is regarded as one of Tolstoy's " +
                                     "finest literary achievements",
                            ImagePath = "/Images/WarAndPeace.jpeg",
                            Genre = Genre.Fiction,
                            Price = 1200,
                            AuthorID = 1
                        },

                        new Book
                        {
                            Title = "1984",
                            Year = 2010,
                            Pages = 200,
                            Description = "Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian novel by English novelist " +
                                          "George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and " +
                                          "final book completed in his lifetime.",
                            Genre = Genre.Fantasy,
                            Price = 400,
                            AuthorID = 2,
                            ImagePath = "/Images/Oruel.jpeg",
                        });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
