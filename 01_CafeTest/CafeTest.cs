using System;
using System.Collections.Generic;
using GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeTest
    {
        private readonly MenuRepo _repo = new MenuRepo();

        [TestInitialize]
        public void Arrange()
        {

            Meal contentOne = new Meal()
            {
                MealNumber = 1,
                MealName = "Tenders Meal",
                Description = "4-piece Chicken Tenders with Medium Fry and Medium Drink",
                Ingredients = new List<string> { "fried chicken breast", "buttermilk breading", "natural cut fries" },
                Price = 5.99m

            };
            _repo.AddMealToMenu(contentOne);


            Meal contentTwo = new Meal()
            {
                MealNumber = 3,
                MealName = "Double Cheese Meal",
                Description = "Double Cheeseburger with Medium Fry and Medium Drink",
                Ingredients = new List<string> { "USDA beef", "cheese", "ketchup", "tomato", "onion", "lettuce", "natural cut fries" },
                Price = 6.99m
            };
            _repo.AddMealToMenu(contentTwo);
        }
        [TestMethod]
        public void AddMealToMenu_ShouldGetCorrectBoolean()
        {
            Meal content = new Meal();
            bool addResult = _repo.AddMealToMenu(content);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void DeleteMealFromMenu_ShouldReturnTrue()
        {
            bool removeResult = _repo.DeleteMealFromMenu(1);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
        public void GetMealByNumber_ShouldReturnCorrectContent()
        {
            Meal searchResult = _repo.GetMealByNumber(1);
            Assert.AreEqual("Tenders Meal", searchResult.MealName);
        }
        [TestMethod]
        public void GetAllMeals_ShouldListAllMeals()
        {
           List<Meal> MenuRepo = _repo.GetAllMeals();
            Assert.AreEqual(MenuRepo.Count, 2);
        }
    }
}
