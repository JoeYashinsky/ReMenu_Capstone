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
    public class FoodieRepository : RepositoryBase<Foodie>, IFoodieRepository
    {
        public FoodieRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }

        public Foodie GetFoodie(string userId) => FindByCondition(f => f.IdentityUserId.Equals(userId)).SingleOrDefault();
        public Foodie GetFoodie(int foodieId) => FindByCondition(f => f.FoodieId.Equals(foodieId)).SingleOrDefault();
        public void CreateFoodie(Foodie foodie) => Create(foodie);
        public List<Foodie> GetAllFoodies() => FindAll().ToList();
        public void EditFoodie(Foodie foodie) => Update(foodie);
        public void DeleteFoodie(Foodie foodie) => Delete(foodie);

    }
}
