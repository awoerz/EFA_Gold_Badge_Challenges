using _01_Kmodo_Cafe;
using _01_Komodo_Cafe_Class_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace _01_Komodo_Cafe_Unit_Tests
{
    [TestClass]
    public class Kmodo_Cafe_Menu_Item_Repo_Tests
    {
        private MenuItem _menuItem;
        private MenuItemRepository _menuItemRepository;

        [TestInitialize]
        public void Arrange()
        {
            List<ingredients> burgerIngredients = new List<ingredients>();
            burgerIngredients.Add(ingredients.Hamburger);
            burgerIngredients.Add(ingredients.Cheese);
            burgerIngredients.Add(ingredients.Bun);
            _menuItem = new MenuItem(1, "Cheeseburger", "The all american beef patty with cheese. Add toppings of your choice!", burgerIngredients, 4.99m);

            _menuItemRepository = new MenuItemRepository();
            _menuItemRepository.AddMenuItem(_menuItem);
        }

        [TestMethod]
        public void RepositoryAddsMenuItems()
        {
            MenuItemRepository myMenu = new MenuItemRepository();
            Assert.IsTrue(myMenu.AddMenuItem(_menuItem));
        }

        [TestMethod]
        public void AccessMenuItemsByMenuItemNumber()
        {
            MenuItem myMenuItem = _menuItemRepository.GetMenuItemByNumber(1);
            Assert.AreEqual(_menuItem, myMenuItem);
        }

        [TestMethod]
        public void ConfirmMenuItemExistsWithNumber()
        {
            Assert.IsTrue(_menuItemRepository.MenuItemExistsWithNumber(1));
            Assert.IsFalse(_menuItemRepository.MenuItemExistsWithNumber(2));
        }

        [TestMethod]
        public void ConfirmMenuItemRemoved()
        {
            Assert.IsTrue(_menuItemRepository.RemoveMenuItem(1));
            Assert.IsFalse(_menuItemRepository.RemoveMenuItem(2));
        }

        [TestMethod]
        public void ConfirmMenuReturnedAsListOfMenuItems()
        {
            List<MenuItem> newListOfMenuItems = new List<MenuItem>();
            newListOfMenuItems.Add(_menuItem);

            MenuItemRepository newMenuItemRepo = new MenuItemRepository(newListOfMenuItems);

            CollectionAssert.AreEqual(newListOfMenuItems, newMenuItemRepo.GetMenu());
        }
    }

    [TestClass]
    public class Komodo_Cafe_Menu_Item_Tests
    {
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            List<ingredients> burgerIngredients = new List<ingredients>();
            burgerIngredients.Add(ingredients.Hamburger);
            burgerIngredients.Add(ingredients.Cheese);
            burgerIngredients.Add(ingredients.Bun);
            _menuItem = new MenuItem(1, "Cheeseburger", "The all american beef patty with cheese. Add toppings of your choice!", burgerIngredients, 4.99m);
        }

        [TestMethod]
        public void GetIngredientsAsStringFormatedCorrectly()
        {
            string burgerIngredientsString = "Hamburger, Cheese, Bun";

            Assert.AreEqual(burgerIngredientsString, _menuItem.GetIngredientsAsString());
        }
    }

    [TestClass]
    public class Komod_Cafe_UI_Tests
    {
        UI testUi = new UI();

        [TestMethod]
        public void ConfirmIntResponseAsInt()
        {
            StringReader input = new StringReader("1");
            Console.SetIn(input);
            int actual = testUi.GetUserResponseAsInt();
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void ConfirmAskAgainWhenIntInputIsBad()
        {
            //Arrange
            StringReader input = new StringReader("invalid \n 1");
            StringWriter output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);
            //Act
            testUi.GetUserResponseAsInt();
            //Assert
            Assert.IsTrue(output.ToString().Contains("Your response was not valid, please input a valid integer for your selection."));
        }
        [TestMethod]
        public void ConfirmDecimalResponseAsDecimal()
        {
            //Arange
            StringReader input = new StringReader("1.1");
            Console.SetIn(input);
            //Act
            decimal actual = testUi.GetUserResponseAsDecimal();
            //Assert
            Assert.AreEqual(1.1m, actual);
        }
        [TestMethod]
        public void ConfirmAskAgainWhenDecimalInputIsBad()
        {
            //Arrange
            StringReader input = new StringReader("invalid \n 1.1");
            StringWriter output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);
            //Act
            testUi.GetUserResponseAsDecimal();
            //Assert
            Assert.IsTrue(output.ToString().Contains("Your response was not valid, please input a valid integer for your selection."));
        }
        [TestMethod]
        public void CoinfirmOutputChoiceReturnsCorrectly()
        {
            //Arrange
            StringReader input = new StringReader("1 \n N \n D \n 1 \n n \n key \n 1.1 \n 1");
            Console.SetIn(input);
            //Act & Assert
            Assert.IsTrue(testUi.OutputChoiceAndContinue(1));
            Assert.IsTrue(testUi.OutputChoiceAndContinue(2));
            Assert.IsTrue(testUi.OutputChoiceAndContinue(3));
            Assert.IsTrue(testUi.OutputChoiceAndContinue(5));
            Assert.IsFalse(testUi.OutputChoiceAndContinue(4));
        }
    }
}
