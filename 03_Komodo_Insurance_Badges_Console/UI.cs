using _03_Komodo_Insurance_Badges_Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_Komodo_Insurance_Badges_Console
{
    public class UI
    {
        private BadgeRepository _BadgeRepo = new BadgeRepository();
        private bool ContinueApplication = true;
        public void Run()
        {
            while (ContinueApplication)
            {
                if (!Console.IsOutputRedirected) Console.Clear();
                PrintMainMenu();
                ContinueApplication = EvaluateMainMenuUserInput(GetUserResponseAsInt());
                Console.ReadLine();
            }
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine("Thank you for using the application.");
            Console.ReadKey();
        }
        public void PrintMainMenu()
        {
            Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                "1. Add a badge\n" +
                "2. Edit a badge.\n" +
                "3. List all badges.\n" +
                "4. Exit Application");
        }
        public int GetUserResponseAsInt()
        {
            int responseToReturn = 0;
            bool validResponse = false;
            Console.WriteLine("");
            while (!validResponse)
            {
                validResponse = int.TryParse(Console.ReadLine(), out responseToReturn);
                if (validResponse)
                {
                    return responseToReturn;
                }
                else
                {
                    Console.WriteLine("Your response was not valid, please input a valid integer for your selection.");
                }
            }
            return responseToReturn;
        }
        public bool EvaluateMainMenuUserInput(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    AddBadge();
                    return true;
                case 2:
                    Console.WriteLine("Option 2.");
                    return true;
                case 3:
                    Console.WriteLine("Option 3.");
                    return true;
                case 4:
                    Console.WriteLine("Option 4.");
                    return false;
                default:
                    Console.WriteLine("User response was invalid. Please try again.");
                    return true;
            }
        }  
        public void AddBadge()
        {
            Badge newBadge = new Badge();
            Console.Write("What is the number on the badge: ");
            newBadge.BadgeID = GetUserResponseAsInt();
            Console.WriteLine();
            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("List a door that it needs access to: ");
                newBadge.Doors.Add(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Any other doors(y/n)? ");
                string userChoice = Console.ReadLine().ToUpper();
                if(userChoice != "Y")
                {
                    addingDoors = false;
                }
            }
            _BadgeRepo.AddBadge(newBadge);
        }
    }
}
