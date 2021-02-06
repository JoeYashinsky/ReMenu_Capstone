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
        Task<Meal> GetMealAsync(int mealId);
        Task<Meal> GetMealAsync(string mealId);
        void EditMeal(Meal meal);
        void DeleteMeal(Meal meal);

        Task<List<Meal>> GetMealsAsync(int mealId);

    }
}
