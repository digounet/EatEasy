using EatEasy.Infra.Data.Context;
using EatEasy.Domain.Models;

namespace EatEasy.Infra.Data.Seed
{
    public static class SeedProducts
    {
        public static void SeedProductsData(this EatEasyContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new(Guid.NewGuid(), "Hamburgher",
                    "Suculento hamburger grelhado, queijo derretido, molho especial e acompanhamentos frescos, uma explosão de sabores!",
                    Guid.Parse(SeedCategories.LANCHE), 22.00),
                new(Guid.NewGuid(), "Cheesburgher",
                    "Saboroso cheeseburger com carne suculenta, queijo derretido e acompanhamentos irresistíveis!",
                    Guid.Parse(SeedCategories.LANCHE), 24.00),
                new(Guid.NewGuid(), "Batata frita",
                    "Batatas fritas crocantes e irresistíveis: um sabor estalante que vai te conquistar!",
                    Guid.Parse(SeedCategories.ACOMP), 10.00),
                new(Guid.NewGuid(), "Onion rings",
                    "Onion rings crocantes e deliciosas, um petisco irresistível.", Guid.Parse(SeedCategories.ACOMP),
                    10.00),
                new(Guid.NewGuid(), "Refrigerante",
                    "Refresque-se com o sabor gelado deste incrível refrigerante!", Guid.Parse(SeedCategories.BEBIDA),
                    4.50),
                new(Guid.NewGuid(), "Suco",
                    "Suco natural, rico em vitaminas e refrescante, perfeito para uma vida saudável.",
                    Guid.Parse(SeedCategories.BEBIDA), 5.00),
                new(Guid.NewGuid(), "Sorvete",
                    "Sorvete cremoso e refrescante, uma delícia gelada que derrete na boca.",
                    Guid.Parse(SeedCategories.SOBREMESA), 2.50)
            };

            context.AddRange(products);
            context.SaveChanges();
        }
    }
}
