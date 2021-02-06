using Microsoft.EntityFrameworkCore;
using ReMenu.Data;
using ReMenu.Interfaces;
using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Repositories
{
    public class MealRepository : BaseRepository<Meal>, IMealInterface
    {
        private readonly object _repo;

        public MealRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public void CreateMeal(Meal meal) => Create(meal);
        public void EditMeal(Meal meal) => Update(meal);
        public void DeleteMeal(Meal meal) => Delete(meal);
        public async Task<List<Meal>> GetMealsAsync(int foodieId) => await FindAll().ToListAsync();
        public async Task<Meal> GetMealAsync(int mealId) => await FindByCondition(m => m.MealId.Equals(mealId)).FirstOrDefaultAsync();
        public async Task<Meal> GetMealAsync(string mealId) => await FindByCondition(m => m.MealId.Equals(mealId)).FirstOrDefaultAsync();
    }
}
