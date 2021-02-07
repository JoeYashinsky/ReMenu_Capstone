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
    public class FoodieRepository : BaseRepository<Foodie>, IFoodieInterface
    {
        private readonly object _repo;

        public FoodieRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }

        public void CreateFoodie(Foodie foodie) => Create(foodie);
        public List<Foodie> GetAllFoodies() => FindAll().ToList();
        public Foodie GetFoodie(string userId) => FindByCondition(f => f.IdentityUserId.Equals(userId)).FirstOrDefault();
        public Foodie GetFoodie(int foodieId) => FindByCondition(f => f.FoodieId.Equals(foodieId)).FirstOrDefault();
        public void EditFoodie(Foodie foodie) => Update(foodie);
        public void DeleteFoodie(Foodie foodie) => Delete(foodie);

    }
}
