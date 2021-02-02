using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IRestaurantInterface : IInterfaceBase<Restaurant>
    {
        void CreateRestaurant(Restaurant restaurant);
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantAsync(string restaurantId);
        Task<Restaurant> GetRestaurantAsync(int restaurantId);
        void EditRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
    }
}
