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
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        private readonly object _repo;

        public RestaurantRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
        public void EditRestaurant(Restaurant restaurant) => Update(restaurant);
        public void DeleteRestaurant(Restaurant restaurant) => Delete(restaurant);
        public List<Restaurant> GetRestaurants() => FindAll().ToList();
        public Restaurant GetRestaurant(int restaurantId) => FindByCondition(r => r.RestaurantId.Equals(restaurantId)).FirstOrDefault();
    }
}
