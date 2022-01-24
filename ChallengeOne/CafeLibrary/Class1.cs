using System;
using System.Collections.Generic;

namespace CafeLibrary
{
    //Cafe Library is where POCO and Repo go
    //POCO: Plain Old Csharp Object
    public class Menu
    {
        //Constructors
        public Menu() { }
        public Menu(int mealNumber, string mealName, string mealDescription, decimal mealPrice, List<string> listOfIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            ListOfIngredients = listOfIngredients;
        }

        // Properties
        public int MealNumber { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        public decimal MealPrice { get; set; }

        public List<string> ListOfIngredients = new List<string>();
    }
}
