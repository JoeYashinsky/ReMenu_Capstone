using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.ViewModels
{
    public class MealRestaurantViewModel
    {

        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Food Order")]  // [DisplayName("Food Order")]
        public string FoodOrder { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Future Modification")]
        public string FutureModification { get; set; }

        [Display(Name = "Wish I Would Have...")]
        public string FutureOrder { get; set; }

        [Display(Name = "Favorite This Restaurant?")]
        public bool FavRestaurant { get; set; }

        [Display(Name = "Favorite This Meal?")]
        public bool FavMeal { get; set; }

        [Display(Name = "Your Meal Image")]
        public IFormFile MealImage { get; set; }
    }
}
