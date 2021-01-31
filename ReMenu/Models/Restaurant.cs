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
    }
}
