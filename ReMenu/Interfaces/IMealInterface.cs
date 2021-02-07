using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IMealInterface : IInterfaceBase<Meal>
    {
        void CreateMeal(Meal meal);
        Meal GetMeal(int mealId);
        Meal GetMeal(string mealId);
        void EditMeal(Meal meal);
        void DeleteMeal(Meal meal);

        List<Meal> GetMeals(int mealId);

    }
}
