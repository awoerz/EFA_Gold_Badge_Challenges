using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komodo_Cafe_Class_Library
{
    public class MenuItemRepository
    {
        private List<MenuItem> _Menu;

        public MenuItemRepository() 
        {
            _Menu = new List<MenuItem>();
        }

        public MenuItemRepository(List<MenuItem> menu)
        {
            _Menu = menu;
        }

        public bool AddMenuItem(MenuItem newItem)
        {
            _Menu.Add(newItem);
            return true;
        }

        public bool RemoveMenuItem(int menuItemNumber)
        {
            if(GetMenuItemByNumber(menuItemNumber) != null)
            {
                _Menu.Remove(GetMenuItemByNumber(menuItemNumber));
                return true;
            }
            return false;
        }

        public List<MenuItem> GetMenu()
        {
            return _Menu;
        }

        public bool MenuItemExistsWithNumber(int menuItemNumber)
        {
            foreach(MenuItem menuItem in _Menu)
            {
                if(menuItem.Number == menuItemNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public MenuItem GetMenuItemByNumber(int menuItemNumber)
        {
            if (MenuItemExistsWithNumber(menuItemNumber))
            {
                foreach(MenuItem menuItem in _Menu)
                {
                    if(menuItem.Number == menuItemNumber)
                    {
                        return menuItem;
                    }
                }
            }
            return null;
        }
    }

}
