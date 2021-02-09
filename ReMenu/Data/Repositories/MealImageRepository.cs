using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Data.Repositories
{
    public class MealImageRepository : RepositoryBase<MealImage>, IMealImageRepository
    {
        public MealImageRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            public void CreateMealImage(MealImage mealImage) => Create(mealImage);
            public void EditMealImage(MealImage mealImage) => Update(mealImage);
            public void DeleteMealImage(MealImage mealImage) => Delete(mealImage);
            public List<MealImage> GetMealImages(int foodieId) => FindAll().ToList();
            public MealImage GetMealImage(int mealImageId) => FindByCondition(m => m.MealImageId.Equals(mealImageId)).FirstOrDefault();
            public MealImage GetMealImage(string mealImageId) => FindByCondition(m => m.MealImageId.Equals(mealImageId)).FirstOrDefault();
        }
    }
}