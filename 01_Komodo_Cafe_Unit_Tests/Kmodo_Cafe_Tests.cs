using _01_Komodo_Cafe_Class_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Komodo_Cafe_Unit_Tests
{
    [TestClass]
    public class Kmodo_Cafe_Tests
    {
        private MenuItem _menuItem;
        private MenuItemRepository _menuItemRepository;

        [TestInitialize]
        public void Arrange()
        {
            List<ingredients> burgerIngredients = new List<ingredients>();
            burgerIngredients.Add(ingredients.Beef);
            burgerIngredients.Add(ingredients.Cheese);
            burgerIngredients.Add(ingredients.Bread);
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
}
