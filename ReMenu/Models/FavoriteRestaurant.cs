﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models
{
    public class FavoriteRestaurant
    {
        [Key]
        public int FavoriteRestaurantId { get; set; }

        [ForeignKey("Foodie")]
        public int FoodieId { get; set; }
        public Foodie Foodie { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        public Restaurant Restaurant { get; set; }

    }
}
