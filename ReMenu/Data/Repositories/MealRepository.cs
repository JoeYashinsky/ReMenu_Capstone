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
        public List<Meal> GetMeals(int foodieId) => FindAll().ToList();
        public Meal GetMeal(int mealId) => FindByCondition(m => m.MealId.Equals(mealId)).FirstOrDefault();
        public Meal GetMeal(string mealId) => FindByCondition(m => m.MealId.Equals(mealId)).FirstOrDefault();
    }
}
