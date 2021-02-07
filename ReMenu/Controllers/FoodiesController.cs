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

namespace ReMenu.Controllers
{
    public class FoodiesController : Controller
    {
        private readonly IInterfaceWrapper _repo;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        //[Obsolete]
        /*public FoodiesController(IInterfaceWrapper repo, IHostingEnvironment hostingEnvironment)
        {
            _repo = repo;
            this.hostingEnvironment = hostingEnvironment;
        }*/

        private readonly ApplicationDbContext _context;
        public FoodiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodiesController
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var foodie = await _repo.Foodie.GetFoodieAsync(userId);
            var foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            //var meals = _repo.Meal.GetMealsAsync(foodie.FoodieId);
            if (foodie == null)
            {
                return RedirectToAction("Create");
            }
            //var myMeals = _repo.Meal.GetMealsAsync();

            return View("Index");
        }

        // GET: FoodiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Foodie foodie)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Foodie newFoodie = new Foodie();
                newFoodie.IdentityUserId = userId;
                newFoodie.FirstName = foodie.FirstName;
                newFoodie.LastName = foodie.LastName;
                _context.Add(newFoodie);
                await _context.SaveChangesAsync();

                //_repo.Foodie.CreateFoodie(foodie);
                //await _repo.SaveAsync();
                return RedirectToAction(nameof(CreateRestaurant));
            }
            return View(foodie);
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
            ViewData["allStates"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View();
        }

        // POST: FoodiesController/CreateRestaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRestaurant([Bind("RestaurantId, Name, StreetAddress, City, State, ZipCode")] Restaurant restaurant)
        {
            try
            {
                Restaurant newRestaurant = new Restaurant();
                newRestaurant.Name = restaurant.Name;
                newRestaurant.StreetAddress = restaurant.StreetAddress;
                newRestaurant.City = restaurant.City;
                newRestaurant.State = restaurant.State;
                newRestaurant.ZipCode = restaurant.ZipCode;
                _context.Add(newRestaurant);
                await _context.SaveChangesAsync();

                //_repo.Restaurant.Create(restaurant);
                //await _repo.SaveAsync();
                return RedirectToAction("CreateMeal", new {id = restaurant.RestaurantId });
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
            ViewData["Categories"] = new List<string> { "Breakfast", "Fish", "Meat", "Pasta", "Pizza", "Salad", "Sandwich", "Soup", "Sushi", "Vegetarian" };
            ViewData["Ratings"] = new List<int> { 5, 4, 3, 2, 1 };
            ViewData["FoodieId"] = new SelectList(_context.Foodies, "FoodieId", "FoodieId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");

            return View(new Meal());
        }

        // POST: FoodiesController/CreateMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMeal([Bind("MealId, FoodieId, RestaurantId, FoodOrder, Category, Price, Rating, FutureModification, FutureOrder, Photo")] Meal meal)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);
            var foodie = _context.Foodies.Where(f => f.IdentityUserId.Equals(userId)).FirstOrDefault();

            try
            {
                {
                    Meal newMeal = new Meal();
                    newMeal.FoodieId = foodie.FoodieId;
                    var thisRestaurant = _context.Restaurants.Where(r => r.RestaurantId == newMeal.RestaurantId).FirstOrDefault();
                    newMeal.RestaurantId = thisRestaurant.RestaurantId;
                 
                    newMeal.Restaurant = thisRestaurant;
                    newMeal.FoodOrder = meal.FoodOrder;
                    newMeal.Category = meal.Category;
                    newMeal.Price = meal.Price;
                    newMeal.Rating = meal.Rating;
                    newMeal.FutureModification = meal.FutureModification;
                    newMeal.FutureOrder = meal.FutureOrder;
                    newMeal.PhotoPath = meal.PhotoPath;
                    _context.Add(newMeal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MealDetails", new { id = meal.MealId });
                };
                //return View(meal);
                //return RedirectToAction("MealDetails", new { id = newMeal.FoodieId });
                //return RedirectToAction("MealDetails", new { id = newMeal.MealId });
            }
            catch (Exception e)
            {
                return View(e);
            } 
        }

        // GET: FoodiesController/MealDetails/5
        public ActionResult MealDetails(int mealId)
        {
            //var meal = await _repo.Meal.GetMealAsync(mealId);
            return View();
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

        /*private List<Meal> GetMeals()
        {
            var meals = _repo.Meal.FindAll();
            List<Meal> allMeals = new List<Meal>();
            foreach(Meal m in meals)
            {
                allMeals.Add(m);
            }

            return allMeals;
        }*/

        public async Task<ActionResult> GetMeals()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);
            List<Meal> meals = await _repo.Meal.GetMealsAsync(foodie.FoodieId);
            return View(meals);
        }
    }
}
