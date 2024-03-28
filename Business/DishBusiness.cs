using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DishStorer.Data;
namespace DishStorer.Business
{
    class DishBusiness
    {
        public DishDbContext DishDbContext;

        public List<Dish> GetAll()
        {
            using (DishDbContext = new DishDbContext())
            {
            return DishDbContext.Dishes.ToList ();
            }
        }

        public void Add(Dish dish)
        {
            using (DishDbContext = new DishDbContext())
            {
                DishDbContext.Dishes.Add(dish);
                DishDbContext.SaveChanges();

            }
        }

        public void Update(Dish dish)
        {
            using (DishDbContext = new DishDbContext())
            {

                var item = DishDbContext.Dishes.Find(dish.Id);
                if (item != null)
                {
                    DishDbContext.Entry(item).CurrentValues.SetValues(dish);
                    DishDbContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (DishDbContext = new DishDbContext())
            {
                var dish = DishDbContext.Dishes.Find(id);
                if (dish != null)
                {
                    DishDbContext.Dishes.Remove(dish);
                    DishDbContext.SaveChanges();
                }
            }
        }
    }
        class PersonBusiness
        {
            private DishDbContext DishDbContext;

            public List<Person> GetAll()
            {
                using (DishDbContext = new DishDbContext())
                {
                    return DishDbContext.People.ToList();
                }
            }

            public void Add(Person person)
            {
                using (DishDbContext = new DishDbContext())
                {
                    DishDbContext.People.Add(person);
                    DishDbContext.SaveChanges();

                }
            }

            public void Update(Person person)
            {
                using (DishDbContext = new DishDbContext())
                {

                    var item = DishDbContext.People.Find(person.Id);
                    if (item != null)
                    {
                        DishDbContext.Entry(item).CurrentValues.SetValues(person);
                        DishDbContext.SaveChanges();
                    }

                }
            }

            public void Delete(int id)
            {
                using (DishDbContext = new DishDbContext())
                {
                    var person = DishDbContext.People.Find(id);
                    if (person != null)
                    {
                        DishDbContext.People.Remove(person);
                        DishDbContext.SaveChanges();
                    }
                }
            }
        }
    }

