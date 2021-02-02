using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IFoodieInterface : IInterfaceBase<Foodie>
    {
        void CreateFoodie(Foodie foodie);
        Task<List<Foodie>> GetAllFoodiesAsync();
        Task<Foodie> GetFoodieAsync(int foodieId);
        Task<Foodie> GetFoodieAsync(string userId);

        void EditFoodie(Foodie foodie);
        void DeleteFoodie(Foodie foodie);
    }
}
