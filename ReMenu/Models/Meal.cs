using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }

        [ForeignKey("Foodie")]
        public int FoodieId { get; set; }
        public Foodie Foodie { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

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
        
        [Display(Name = "Meal Photo")]
        public string MealPicture { get; set; }

        [Display(Name = "Wish I Would Have...")]
        public string FutureOrder { get; set; }

        [Display(Name = "Favorite This Meal?")]
        public bool FavMeal { get; set; }

    }
}
