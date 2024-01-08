using Coursework1.Model;
using Coursework1.Service;

namespace Coursework1.Pages
{
    public partial class AddCoffee
    {
        private List<Coffee> coffeeTypes;
        private Coffee newCoffeeType = new Coffee();
        private ICoffeeService coffeeService;

        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();

        //    if (coffeeService != null)
        //    {
        //        coffeeTypes = coffeeService.GetCoffeeTypes();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Coffee service is not initialized.");
        //    }
        //}


        private void AddCoffeeType()
        {
          
            coffeeService.AddCoffeeType(newCoffeeType);
            newCoffeeType = new Coffee();
        }

        private void DeleteCoffeeType(int coffeeTypeId)
        {
            coffeeService.DeleteCoffeeType(coffeeTypeId);
            coffeeTypes = coffeeService.GetCoffeeTypes(); // Refresh the list after deletion
        }

        // Method to edit a Coffee Type (implementation may vary based on requirements)
        private void EditCoffeeType(Coffee coffeeType)
        {
            // Implement edit functionality here, such as displaying a modal or form
            // to update the Coffee Type details
        }
    }
}