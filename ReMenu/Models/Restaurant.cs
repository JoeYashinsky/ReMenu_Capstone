using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Favorite This Restaurant?")]
        public bool FavRestaurant { get; set; }
    }
}
