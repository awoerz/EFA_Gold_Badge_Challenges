using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komodo_Cafe_Class_Library
{
    public enum ingredients
    {
        Hamburger,
        Hotdog,
        ChickenPatty,
        Bun,
        Cheese,
        Lettuce,
        Tomotato,
        Pickles,
        Onions,
        Ketchup,
        Mustard,
        Mayonnaise,
        SecretSauce,
        Fries,
        Drink
    }

    public class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ingredients> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {
            Ingredients = new List<ingredients>();
        }

        public MenuItem(int mealNumber, string mealName, string mealDescription, List<ingredients> ingredients, decimal price)
        {
            Number = mealNumber;
            Name = mealName;
            Description = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }

        public string GetIngredientsAsString()
        {
            string outputString = "";
            foreach (ingredients ing in Ingredients)
            {
                if (ing == Ingredients.Last())
                {
                    outputString += $"{ing}";
                }
                else
                {
                    outputString += $"{ing}, ";
                }
            }
            return outputString;
        }
    }
}
