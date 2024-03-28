using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DishStorer.Data
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public float Calories { get; set; }
        public float Carbohydrates { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public string Cuisine { get; set; } = string.Empty;
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public string? Favourite { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
