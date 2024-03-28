using DishStorer.View.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DishStorer.Business;
using DishStorer.Data;


namespace DishStorer
{
    /// <summary>
    /// Interaction logic for CookBook.xaml
    /// </summary>
    
    public partial class CookBook : Window
    {
        int idOfList = 0;
        private Dish? filterDish = null;
        private DishBusiness dishBusiness = new DishBusiness();
        private List<Dish> allDishes = new List<Dish>();
        int all=0;
        public CookBook()
        {
            InitializeComponent();
            Title.Text = "Nugger";
            allDishes = dishBusiness.GetAll();
            Fat.txtInput.Text = allDishes.Count.ToString();

            allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
            if (allDishes.Count != 0)
            {
                DishNameList.Text = allDishes[idOfList].Name;
                DishFatList.Text = "Fat: " + allDishes[idOfList].Fat.ToString();
                DishCarbsList.Text = "Carbohydrates: " + allDishes[idOfList].Carbohydrates.ToString();
                DishCuisineList.Text = "Cuisine: " + allDishes[idOfList].Cuisine.ToString();
                if (allDishes[idOfList].Breakfast == 1)
                    DishBreakfastList.Text = "Breakfast: " + "yes";
                else
                    DishBreakfastList.Text = "Breakfast: " + "no";
                if (allDishes[idOfList].Lunch == 1)
                    DishLunchList.Text = "Lunch: " + "yes";
                else
                    DishLunchList.Text = "Lunch: " + "no";
                if (allDishes[idOfList].Dinner == 1)
                    DishDinnerList.Text = "Dinner: " + "yes";
                else
                    DishDinnerList.Text = "Dinner: " + "no";
            }
        }
        private void SwitchToPerson_Click(object sender, RoutedEventArgs e)
        {
            CookBook1.Hide();
        }

        private void DishAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }
            PersonBusiness personBusiness=new PersonBusiness();
            Person currentPerson;
            List<Person> people = personBusiness.GetAll();
            Dish dish = new Dish();
            dish.Name = NameOfDishToAdd.txtInput.Text.ToLower();
            dish.Fat = int.Parse(Fat.txtInput.Text);
            dish.Carbohydrates = int.Parse(Carbohydrates.txtInput.Text);
            dish.Protein = int.Parse(Protein.txtInput.Text);
            dish.Cuisine = Cuisine.txtInput.Text.ToLower();
            if (BreakfastCheckbox.IsChecked == true)
                dish.Breakfast = 1;
            else
                dish.Breakfast = 0;
            if (LunchCheckbox.IsChecked == true)
                dish.Lunch = 1;
            else
                dish.Lunch = 0;
            if (DinnerCheckbox.IsChecked == true)
                dish.Dinner = 1;
            else
                dish.Dinner = 0;
            if (FavoriteCheckBox.IsChecked == true)
            {
                foreach (var el in people)
                {
                    if (el.CurrentPerson == 1)
                    {
                        currentPerson = el;
                        dish.Favourite = dish.Favourite + ',' + currentPerson.Name;
                        break;
                    }
                    
                }
                
            }
            
