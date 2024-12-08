using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void Seed(IMongoCollection<Product> productCollection)
        {
            bool productExists = productCollection.Find(p => true).Any();

            if (!productExists)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "Yerba Mate",
                    Category = "Beverages",
                    Summary = "Traditional Argentine infusion",
                    Description = "Yerba Mate is a traditional Argentine tea made from the leaves of the Ilex paraguariensis plant, commonly enjoyed with a gourd and bombilla.",
                    ImageFile = "yerba_mate.jpg",
                    Price = 10.50M
                },
                new Product
                {
                    Name = "Dulce de Leche",
                    Category = "Desserts",
                    Summary = "Sweet milk caramel spread",
                    Description = "A creamy, sweet caramel spread made from milk and sugar, used in desserts or enjoyed on its own.",
                    ImageFile = "dulce_de_leche.jpg",
                    Price = 7.25M
                },
                new Product
                {
                    Name = "Alfajor de Maicena",
                    Category = "Snacks",
                    Summary = "Classic Argentine cookie sandwich",
                    Description = "Two soft cookies made from cornstarch, sandwiched with dulce de leche and rolled in shredded coconut.",
                    ImageFile = "alfajor_de_maicena.jpg",
                    Price = 2.50M
                },
                new Product
                {
                    Name = "Chimichurri Sauce",
                    Category = "Condiments",
                    Summary = "Argentine herb sauce for grilling",
                    Description = "A tangy herb-based sauce made with parsley, garlic, oregano, and vinegar, traditionally served with grilled meats.",
                    ImageFile = "chimichurri.jpg",
                    Price = 5.00M
                },
                new Product
                {
                    Name = "Empanadas",
                    Category = "Snacks",
                    Summary = "Savory stuffed pastries",
                    Description = "Golden-brown pastry filled with various ingredients like beef, chicken, or cheese, commonly enjoyed as a snack or meal.",
                    ImageFile = "empanadas.jpg",
                    Price = 3.75M
                },
                new Product
                {
                    Name = "Malbec Wine",
                    Category = "Beverages",
                    Summary = "Premium Argentine wine",
                    Description = "A rich, full-bodied red wine made from Malbec grapes, one of Argentina's most famous exports.",
                    ImageFile = "malbec_wine.jpg",
                    Price = 15.00M
                }
            };
        }
    }
}
