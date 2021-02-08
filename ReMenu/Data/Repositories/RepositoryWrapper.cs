using ReMenu.Data;
using ReMenu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IFoodieRepository _foodie;
        private IMealRepository _meal;
        private IRestaurantRepository _restaurant;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IFoodieRepository Foodie
        {
            get
            {
                if(_foodie == null)
                {
                    _foodie = new FoodieRepository(_context);
                }
                return _foodie;
            }
        }

        public IMealRepository Meal
        {
            get
            {
                if(_meal == null)
                {
                    _meal = new MealRepository(_context);
                }
                return _meal;
            }
        }

        public IRestaurantRepository Restaurant
        {
            get
            {
                if(_restaurant == null)
                {
                    _restaurant = new RestaurantRepository(_context);
                }
                return _restaurant;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
