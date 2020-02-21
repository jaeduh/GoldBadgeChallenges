using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
        public void Run()
        {
           Seed();
           RunMenu();
        }
        private void RunMenu()
        {
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Greetings! How would you like to proceed?\n" +
                    "1. See All Claims\n" +
                    "2. Process Next Claim\n" +
                    "3. Enter New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();
                
                switch(userInput)
                {
                    case "1":
                        UserSeeAllClaims();
                        break;
                    case "2":
                        UserProcessNextClaim();
                        break;
                    case "3":
                        UserEnterNewClaim();
                        break;
                    case "4":
                        menuIsRunning = false;
                        break;
                }
            }
        }
       private void UserSeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> listOFClaims = _claimRepo.ListAllClaims();

            foreach(Claim content in listOFClaims)
            {
                Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                    $"Type of Claim: {content.TypeOfClaim}\n" +
                    $"Claim Descriptiom: {content.ClaimDescription}\n" +
                    $"Claim Amount: {content.ClaimDescription}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is Claim Valid: {content.DateOfClaim}");
            }
            Console.ReadKey();
            Console.ReadKey();

        }
        private void UserProcessNextClaim()
                                    //1. Peek to see next claim
                                    //3. Delete claim after work
        {
            
            Claim content = _claimRepo.ViewNextClaim();
            Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                    $"Type of Claim: {content.TypeOfClaim}\n" +
                    $"Claim Descriptiom: {content.ClaimDescription}\n" +
                    $"Claim Amount: {content.ClaimDescription}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is Claim Valid: {content.DateOfClaim}");

            Console.WriteLine("View next claim");

            _claimRepo.DeleteClaimFromList();

            Console.Clear();
            Console.WriteLine("Delete this claim");
        }
        private void UserEnterNewClaim() //2. Determine validity of claim
        {
            Claim content = new Claim();

            Console.WriteLine("Enter a three digit claim ID starting with '2'.");
            string claimIDString = Console.ReadLine();
            int claimNoId = int.Parse(claimIDString);
            content.ClaimID = claimNoId;

            Console.WriteLine("What is your claim type?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    content.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    content.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    content.TypeOfClaim = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Now, give a short description of your claim.");
            content.ClaimDescription = Console.ReadLine();

            Console.WriteLine("What is your claim amount?");
            string claimCostString = Console.ReadLine();
            decimal claimCostID = decimal.Parse(claimCostString);
            content.ClaimAmount = claimCostID;

            Console.WriteLine("When did the incident happen?");
            content.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("When was the claim filed?");
            content.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Based on the incident and claim dates, your claim is valid");
            bool claimIsValid = true;
            if (claimIsValid)
            {
                Console.WriteLine("Great, your claim is processed!");
            }
            else
            {
                Console.WriteLine("This claim has been denied.");
            }
           
        }

        public void Seed()
        {
            Claim contentOne = new Claim()
            {
                ClaimID = 220,
                TypeOfClaim = ClaimType.Car,
                ClaimDescription = "Snow storm caused car to slide into pole, causing body damage.",
                ClaimAmount = 1000,
                DateOfIncident = new DateTime(2020, 2, 1),
                DateOfClaim = DateTime.Now,
                ClaimIsValid = true
            };
        }
    }
}
