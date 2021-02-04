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
        public async Task<List<Foodie>> GetAllFoodiesAsync() => await FindAll().ToListAsync();
        public async Task<Foodie> GetFoodieAsync(string userId) => await FindByCondition(f => f.IdentityUserId.Equals(userId)).FirstOrDefaultAsync();
        public async Task<Foodie> GetFoodieAsync(int foodieId) => await FindByCondition(f => f.FoodieId.Equals(foodieId)).FirstOrDefaultAsync();
        public void EditFoodie(Foodie foodie) => Update(foodie);
        public void DeleteFoodie(Foodie foodie) => Delete(foodie);

    }
}
