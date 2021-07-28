using _01_Komodo_Cafe_Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Kmodo_Cafe
{
    public class UI
    {
        MenuItemRepository menuItemRepository = new MenuItemRepository();

        public void Run()
        {
            SeedContent();
            bool continueRunningApplication = true;
            Console.WriteLine("Welcome to the Komodo Cafe Console Application. Please profide a selection for the what you would like to do:");
            while(continueRunningApplication)
            {
                DisplayMenu();
                int userResponse = GetUserResponseAsInt();
                PressAnyKeyToContinue();
            }
        }

        public void SeedContent()
        {
            List<ingredients> comboOneIngredients = new List<ingredients> { ingredients.Hamburger, ingredients.Bun, ingredients.Cheese, ingredients.Ketchup, ingredients.Mustard, ingredients.Onions, ingredients.Pickles, ingredients.Fries, ingredients.Drink };
            MenuItem comboOne = new MenuItem(1, "Combo Number One", "A delicious all American cheeseburger, topped with pickles, onion, ketchup and mustard. Fries are on the side along with a tasty beverage of your choice!", comboOneIngredients, 4.99m);

            List<ingredients> comboTwoIngredients = new List<ingredients> { ingredients.Hamburger, ingredients.Bun, ingredients.Cheese, ingredients.Ketchup, ingredients.Mustard, ingredients.Onions, ingredients.Pickles, ingredients.Lettuce, ingredients.Tomotato, ingredients.Fries, ingredients.Drink };
            MenuItem comboTwo = new MenuItem(2, "Combo Number Two", "A DELUXE all American cheeseburger, topped with pickles, onion, ketchup, mustard, lettuce, and tomato. Fries are on the side along with a tasty beverage of your choice!", comboTwoIngredients, 6.49m);

            List<ingredients> comboThreeIngredients = new List<ingredients> { ingredients.Hotdog, ingredients.Bun, ingredients.Onions, ingredients.Ketchup, ingredients.Mayonnaise, ingredients.Fries, ingredients.Drink };
            MenuItem comboThree = new MenuItem(3, "Combo Number Three", "An all beef, grilled to perfection hotdog on a buttered bun, topped with ketchup, mustard, and onions. Serverd with a side of fries and a drink.", comboThreeIngredients, 4.99m);

            List<ingredients> comboFourIngredients = new List<ingredients> { ingredients.ChickenPatty, ingredients.Bun, ingredients.Pickles, ingredients.Fries, ingredients.Drink };
            MenuItem comboFour = new MenuItem(4, "Combo Number Four", "The best fried chicken breast anywhere on the planet, topped with 3 perfect little pickle slices; served with a side of fries and a drink.", comboFourIngredients, 6.49m);

            List<ingredients> comboFiveIngredients = new List<ingredients> { ingredients.ChickenPatty, ingredients.Bun, ingredients.Pickles, ingredients.Lettuce, ingredients.Tomotato, ingredients.SecretSauce, ingredients.Fries, ingredients.Drink };
            MenuItem comboFive = new MenuItem(5, "Combo Number Five", "The best fried chicken breast anywhere on the planet but improved by the only thing that can make it better, our secret sauce! Oh yeah, and it comes with fries and a drink.", comboFiveIngredients, 7.49m);

            menuItemRepository.AddMenuItem(comboOne);
            menuItemRepository.AddMenuItem(comboTwo);
            menuItemRepository.AddMenuItem(comboThree);
            menuItemRepository.AddMenuItem(comboFour);
            menuItemRepository.AddMenuItem(comboFive);

        }
    
        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Main Menu: \n" +
                "1. View current menu \n" +
                "2. Add item to menu \n" +
                "3. Remove item from menu \n" +
                "4. Exit application");
        }

        public int GetUserResponseAsInt()
        {
            int responseToReturn = 0;
            bool validResponse = false;
            while (!validResponse)
            {
                validResponse = int.TryParse(Console.ReadLine(), out responseToReturn);
                if (validResponse)
                {
                    return responseToReturn;
                }
                else
                {
                    Console.WriteLine("Your response was not a valid, please input a valid integer for your selection.");
                }
            }
            return responseToReturn;
        }
    }
}
