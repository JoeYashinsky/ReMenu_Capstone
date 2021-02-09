using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Models
{
    public class MealImage
    {
        [Key]

        public int MealImageId { get; set; }

        public string FilePath { get; set; }

        public IFormFile Photo { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
