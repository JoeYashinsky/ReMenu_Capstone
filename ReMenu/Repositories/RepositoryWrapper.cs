using ReMenu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Repositories
{
    public class RepositoryWrapper : IInterfaceWrapper
    {
        private ApplicationDbContext _context;
        private IFoodieInterface _foodie;
        private IMealInterface _meal;
        private IRestaurantInterface restaurant;

        public IFoodieInterface Foodie
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



        public IMealInterface Meal
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



        public IRestaurantInterface Restaurant
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
    }
}
