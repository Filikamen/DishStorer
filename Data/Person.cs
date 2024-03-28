using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DishStorer.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Gender { get; set; }= string.Empty;
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public int CurrentPerson { get; set; }
        
    }
}
