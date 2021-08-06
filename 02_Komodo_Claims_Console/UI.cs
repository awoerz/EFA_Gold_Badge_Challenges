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
        private ClaimRepository _ClaimRepo = new ClaimRepository();
        public void Run()
        {
            SeedContent();
            bool continueApplication = true;
            while (continueApplication)
            {
                PrintMainMenu();
                int userResponse = GetUserResponseAsInt();
                continueApplication = OutputChoiceAndContinue(userResponse);
                PressAnyKeyToContinue();
            }
        }
        public void SeedContent()
        {
            Claim firstClaim = new Claim(1, ClaimTypes.Auto, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim secondClaim = new Claim(2, ClaimTypes.Home, "House fire in kitchen", 40000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim thridClaim = new Claim(3, ClaimTypes.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _ClaimRepo.AddClaimToRepo(firstClaim);
            _ClaimRepo.AddClaimToRepo(secondClaim);
            _ClaimRepo.AddClaimToRepo(thridClaim);
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
        public decimal GetUserRepsonseAsDecimal()
        {
            decimal responseToReturn = 0;
            bool validResponse = false;
            while (!validResponse)
            {
                validResponse = decimal.TryParse(Console.ReadLine(), out responseToReturn);
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
        public DateTime GetUsersDate()
        {
            Console.WriteLine("Please provide a year as a four digit number");
            int year = GetUserResponseAsInt();
            Console.WriteLine("Please provide the month as a 1 or 2 digit number");
            int month = GetUserResponseAsInt();
            Console.WriteLine("Please provide the day as a 1 or 2 digit number");
            int day = GetUserResponseAsInt();
            return new DateTime(year, month, day);
        }
        public bool OutputChoiceAndContinue(int userChoice)
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            switch (userChoice)
            {
                case 1:
                    SeeAllClaims();
                    return true;
                case 2:
                    TakeCareOfQueue();
                    return true;
                case 3:
                    CreateNewClaim();
                    return true;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Your selection was invalid. Please try again.");
                    return true;
            }
        }
        public void SeeAllClaims()
        {
            Table table = new Table("ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            foreach (Claim claim in _ClaimRepo.Repository)
            {
                table.AddRow(claim.ClaimID, claim.ClaimType, claim.Description, "$" + claim.ClaimAmount, claim.DateOfIncident.Date.ToString("d"), claim.DateOfClaim.Date.ToString("d"), claim.IsValid);
            }

            Console.WriteLine(table.ToString());
        }
        public void TakeCareOfQueue()
        {
            //Create Queue
            Queue<Claim> claimQueue = new Queue<Claim>();
            foreach(Claim claim in _ClaimRepo.Repository)
            {
                claimQueue.Enqueue(claim);
            }
            //Ouput next Item in Queue
            bool DealWithQueue = true;
            while(DealWithQueue)
            {
                if (!Console.IsOutputRedirected) Console.Clear();
                if(claimQueue.Count == 0)
                {
                    Console.WriteLine("There are no more items in the queue.");
                    DealWithQueue = false;
                }
                else
                {
                    Console.WriteLine("Here are the details of the next claim to be handled:");
                    Claim currentClaim = claimQueue.Dequeue();
                    Console.WriteLine($"ClaimID: {currentClaim.ClaimID}\n" +
                        $"Type: {currentClaim.ClaimType}\n" +
                        $"Description: {currentClaim.Description}\n" +
                        $"Amount: {currentClaim.ClaimAmount}\n" +
                        $"DateOfAccident: {currentClaim.DateOfIncident.Date.ToString("d")}\n" +
                        $"DateOfClaim: {currentClaim.DateOfClaim.Date.ToString("d")}\n" +
                        $"IsValid: {currentClaim.IsValid}");
                    Console.WriteLine("Do you want to deal with this claim now? (y/n)");
                    string userResponse = Console.ReadLine();
                    if (userResponse.ToUpper() != "Y")
                    {
                        DealWithQueue = false;
                    }
                }
            }
        }
        public void CreateNewClaim()
        {
            Claim newClaim = new Claim();
            Console.Write("Enter the claim id: ");
            newClaim.ClaimID = GetUserResponseAsInt();
            Console.Write("Etner the claim type. (defaults to auto)\n" +
                "1. Auto\n" +
                "2. Home\n" +
                "3. Theft\n");
            int userChoice = GetUserResponseAsInt();
            switch (userChoice)
            {
                case 1:
                    newClaim.ClaimType = ClaimTypes.Auto;
                    break;
                case 2:
                    newClaim.ClaimType = ClaimTypes.Home;
                    break;
                case 3:
                    newClaim.ClaimType = ClaimTypes.Theft;
                    break;
                default:
                    newClaim.ClaimType = ClaimTypes.Auto;
                    break;
            }
            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();
            Console.Write("Amount of Damage:");
            newClaim.ClaimAmount = GetUserRepsonseAsDecimal();
            Console.WriteLine("Date of Accident:");
            newClaim.DateOfIncident = GetUsersDate();
            Console.WriteLine("Date of Claim: ");
            newClaim.DateOfClaim = GetUsersDate();
            Console.WriteLine("Claim is valid");
            _ClaimRepo.AddClaimToRepo(newClaim);
            Console.WriteLine("Claim has been added.");
        }
    }
}
