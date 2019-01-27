namespace LoadingHw
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RecipeContext : DbContext
    {
        public RecipeContext() : base("name=RecipeContext") { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}