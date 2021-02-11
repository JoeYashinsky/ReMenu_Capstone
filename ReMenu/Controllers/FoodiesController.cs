using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReMenu.Interfaces;
using ReMenu.Models;
using Microsoft.AspNetCore.Hosting;
using ReMenu.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReMenu.ViewModels;

namespace ReMenu.Controllers
{
    public class FoodiesController : Controller
    {
        private readonly IRepositoryWrapper _repo;        
        private readonly IWebHostEnvironment webHostEnvironment;

        public FoodiesController(IRepositoryWrapper repo, IWebHostEnvironment hostingEnvironment)
        {
            _repo = repo;
            webHostEnvironment = hostingEnvironment;
        }

        // GET: FoodiesController
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var foodie = await _repo.Foodie.GetFoodieAsync(userId);
            //var foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var foodie = _repo.Foodie.GetFoodie(userId);
            //var meals = _repo.Meal.GetMealsAsync(foodie.FoodieId);
            if (foodie == null)
            {
                return RedirectToAction("Create");
            }
            //var myMeals = _repo.Meal.GetMealsAsync();

            return View("CreateFood");
        }

        // GET: FoodiesController/Create
        public ActionResult Create()
        {
            return View(new Foodie());
        }

        // POST: FoodiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Foodie foodie)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie newFoodie = new Foodie();
            newFoodie.IdentityUserId = userId;
            newFoodie.FirstName = foodie.FirstName;
            newFoodie.LastName = foodie.LastName;

            //_context.Add(newFoodie);
            //await _context.SaveChangesAsync();

