using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    class ProgramUI
    {
        private readonly BadgesRepo _badgesRepo = new BadgesRepo();
        static void Main(string[] args)
        {
            ProgramUI i = new ProgramUI();
            //ui.Run();
        }

        public void Run()
        {
            //Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello, would you like to ?:\n" +
                "1. Create a badge\n" +
                "2. Add a door?\n" +
                "3. Remove a door?\n" +
                "4. Show all badges\n" +
                "5. exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        UserCreateBadge();
                        break;
                    case "2":
                        UserAddDoor();
                        break;
                    case "3":
                        UserRemoveDoor();
                        break;
                    case "4":
                        UserSeeAllBadges();
                    case "5":
                        menuIsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UserCreateBadge()
        {
            Badge content = new Badge();

            Console.WriteLine("Select a number in the '200s' higher than 201.");
            string badgeIDstring = Console.ReadLine();
            int badgeIDNo = int.Parse(badgeIDstring);
            content.BadgeID = badgeIDNo;

            Console.WriteLine("Now name your Door!");
            string userInput = Console.ReadLine();
            content.DoorName.Add(userInput);

            _badgesRepo.CreateNewBadge(content);
            Console.WriteLine("Your badge has been added!");


        }
        private void UserAddDoor()
        {
            Badge content = new Badge();
            Console.WriteLine("Add an additional door to your badge");
            string userInput = Console.ReadLine();
            content.DoorName.Add(userInput);
            Console.WriteLine("Your door has been added.");
        }

        private void UserRemoveDoor()
        {
            Badge content = new Badge();
            Console.WriteLine("Remove door from your badge");
            string userInput = Console.ReadLine();
            content.DoorName.Remove(userInput);
            Console.WriteLine("Your door has been Removed.");

        }

        private void UserSeeAllBadges()
        {
            Dictionary<int, List<string>> badges = _badgesRepo.DisplayAllBadges();
        }
    }
}
