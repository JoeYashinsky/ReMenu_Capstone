using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IFoodieRepository : IRepositoryBase<Foodie>
    {
        void CreateFoodie(Foodie foodie);
        List<Foodie> GetAllFoodies();
        Foodie GetFoodie(int foodieId);
        Foodie GetFoodie(string userId);

        void EditFoodie(Foodie foodie);
        void DeleteFoodie(Foodie foodie);
    }
}
