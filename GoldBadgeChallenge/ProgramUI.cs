using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    public class ProgramUI //CRUD
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();
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
                Console.WriteLine("Hello, would you like to?:\n" +
                "1. add\n" +
                "2. delete\n" +
                "3. view all menu items?\n" +
                "4. exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        UserAddMealToMenu();
                        break;
                    case "2":
                        UserDeleteMealFromMenu();
                        break;
                    case "3":
                        UserListMeals();
                        break;
                    case "4":
                        menuIsRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }

        private void UserAddMealToMenu()
        {
            Meal content = new Meal();


            Console.WriteLine("Select an odd number higher than 5.");
            string mealNoString = Console.ReadLine();
            int mealNoID = int.Parse(mealNoString);
            content.MealNumber = mealNoID;

            Console.WriteLine("Now name your meal!");
            content.MealName = Console.ReadLine();

            Console.WriteLine("Add a description for your meal");
            content.Description = Console.ReadLine();

            Console.WriteLine("List the ingredients needed for your meal");
            string userInput = Console.ReadLine();
            List<string> result = userInput.Split(',').ToList();
            content.Ingredients = result;

            Console.WriteLine("Set a price for your meal.");
            string mealCostString = Console.ReadLine();
            decimal mealCostID = decimal.Parse(mealCostString);
            content.Price = mealCostID;


            _menuRepo.AddMealToMenu(content);
            Console.WriteLine("Your meal has been added to the menu.");
        }
        private void UserDeleteMealFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you would like to delete");
            string mealNumberInput = Console.ReadLine();
            int mealNoInput = int.Parse(mealNumberInput);
            _menuRepo.DeleteMealFromMenu(mealNoInput);
            Console.WriteLine($"{mealNumberInput} was deleted successfully.\n" +
                $"Press any key to return home..");
        }
        private void UserListMeals()
        {
            Console.Clear();
            List<Meal> menu = _menuRepo.GetAllMeals();

            foreach(Meal content in menu)
            {
                Console.WriteLine($"MealNumber: {content.MealNumber}\n" +
                    $"MealName: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price: {content.Price}");
            }
            Console.ReadKey();
            Console.ReadKey();
        }
        public void Seed()
        {
            Meal contentOne = new Meal()
            {
                MealNumber = 1,
                MealName = "Tenders Meal",
                Description = "4-piece Chicken Tenders with Medium Fry and Medium Drink",
                Ingredients = new List<string> { "fried chicken breast", "buttermilk breading", "natural cut fries" },
                Price = 5.99m

            };
            _menuRepo.AddMealToMenu(contentOne);

            Meal contentTwo = new Meal()
            {
                MealNumber = 3,
                MealName = "Double Cheese Meal",
                Description = "Double Cheeseburger with Medium Fry and Medium Drink",
                Ingredients = new List<string> { "USDA beef", "cheese", "ketchup", "tomato", "onion", "lettuce", "natural cut fries" },
                Price = 6.99m
            };
            _menuRepo.AddMealToMenu(contentTwo);

            Meal contentThree = new Meal()
            {
                MealNumber = 5,
                MealName = "Grilled Chicken Salad",
                Description = "Grilled Chicken Salad with Choice of Dressing and Meidum Drink",
                Ingredients = new List<string> { "Iceberg lettuce", "Spring mix", "shredded cheese", "tomato", "cucumber", "grilled chicken breast" },
                Price = 7.50m
            };
            _menuRepo.AddMealToMenu(contentThree);

        }
    }
}
