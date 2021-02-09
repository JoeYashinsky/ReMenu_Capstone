using ReMenu.Interfaces;
using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Contracts
{
    interface IMealImageRepository : IRepositoryBase<MealImage>
    {
        void CreateMealImage(MealImage mealImage);
        MealImage GetMealImage(int mealImageId);
        MealImage GetMealImage(string mealImageId);
        void EditMealImage(MealImage mealImage);
        void DeleteMealImage(MealImage mealImage);
        List<MealImage> GetMealImages(int mealImageId);
    }