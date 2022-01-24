using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;

namespace CafeUI
{
    public class UserInterface
    {
        // Where i define how my user interface runs
        private readonly MenuRepository _repo = new MenuRepository();
        // run method dictates what runs
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            string userSelection = "";

            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Enter the number of your menu selection:\n" +
                    "1. Show all menu items \n" +
                    "2. Find menu items by name\n" +
                    "3. Add new items\n" +
                    "4. Update items \n" +
                    "5. Remove items \n" +
                    "6. Exit"
                );

                userSelection = Console.ReadLine();

                switch(userSelection)
                {
                    case "1":
                        DisplayAllItems();
                        break;
                    case "2":
                        DisplayByName();
                        break;
                    case "3":
                        AddNewItem();
                        break;
                    case "4":
                        UpdateExistingItems();
                        break;
                    case "5":
                        RemoveExistingItem();
                        break;
                    case "6":
                        //Exit
                        System.Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        // what to do with invalid input
                        break;

                }

            }

        }

        // Display all method
        private void DisplayAllItems()
        {
            List<Menu> listOfItems = _repo.GetItems();
            foreach(Menu item in listOfItems)
            {
                System.Console.WriteLine(
                    $"Name: {item.MealName} \n" +
                    $"Description: {item.MealDescription} \n" +
                    $"Number: {item.MealNumber} \n" +
                    $"Price: {item.MealPrice} \n");
                foreach(string ingredient in item.ListOfIngredients)
                {
                    System.Console.WriteLine($"Ingredients: {ingredient}");
                }
                
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Display by name
        private void DisplayByName()
        {
            Console.Clear();

            List<Menu> listOfItems = _repo.GetItems();

            System.Console.WriteLine("Enter the name of the menu item you're looking for: ");
            string itemName = Console.ReadLine();
            foreach(Menu item in listOfItems)
            {
                if(itemName == item.MealName)
                {
                    System.Console.WriteLine(
                        $"Name: {item.MealName} \n" +
                        $"Description: {item.MealDescription} \n" +
                        $"Number: {item.MealNumber} \n" +
                        $"Price: {item.MealPrice} \n");
                    foreach(string ingredient in item.ListOfIngredients)
                    {
                        System.Console.WriteLine($"Ingredients: {ingredient}");
                    }
                }
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Add new
        private void AddNewItem()
        {
            Menu item = new Menu();

            Console.WriteLine("Enter the meal's name: ");
            item.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal' description: ");
            item.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the meal's number: ");
            item.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the meal's price: ");
            item.MealPrice = decimal.Parse(Console.ReadLine());

            bool addingIngredients = true;
            while(addingIngredients)
            {
                Console.WriteLine("Enter the meal's ingredients: ");
                item.ListOfIngredients.Add(Console.ReadLine());
                System.Console.WriteLine("Do you want to add more ingredients? Y or N ");
                string response = Console.ReadLine().ToUpper();
                if(response == "N")
                {
                    addingIngredients = false;
                }
                else if(response != "Y" && response != "N")
                {
                    Console.WriteLine("Sorry, didn't understand that");
                }
            }

            _repo.AddItemToDirectory(item);
            // Add confirmation that content was added

            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Update existing items
        
        private void UpdateExistingItems()
        {
            Console.Clear();
            // Select what content to update
            System.Console.WriteLine("Select the item you want to update: ");
            // Asking for title, or from list
            List<Menu> itemList = _repo.GetItems();
            int counter = 1;


            foreach(Menu item in itemList)
            {
                System.Console.WriteLine(counter + ". " + item.MealName);
                counter++;
            }

            int itemSelection = int.Parse(Console.ReadLine());
            int targetIndex = itemSelection - 1;

            if(targetIndex >= 0 && targetIndex < itemList.Count)
            {
                Menu targetItem = itemList[targetIndex];
                // _repo.UpdateExistingItem(originalName, newItem)
                {

                }

            }
            else
            {
                // Invalid selection
                System.Console.WriteLine("Invalid Selection");

            }

            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Delete items
        private void RemoveExistingItem()
        {
            Console.Clear();

            //Listing all content and letting user pick one
            Console.WriteLine("Select the item you want to remove: ");

            List<Menu> itemList = _repo.GetItems();
            int counter = 1;


            foreach(Menu item in itemList)
            {
                System.Console.WriteLine(counter + ". " + item.MealName);
                counter++;
            }

            int itemSelection = int.Parse(Console.ReadLine());
            int targetIndex = itemSelection - 1;

            //check for valid selection
            if(targetIndex >= 0 && targetIndex < itemList.Count)
            {
                Menu targetItem = itemList[targetIndex];

                if (_repo.DeleteExistingItem(targetItem))
                {
                    //Code for succcess
                    System.Console.WriteLine($"{targetItem.MealName} was removed");
                }
                else
                {
                    System.Console.WriteLine("Something went wrong");
                }
            }
            else
            {
                // Invalid selection
                System.Console.WriteLine("Invalid Selection");

            }

            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }






        // static void Main(string[] args)
        // {





        //     // Where we will build the UI
        //     Console.WriteLine("Hello World!");
        //     Menu item1 = new Menu();
        //     // Menu is the class, Item1 is the object
        //     item1.MealName = "Donut";
        //     item1.MealDescription = "A tasty hole";
        //     item1.MealNumber = 1;
        //     item1.MealPrice = 3.99m;
        //     item1.ListOfIngredients.Add("Flour");
        //     item1.ListOfIngredients.Add("Water");
        //     System.Console.Write(item1.MealName + "\n" + item1.MealDescription + "\n" + item1.MealNumber + "\n" + item1.MealPrice + "\n" + "The ingredients are: ");

        //     foreach(string ingredient in item1.ListOfIngredients)
        //     {
        //         Console.Write(ingredient + " and ");
        //     }

        //     //---------------------------------------------------//

            public void SeedContent(){

            List<string> listOfIngredients2 = new List<string>();
            listOfIngredients2.Add("Flour");
            listOfIngredients2.Add("Water");

            Menu item2 = new Menu(2, "Croissaint", "Moon shaped dessert", 6.99m, listOfIngredients2);
            _repo.AddItemToDirectory(item2);
            }

        //     System.Console.WriteLine(item2.MealName + "\n" + item2.MealDescription + "\n" + item2.MealNumber + "\n" + item2.MealPrice + "\n" + "The ingredients are: " + item2.ListOfIngredients[0] + ", " + item2.ListOfIngredients[1]);

        //     // List<Menu> listOfIngredients = new List<Menu>();

        //     // MenuRepository repo = new MenuRepository();

        //     Repository repo = new Repository();

        //     repo.AddItemToDirectory(item1);

        //     System.Console.WriteLine(repo.AddItemToDirectory(item1));

        //     List<Menu> list = repo.GetItems();

        //     System.Console.WriteLine("What would you like to add to the menu");
        

    }
}