using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models
{
    public class FavoriteMeal
    {
        [Key]
        public int FavoriteMealId { get; set; }

        [ForeignKey("Foodie")]
        public int FoodieId { get; set; }
        public Foodie Foodie { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
