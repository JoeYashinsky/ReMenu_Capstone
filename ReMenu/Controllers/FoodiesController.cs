using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReMenu.Interfaces;
using ReMenu.Models;

namespace ReMenu.Controllers
{
    public class FoodiesController : Controller
    {
        private readonly IInterfaceWrapper _repo;

        public FoodiesController(IInterfaceWrapper repo)
        {
            _repo = repo;
        }


        // GET: FoodiesController
        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);
            if (foodie == null)
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction("CreateRestaurant");
        }

        // GET: FoodiesController/Create
        public ActionResult Create()
        {
            return View(new Foodie());
        }

        // POST: FoodiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Foodie foodie)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                foodie.IdentityUserId = userId;
                _repo.Foodie.CreateFoodie(foodie);
                await _repo.SaveAsync();
                return RedirectToAction("CreateRestaurant");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: FoodiesController/Details/5
        public async Task<ActionResult> FoodieDetails(int id)
        {
            var foodie = await _repo.Foodie.GetFoodieAsync(id);
            return View(foodie);
        }

        // GET: FoodiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodiesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        // GET: FoodiesController/CreateRestaurant
        public ActionResult CreateRestaurant()
        {
            return View();
        }

        // POST: FoodiesController/CreateRestaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                _repo.Restaurant.Create(restaurant);
                await _repo.SaveAsync();
                return RedirectToAction("CreateMeal");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: FoodiesController/EditRestaurant/5
        public async Task<ActionResult> EditRestaurant(int restaurantId)
        {
            var editedRestaurant = await _repo.Restaurant.GetRestaurantAsync(restaurantId);
            return View(editedRestaurant);
        }

        // POST: FoodiesController/EditRestaurant/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRestaurant(Restaurant restaurant)
        {
            try
            {
                _repo.Restaurant.EditRestaurant(restaurant);
                await _repo.SaveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodiesController/RestaurantDetails/5
        public async Task<ActionResult> RestaurantDetails(int restaurantId)
        {
            var restaurantDetails = await _repo.Restaurant.GetRestaurantAsync(restaurantId);
            return View(restaurantDetails);
        }





        // GET: FoodiesController/CreateMeal
        public ActionResult CreateMeal()
        {
            ViewData["Categories"] = new List<string> { "Breakfast", "Fish", "Meat", "Pasta", "Pizza", "Salad", "Sandwich", "Soup", "Sushi" };
            ViewData["Ratings"] = new List<int> { 5, 4, 3, 2, 1 };
            return View();
        }

        // POST: FoodiesController/CreateMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMeal(Meal meal)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);

            try
            {
                meal.FoodieId = foodie.FoodieId;
                _repo.Meal.CreateMeal(meal);
                await _repo.SaveAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: FoodiessController/EditMeal/5
        public async Task<ActionResult> EditMeal(int mealId)
        {
            var editedMeal = await _repo.Meal.GetMealAsync(mealId);
            return View(editedMeal);
        }

        // POST: FoodiesController/EditMeal/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMeal(Meal meal)
        {
            try
            {
                _repo.Meal.EditMeal(meal);
                await _repo.SaveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodiesController/MealDetails/5
        public async Task<ActionResult> MealDetails(int mealId)
        {
            var mealDetails = await _repo.Meal.GetMealAsync(mealId);
            return View(mealDetails);
        }

        // GET: FoodiesController/DeleteMeal/5
        public async Task<ActionResult> DeleteMeal(int mealId)
        {
            var deletedMeal = _repo.Meal.GetMealAsync(mealId);
            await _repo.SaveAsync();
            return View(deletedMeal);
        }

        // POST: FoodiesController/DeleteMeal/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMeal(int id, Meal meal)
        {
            try
            {
                _repo.Meal.DeleteMeal(meal);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        /*public async Task<ActionResult> GetMeals()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);
            List<Meal> meals = await _repo.Meal.GetMealsAsync(foodie.FoodieId);
            return View();*/
        //}
    }
}