            var dishes = dishBusiness.GetAll();
            List<int> ids = new List<int>();
            foreach (var el in dishes)
                ids.Add(el.Id);
            ids.Sort();
            if (ids.Count==0)
            {
                dish.Id = 1;
            }
            else
            {
                int i = 1;
                foreach (var el in ids)
                {
                    if (el - i != 0)
                    {
                        dish.Id = i + 1;
                        break;
                    }
                    else if (i == ids.Count)
                        dish.Id = ids.Count+1;
                    i++;
                }
                dishBusiness.Add(dish);
                allDishes.Add(dish);
                allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
            }    
        }

        private void DishUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }
            int id= -1;
            var dishes = dishBusiness.GetAll();
            PersonBusiness personBusiness = new PersonBusiness();
            Person currentPerson;
            List<Person> people = personBusiness.GetAll();
            Dish dish = new Dish();
            Dish dishToRemove = new Dish();
            foreach (var el in dishes)
            {
                if (el.Name == NameOfDishToAdd.txtInput.Text)
                {
                    id = el.Id;
                    dishToRemove = el;
                }
                
            }
            if (id == -1)
                throw new ArgumentException("No dish with that name exists");
            dishBusiness.Delete(id);
            allDishes.Remove(dishToRemove);
            dish.Name = NameOfDishToAdd.txtInput.Text.ToLower();
            if (Fat.txtInput.Text!=String.Empty)dish.Fat = int.Parse(Fat.txtInput.Text);
            if (Carbohydrates.txtInput.Text != String.Empty) dish.Carbohydrates = int.Parse(Carbohydrates.txtInput.Text);
            if (Protein.txtInput.Text != String.Empty) dish.Protein = int.Parse(Protein.txtInput.Text);
            if (Cuisine.txtInput.Text != String.Empty) dish.Cuisine = Cuisine.txtInput.Text.ToLower();
            if (BreakfastCheckbox.IsChecked == true)
                dish.Breakfast = 1;
            else
                dish.Breakfast = 0;
            if (LunchCheckbox.IsChecked == true)
                dish.Lunch = 1;
            else
                dish.Lunch = 0;
            if (DinnerCheckbox.IsChecked == true)
                dish.Dinner = 1;
            else
                dish.Dinner = 0;
            if (FavoriteCheckBox.IsChecked == true)
            {
                foreach (var el in people)
                {
                    if (el.CurrentPerson == 1)
                    {
                        currentPerson = el;
                        dish.Favourite = dish.Favourite + ',' + currentPerson;
                        break;
                    }

                }

            }

            List<int> ids = new List<int>();
            foreach (var el in dishes)
                ids.Add(el.Id);
            ids.Sort();
            if (ids.Count == 0)
            {
                dish.Id = 1;
            }
            else
            {
                int i = 1;
                foreach (var el in ids)
                {
                    if (el - i != 0)
                    {
                        dish.Id = i + 1;
                        break;
                    }
                    else if (i == ids.Count)
                        dish.Id = ids.Count + 1;
                    i++;
                }
                dishBusiness.Add(dish);
                allDishes.Add(dish);
                allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
            }
        }

        private void DishClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filterDish = null;

        }

        private void DishFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }
            PersonBusiness personBusiness = new PersonBusiness();
            Person currentPerson;
            List<Person> people = personBusiness.GetAll();
            Dish dish = new Dish();
            dish.Name = NameOfDishToAdd.txtInput.Text.ToLower();
            dish.Fat = int.Parse(Fat.txtInput.Text);
            dish.Carbohydrates = int.Parse(Carbohydrates.txtInput.Text);
            dish.Protein = int.Parse(Protein.txtInput.Text);
            dish.Cuisine = Cuisine.txtInput.Text.ToLower();
            if (BreakfastCheckbox.IsChecked == true)
                dish.Breakfast = 1;
            else
                dish.Breakfast = 0;
            if (LunchCheckbox.IsChecked == true)
                dish.Lunch = 1;
            else
                dish.Lunch = 0;
            if (DinnerCheckbox.IsChecked == true)
                dish.Dinner = 1;
            else
                dish.Dinner = 0;
            if (FavoriteCheckBox.IsChecked == true)
            {
                foreach (var el in people)
                {
                    if (el.CurrentPerson == 1)
                    {
                        currentPerson = el;
                        dish.Favourite = dish.Favourite + ',' + currentPerson;
                        break;
                    }

                }

            }
            filterDish = dish;
            
        }

        private void DishDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }
            int id = -1;
            var dishes = dishBusiness.GetAll();
            PersonBusiness personBusiness = new PersonBusiness();
            Person currentPerson;
            List<Person> people = personBusiness.GetAll();
            Dish dish = new Dish();
            foreach (var el in dishes)
            {
                if (el.Name == NameOfDishToRemove.txtInput.Text)
                    id = el.Id;

            }
            if (id == -1)
                throw new ArgumentException("No dish with that name exists");
            dishBusiness.Delete(id);
            allDishes.Remove(dish);
            allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }
            if (idOfList - 1 < 0)
                idOfList = allDishes.Count() - 1;
            
                allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
                DishNameList.Text = allDishes[idOfList].Name;
                DishFatList.Text = "Fat: " + allDishes[idOfList].Fat.ToString();
                DishCarbsList.Text = "Carbohydrates: " + allDishes[idOfList].Carbohydrates.ToString();
                DishCuisineList.Text = "Cuisine: " + allDishes[idOfList].Cuisine.ToString();
                if (allDishes[idOfList].Breakfast == 1)
                    DishBreakfastList.Text = "Breakfast: " + "yes";
                else
                    DishBreakfastList.Text = "Breakfast: " + "no";
                if (allDishes[idOfList].Lunch == 1)
                    DishLunchList.Text = "Lunch: " + "yes";
                else
                    DishLunchList.Text = "Lunch: " + "no";
                if (allDishes[idOfList].Dinner == 1)
                    DishDinnerList.Text = "Dinner: " + "yes";
                else
                    DishDinnerList.Text = "Dinner: " + "no";
            

        }

        private void GoForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (all == 0)
            {
                allDishes = dishBusiness.GetAll();
                all++;
            }

            // Increment idOfList
            idOfList++;

            // Check if idOfList exceeds the bounds of the allDishes list
            if (idOfList >= allDishes.Count)
            {
                idOfList = 0; // Reset idOfList to 0 to loop back to the beginning
            }

            // Check if allDishes is not empty
            if (allDishes.Count > 0)
            {
                // Access elements from allDishes based on the updated idOfList
                allDishes.Sort(delegate (Dish c1, Dish c2) { return c1.Id.CompareTo(c2.Id); });
                DishNameList.Text = allDishes[idOfList].Name;
                DishFatList.Text = "Fat: " + allDishes[idOfList].Fat.ToString();
                DishCarbsList.Text = "Carbohydrates: " + allDishes[idOfList].Carbohydrates.ToString();
                DishCuisineList.Text = "Cuisine: " + allDishes[idOfList].Cuisine.ToString();
                if (allDishes[idOfList].Breakfast == 1)
                    DishBreakfastList.Text = "Breakfast: " + "yes";
                else
                    DishBreakfastList.Text = "Breakfast: " + "no";
                if (allDishes[idOfList].Lunch == 1)
                    DishLunchList.Text = "Lunch: " + "yes";
                else
                    DishLunchList.Text = "Lunch: " + "no";
                if (allDishes[idOfList].Dinner == 1)
                    DishDinnerList.Text = "Dinner: " + "yes";
                else
                    DishDinnerList.Text = "Dinner: " + "no";
            }
            else
            {
                // Handle the case when allDishes is empty
                // Optionally, you can display a message or perform other actions
            }
        }
    }
}