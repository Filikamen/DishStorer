using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Reflection.Metadata.BlobBuilder;


namespace DishStorer.Data
{
    public class DishDbContext : DbContext
    {
        public DbSet<Person>? People { get; set; }
        public DbSet<Dish>? Dishes { get; set; }
        public DishDbContext() : base("name=DishDbContext")
        {
         
        }
    }
 }
   
