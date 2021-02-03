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
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantInterface
    {
        private readonly object repo;

        public RestaurantRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
        public void EditRestaurant(Restaurant restaurant) => Update(restaurant);
        public void DeleteRestaurant(Restaurant restaurant) => Delete(restaurant);
        public async Task<List<Restaurant>> GetRestaurantsAsync() => await FindAll().ToListAsync();
        public async Task<Restaurant> GetRestaurantAsync(int restaurantId) => await FindByCondition(r => r.RestaurantId.Equals(restaurantId)).FirstOrDefaultAsync();
    }
}
