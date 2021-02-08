using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Services
{
    public class Geocoding
    {
        public Result[] Results { get; set; }
        public string Status { get; set; }
    }
    public class Result
    {
        public Address_Components[] Address_components { get; set; }
        public string Formatted_address { get; set; }
        public Geometry Geometry { get; set; }
        public string Place_id { get; set; }
        public Plus_Code Plus_code { get; set; }
        public string[] Types { get; set; }
    }

    public class Geometry
    {
        public Location Location { get; set; }
        public string Location_type { get; set; }
        public Viewport Viewport { get; set; }
    }

    public class Location
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }

    public class Viewport
    {
        public Northeast Northeast { get; set; }
        public Southwest Southwest { get; set; }
    }

    public class Northeast
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }

    public class Southwest
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }

    public class Plus_Code
    {
        public string Compound_code { get; set; }
        public string Global_code { get; set; }
    }

    public class Address_Components
    {
        public string Long_name { get; set; }
        public string Short_name { get; set; }
        public string[] Types { get; set; }
    }
    
}
