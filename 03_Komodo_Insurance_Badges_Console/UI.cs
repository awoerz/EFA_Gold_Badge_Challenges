using _03_Komodo_Insurance_Badges_Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterConsoleTables;


namespace _03_Komodo_Insurance_Badges_Console
{
    public class UI
    {
        private BadgeRepository _BadgeRepo = new BadgeRepository();
        private bool ContinueApplication = true;
        public void Run()
        {
            SeedContent();
            while (ContinueApplication)
            {
                if (!Console.IsOutputRedirected) Console.Clear();
                PrintMainMenu();
                ContinueApplication = EvaluateMainMenuUserInput(GetUserResponseAsInt());
            }
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine("Thank you for using the application.");
            Console.ReadKey();
        }

        public void SeedContent()
        {
            Badge newBadgeOne = new Badge(13546, new List<string>() { "A1" , "A2"});
            Badge newBadgeTwo = new Badge(24357, new List<string>() { "A1", "A2", "B1" });
            _BadgeRepo.AddBadge(newBadgeOne);
            _BadgeRepo.AddBadge(newBadgeTwo);
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
                    UpdateBadge();
                    return true;
                case 3:
                    ListAllBadges();
                    Console.ReadLine();
                    return true;
                case 4:
                    return false;
                default:
                    Console.WriteLine("User response was invalid. Please try again.");
                    return true;
            }
        }  
        public void AddBadge()
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            Badge newBadge = new Badge();
            Console.Write("What is the number on the badge: ");
            newBadge.BadgeID = GetUserResponseAsInt();
            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("List a door that it needs access to: ");
                newBadge.Doors.Add(Console.ReadLine());
                Console.WriteLine("Any other doors(y/n)? ");
                string userChoice = Console.ReadLine().ToUpper();
                if(userChoice != "Y")
                {
                    addingDoors = false;
                }
            }
            _BadgeRepo.AddBadge(newBadge);
        }
        public void UpdateBadge()
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine("Please provide the badge number of the badge that you would like to update.");
            ListAllBadges();
            int selectedId = GetUserResponseAsInt();
            if (_BadgeRepo.GetBadgeDictionary().ContainsKey(selectedId))
            {
                Badge userSelectedBadge =_BadgeRepo.GetBadgeByID(selectedId);
                Console.WriteLine($"Badge {userSelectedBadge.BadgeID} has access to doors: {PrintDoorList(userSelectedBadge.Doors)}");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove a door\n" +
                    "2. Add a door\n");
                int response = GetUserResponseAsInt();
                switch (response)
                {
                    case 1:
                        if (userSelectedBadge.Doors.Count != 0)
                        {
                            Console.WriteLine("Which door would you like to remove?");
                            string userReply = Console.ReadLine();
                            if (userSelectedBadge.Doors.Contains(userReply))
                            {
                                userSelectedBadge.Doors.Remove(userReply);
                            }
                            else
                            {
                                Console.WriteLine("That door is not in the list.");
                            }
                        } 
                        else
                        {
                            Console.WriteLine("There are no doors to remove from this badge.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please provide door number: ");
                        userSelectedBadge.Doors.Add(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Your choice was invalid.");
                        break;
                }

            }
            else
            {
                Console.WriteLine("A badge with that number is not in the repository.\n" +
                    "Press any key to return to the main menu.");
                Console.ReadKey();
            }
        }
        public void ListAllBadges()
        {
            Table table = new Table("Badge#", "Door Access");
            foreach(var badge in _BadgeRepo.GetBadgeDictionary())
            {
                table.AddRow(badge.Key, PrintDoorList(badge.Value));
            }
            Console.WriteLine(table.ToString());
        }
        public string PrintDoorList(List<String> listToPrint)
        {
            string returnString = "";
            foreach(var item in listToPrint)
            {
                if(item == listToPrint.Last())
                {
                    returnString += item;
                }
                else
                {
                    returnString += $"{item}, ";
                }
            }
            return returnString;
        }
    }
}