            _repo.Foodie.CreateFoodie(newFoodie);
            _repo.Save();
            return RedirectToAction(nameof(CreateFood));
        }

        // GET: FoodiesController/Details/5
        public ActionResult FoodieDetails(int id)
        {
            var foodie = _repo.Foodie.GetFoodie(id);

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
            ViewData["allStates"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View();
        }

        // POST: FoodiesController/CreateRestaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant([Bind("RestaurantId, Name, StreetAddress, City, State, ZipCode")] Restaurant restaurant)
        {
            try
            {
                Restaurant newRestaurant = new Restaurant();
                newRestaurant.Name = restaurant.Name;
                newRestaurant.StreetAddress = restaurant.StreetAddress;
                newRestaurant.City = restaurant.City;
                newRestaurant.State = restaurant.State;
                newRestaurant.ZipCode = restaurant.ZipCode;
                //newRestaurant.RestaurantId = restaurant.RestaurantId;
                //_context.Add(newRestaurant);
                //await _context.SaveChangesAsync();

                _repo.Restaurant.Create(restaurant);
                _repo.Save();
                return RedirectToAction("CreateFood", new {id = newRestaurant.RestaurantId });
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: FoodiesController/EditRestaurant/5
        public ActionResult EditRestaurant(int restaurantId)
        {
            var editedRestaurant = _repo.Restaurant.GetRestaurant(restaurantId);
            return View(editedRestaurant);
        }

        // POST: FoodiesController/EditRestaurant/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(Restaurant restaurant)
        {
            try
            {
                _repo.Restaurant.EditRestaurant(restaurant);
                _repo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodiesController/RestaurantDetails/5
        public ActionResult RestaurantDetails(int restaurantId)
        {
            var restaurantDetails = _repo.Restaurant.GetRestaurant(restaurantId);
            return View(restaurantDetails);
        }





        /*// GET: FoodiesController/CreateMeal
        public ActionResult CreateMeal()
        {
            ViewData["Categories"] = new List<string> { "Breakfast", "Fish", "Meat", "Pasta", "Pizza", "Salad", "Sandwich", "Soup", "Sushi", "Vegetarian" };
            ViewData["Ratings"] = new List<int> { 5, 4, 3, 2, 1 };
            ViewData["FoodieId"] = new SelectList(_context.Foodies, "FoodieId", "FoodieId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");

            return View();
        }*/

        public ActionResult CreateFood()
        {
            ViewData["allStates"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            ViewData["Categories"] = new List<string> { "Appetizer", "Breakfast", "Fish", "Meat", "Pasta", "Pizza", "Salad", "Sandwich", "Soup", "Sushi", "Vegetarian" };
            ViewData["Ratings"] = new List<int> { 5, 4, 3, 2, 1 };
            return View(new MealRestaurantViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFood(MealRestaurantViewModel mealModel)
        {
            string uniqueFileName = UploadedFile(mealModel);

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie thisFoodie = _repo.Foodie.GetFoodie(userId);

            Meal meal = new Meal();
            Restaurant mealRestaurant = new Restaurant();

            //if (mealImage.FilePath != null)
            //{
            //    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + mealImage.FilePath.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    mealModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            //}

            _repo.Meal.Create(meal);
            meal.Foodie = thisFoodie;
            meal.FoodieId = thisFoodie.FoodieId;
            meal.FoodOrder = mealModel.FoodOrder;
            meal.Category = mealModel.Category;
            meal.Price = mealModel.Price;
            meal.Rating = mealModel.Rating;
            meal.FutureModification = mealModel.FutureModification;
            meal.FutureOrder = mealModel.FutureOrder;
            meal.FavMeal = mealModel.FavMeal;
            meal.MealPicture = uniqueFileName;
            //meal.PhotoPath = null;
            //meal.PhotoPath = uniqueFileName;

            meal.Restaurant = mealRestaurant;
            meal.Restaurant.Name = mealModel.Name;
            meal.Restaurant.StreetAddress = mealModel.StreetAddress;
            meal.Restaurant.City = mealModel.City;
            meal.Restaurant.State = mealModel.State;
            meal.Restaurant.ZipCode = mealModel.ZipCode;
            meal.Restaurant.FavRestaurant = mealModel.FavRestaurant;

            //meal.MealImage = mealImage;
            

            _repo.Save();

            return RedirectToAction("FoodDetails", new { mealId = meal.MealId });


            //return View(mealModel);
            //return RedirectToAction("FoodDetails", mealModel);
            //return RedirectToAction("FoodDetails", new { id = meal.FoodieId });
        }

        // GET: FoodiesController/MealDetails/5
        public ActionResult FoodDetails(int mealId)
        {
            var meal = _repo.Meal.GetMeal(mealId);
            //var restaurant = _repo.Restaurant.GetRestaurant(restaurantId);

            MealRestaurantViewModel vm = new MealRestaurantViewModel();

            vm.Category = meal.Category;
            vm.FutureOrder = meal.FutureOrder;
            vm.FutureModification = meal.FutureModification;
            vm.Price = meal.Price;
            vm.Rating = meal.Rating;
            vm.FavMeal = meal.FavMeal;
            vm.FoodOrder = meal.FoodOrder;

            //vm.Name = restaurant.Name;
            //vm.StreetAddress = restaurant.StreetAddress;
            //vm.City = restaurant.City;
            //vm.State = restaurant.State;
            //vm.ZipCode = restaurant.ZipCode;

            return View(vm);
        }

        public ActionResult ViewAllMeals()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Foodie foodie = _repo.Foodie.GetFoodie(userId);
                List<Meal> meals = _repo.Meal.GetMeals(foodie.FoodieId);
                return View(meals);
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult FavoriteMeals()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Foodie foodie = _repo.Foodie.GetFoodie(userId);
                List<Meal> meals = _repo.Meal.GetMeals(foodie.FoodieId);
                var favMeals = meals.Where(m => m.FavMeal == true).ToList();

                return View(favMeals);
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult FavoriteRestaurants()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Foodie foodie = _repo.Foodie.GetFoodie(userId);
                List<Restaurant> restaurants = _repo.Restaurant.GetRestaurants();
                var favRestaurants = restaurants.Where(m => m.FavRestaurant == true).ToList();

                return View(favRestaurants);
            }
            catch
            {
                return View("Index");
            }
        }


        public ActionResult FilterByTraits(int rating, string category)
        {
            ViewData["Categories"] = new List<string> { "Appetizer", "Breakfast", "Fish", "Meat", "Pasta", "Pizza", "Salad", "Sandwich", "Soup", "Sushi", "Vegetarian" };
            ViewData["Ratings"] = new List<int> { 5, 4, 3, 2, 1 };

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = _repo.Foodie.GetFoodie(userId);
            if (foodie == null)
            {
                return RedirectToAction("Index");
            }
            List<Meal> meals = _repo.Meal.GetMeals(foodie.FoodieId);
            var mealsByRankAndCategory = meals.Where(m => m.Rating >= rating && m.Category == category).ToList();

            return View(mealsByRankAndCategory);
        }


        public ActionResult GetMealsByRank(int rating)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = _repo.Foodie.GetFoodie(userId);
            List<Meal> meals = _repo.Meal.GetMeals(foodie.FoodieId);
            var mealsByRanking = meals.Where(m => m.Rating >= rating).ToList();
            return View(mealsByRanking);
        }

        public ActionResult GetMealsByCategory(string category)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = _repo.Foodie.GetFoodie(userId);
            List<Meal> meals = _repo.Meal.GetMeals(foodie.FoodieId);
            var mealsByCategory = meals.Where(m => m.Category == category).ToList();
            return View(mealsByCategory);
        }

        private string UploadedFile(MealRestaurantViewModel mealModel)
        {
            string uniqueFileName = null;

            if (mealModel.MealImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + mealModel.MealImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    mealModel.MealImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: FoodiessController/EditMeal/5
        public ActionResult EditMeal(int mealId)
        {
            var editedMeal = _repo.Meal.GetMeal(mealId);
            return View(editedMeal);
        }

        // POST: FoodiesController/EditMeal/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMeal(Meal meal)
        {
            try
            {
                _repo.Meal.EditMeal(meal);
                _repo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodiesController/DeleteMeal/5
        public ActionResult DeleteMeal(int mealId)
        {
            var deletedMeal = _repo.Meal.GetMeal(mealId);
            _repo.Save();
            return View(deletedMeal);
        }

        // POST: FoodiesController/DeleteMeal/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeal(int id, Meal meal)
        {
            try
            {
                _repo.Meal.DeleteMeal(meal);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
