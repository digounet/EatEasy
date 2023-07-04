using EatEasy.Infra.Data.Context;
using EatEasy.Domain.Models;

namespace EatEasy.Infra.Data.Seed
{
    public static class SeedCategories
    {
        public const string LANCHE = "816d5d6d-c088-4602-b350-67c576d34397";
        public const string ACOMP = "488edb91-d0a5-4a2c-89fa-676c099445ae";
        public const string BEBIDA = "81ec0a7a-9f9f-4cf5-9e25-dc7c8838e454";
        public const string SOBREMESA = "ad028f14-dafb-4f3e-8a76-783d1ce0eb3b";

        public static void SeedCategoriesData(this EatEasyContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>()
            {
                new(Guid.Parse(LANCHE), "Lanche"),
                new(Guid.Parse(ACOMP), "Acompanhamento"),
                new(Guid.Parse(BEBIDA), "Bebida"),
                new(Guid.Parse(SOBREMESA), "Sobremesa")
            };

            context.AddRange(categories);
            context.SaveChanges();
        }
    }
}
