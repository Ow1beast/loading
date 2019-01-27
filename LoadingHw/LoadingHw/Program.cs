using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingHw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> Recipes = new List<Recipe>();
            List<Ingredient> Ingredients = new List<Ingredient>();

            using (RecipeContext context = new RecipeContext())
            {
                Console.WriteLine("1. Создать новый рецепт");
                Console.WriteLine("2. Получить список рецептов");

                var key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        Console.WriteLine("Введите название рецепта");
                        Recipe recipe = new Recipe { Name = Console.ReadLine() };

                        Console.WriteLine("Количество ингридиентов: ");
                        int amount;
                        Int32.TryParse(Console.ReadLine(), out amount);

                        for (int i = 0; i < amount; i++)
                        {
                            Console.WriteLine($"Название {i+1} ингридиента: ");
                            Ingredient ingredient = new Ingredient
                            {
                                Name = Console.ReadLine()
                            };
                            recipe.Ingredients.Add(ingredient);
                            context.Ingredients.Add(ingredient);
                        }
                        context.Recipes.Add(recipe);
                        context.SaveChanges();
                        break;
                    case "2":
                        Recipes = context.Recipes.ToList();

                        Console.Clear();

                        for (int i = 0; i < Recipes.Count; i++)
                        {
                            Ingredients = Recipes[i].Ingredients.ToList();

                            Console.WriteLine("Рецепт: \n" + Recipes[i].Name + "\nИнгридиенты: ");

                            for (int k = 0; k < Ingredients.Count; k++)
                            {
                                Console.WriteLine(Ingredients[k].Name);
                            }
                        }
                        break;
                }
            }
                        Console.ReadLine();
        }
    }
}
