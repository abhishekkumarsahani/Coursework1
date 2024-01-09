using Coursework1.Service;
using MudBlazor;
using Coursework1.Model;

namespace Coursework1.Pages
{
    public partial class CoffeeType
    {
        List<Coffee> coffeeTypes = new List<Coffee>();
        private ICoffeeService coffeeService;
        string adminPassword = "admin123"; // Replace with your actual admin password
        string enteredPassword = "";
        decimal newPrice;
        int coffeeIdToUpdate;

        protected override void OnInitialized()
        {
            LoadCoffeeTypes();
        }

        private void LoadCoffeeTypes()
        {
            base.OnInitialized();
            coffeeService = new CoffeeService();
            coffeeTypes = coffeeService.GetCoffeeTypes();
        }
        private void ChangeCoffeePrice()
        {
            if (enteredPassword == adminPassword)
            {
                UpdateCoffeePrice(coffeeIdToUpdate, newPrice);
                enteredPassword = ""; // Reset password field
                newPrice = 0; // Reset price field
            }
            else
            {
                // Handle incorrect password, show error message or take appropriate action
                Snackbar.Add("Incorrect password", Severity.Error);
            }
        }

        private void UpdateCoffeePrice(int coffeeId, decimal updatedPrice)
        {
            // Your logic to update the price goes here
            var coffeeToUpdate = coffeeTypes.Find(c => c.Id == coffeeId);
            if (coffeeToUpdate != null)
            {
                coffeeToUpdate.Price = updatedPrice;
                CoffeeService.UpdateCoffee(coffeeToUpdate);

                Snackbar.Add("Price updated successfully", Severity.Success);
            }
        }



    }
}