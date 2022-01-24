using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuRepository
    {
        //Field for data storage
        private readonly List<Menu> _repo = new List<Menu>();

        // Retrieve it, store, update, delete
        // CRUD (Create (Store), Read (Retrieve), Update, Delete)

        //Create
        public bool AddItemToDirectory(Menu item)
        {
            int startingCount = _repo.Count;

            _repo.Add(item);

            return _repo.Count > startingCount;
        }

        //Read
        //ReadAll
        public List<Menu> GetItems()
        {
            return _repo;
        }

        //Get by name
        public Menu GetItemByName(string horse) 
        {
            // Look thru our collection
            foreach(Menu name in _repo)
            {
                // If we find the title return it
                if(name.MealName == horse)
                {
                    return name;
                }
            }
            
            return null;
            // If we don't find it, do something else

        }

        //Update
        public bool UpdateExistingItem(string originalName, Menu newItem)
        {
            //Find the original item
            Menu oldItem = GetItemByName(originalName);
            //If we find it, update it
            if(oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealPrice = newItem.MealPrice;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;

                return true;
            }
            //If not, say we couldnt
            return false;

        }

        //Delete
        public bool DeleteExistingItem(Menu existingItem)
        {
            return _repo.Remove(existingItem);
        }
    }
}