using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterConsoleTables;
using _02_Komodo_Claims_ClassLibrary;
namespace _02_Komodo_Claims_Console
{
    class UI
    {
        private ClaimRepository claimRepo = new ClaimRespository();

        public void Run()
        {
            //Table table = new Table("one", "two", "three");
            //table.AddRow(1, 2, 3).AddRow("long line goes here", "short text", "word");

            //Console.Write(table.ToString());
            //Console.ReadKey();
            SeedContent();
            bool continueApplication = true;
            while (continueApplication)
            {
                PrintMainMenu();
                int userResponse = GetUserResponseAsInt();
                continueApplication = OutputChoiceAndContinue(userResponse);
                PressAnyKeyToContinue();
            }

            PrintMainMenu();
            Console.ReadLine();
        }
        public void SeedContent()
        {

        }
        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void PrintMainMenu()
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine("Choose a menu item\n" +
            "1. Sell all claims\n" +
            "2. Take care of next claim\n" +
            "3. Enter a new claim.\n" +
            "4. Exit the application.\n");
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
        public bool OutputChoiceAndContinue(int userChoice)
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            switch (userChoice)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Your selection was invalid. Please try again.");
                    return true;
            }
        }
    }
}
