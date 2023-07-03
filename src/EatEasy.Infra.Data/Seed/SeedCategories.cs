using EatEasy.Infra.Data.Context;
using EatEasy.Domain.Models;

namespace EatEasy.Infra.Data.Seed
{
    public static class SeedCategories
    {
        public static void SeedCategoriesData(this EatEasyContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>()
            {
                new(Guid.NewGuid(), "Lanche"),
                new(Guid.NewGuid(), "Acompanhamento"),
                new(Guid.NewGuid(), "Bebida"),
                new(Guid.NewGuid(), "Sobremesa")
            };

            context.AddRange(categories);
            context.SaveChanges();
        }
    }
}
