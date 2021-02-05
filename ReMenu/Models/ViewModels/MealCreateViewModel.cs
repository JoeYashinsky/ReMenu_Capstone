using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models.ViewModels
{
    public class MealCreateViewModel
    {

        [Display(Name = "Food Order")]  // [DisplayName("Food Order")]
        public string FoodOrder { get; set; }
        public int ResturantId { get; set; }

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

        public IFormFile Photo { get; set; }
    }
}
