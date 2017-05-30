using ShoppingCart.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ShoppingCart.DAL
{
    public class DataInitialization : DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    {
        protected override void Seed(ShoppingCartContext context)
        {
            var categories = new List<Category>
            {
                new Category {
                    Name = "Technology"
                },
                new Category {
                    Name = "Science Fiction"
                },
                new Category {
                    Name = "Non Fiction"
                },
                new Category {
                    Name = "Graphic Novels"
                }
            };

            categories.ForEach(c => context.Categories.Add(c));

            var author = new Author
            {
                Biography = "...",
                FirstName = "Jamie",
                LastName = "Munro"
            };

            var books = new List<Book>
            {
                new Book {
                    Author = author,
                    Category = categories[0],
                    Description = "...",
                    Featured = true,
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                    Isbn = "1491914319",
                    ListPrice = 19.99m,
                    SalePrice = 17.99m,
                    Synopsis = "...",
                    Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                },
                new Book {
                    Author = author,
                    Category = categories[0],
                    Description = "...",
                    Featured = true,
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51AkFkNeUxL._AA160_.jpg",
                    Isbn = "1449319548",
                    ListPrice = 14.99m,
                    SalePrice = 13.99m,
                    Synopsis = "...",
                    Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development for Android and iPhone"
                },
                new Book {
                    Author = author,
                    Category = categories[0],
                    Description = "...",
                    Featured = false,
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51LpqnDq8-L._AA160_.jpg",
                    Isbn = "1449309860",
                    ListPrice = 19.99m,
                    SalePrice = 16.99m,
                    Synopsis = "...",
                    Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                },
                new Book {
                    Author = author,
                    Category = categories[0],
                    Description = "...",
                    Featured = false,
                    ImageUrl = "http://ecx.images-amazon.com/images/I/41JC54HEroL._AA160_.jpg",
                    Isbn = "1460954394",
                    ListPrice = 14.99m,
                    SalePrice = 13.49m,
                    Synopsis = "...",
                    Title = "Rapid Application Development With CakePHP"
                },
                 new Book {
                    Author = author,
                    Category = categories[1],
                    Description = "...",
                    Featured = true,
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                    Isbn = "1491914319",
                    ListPrice = 19.99m,
                    SalePrice = 17.99m,
                    Synopsis = "...",
                    Title = " Dynamic Client-Side Web Applications"
                }
                 

            };

            books.ForEach(b => context.Books.Add(b));

            context.SaveChanges();
        }
    }
}