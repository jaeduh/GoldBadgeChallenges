using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    public class MenuRepo // CRUD
    {
        protected readonly List<Meal> _mealDirectory = new List<Meal>();
        public bool AddMealToMenu(Meal content)
        {
            int directoryLength = _mealDirectory.Count();
            _mealDirectory.Add(content);
            bool wasAdded = directoryLength + 1 == _mealDirectory.Count();
            return wasAdded;
        }
        public bool DeleteMealFromMenu(int mealNumber)
        {
            Meal foundContent = GetMealByNumber(mealNumber);
            bool deletedResult = _mealDirectory.Remove(foundContent);
            return deletedResult;
        }
        public Meal GetMealByNumber(int mealNumber)
        {
            foreach(Meal content in _mealDirectory)
            {
                if(content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
        public List<Meal> GetAllMeals()
        {
            return  _mealDirectory;
        }
    }
}
