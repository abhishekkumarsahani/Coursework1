using Coursework1.Model;
using Coursework1.Service;
using MudBlazor;

namespace Coursework1.Pages
{
    public partial class AddInType
    {
        List<AddIn> addinTypes = new List<AddIn>();
        private ICoffeeService coffeeService;
        string adminPassword = "admin123"; // Replace with your actual admin password
        string enteredPassword = "";
        decimal newPrice;
        int addinIdToUpdate;

        protected override void OnInitialized()
        {
            LoadCoffeeTypes();
        }

        private void LoadCoffeeTypes()
        {
            base.OnInitialized();
            coffeeService = new CoffeeService();
            addinTypes = coffeeService.GetAddIns();
        }
        private void ChangeAddinPrice()
        {
            if (enteredPassword == adminPassword)
            {
                UpdateAddinPrice(addinIdToUpdate, newPrice);
                enteredPassword = ""; // Reset password field
                newPrice = 0; // Reset price field
            }
            else
            {
                // Handle incorrect password, show error message or take appropriate action
                Snackbar.Add("Incorrect password", Severity.Error);
            }
        }

        private void UpdateAddinPrice(int addinId, decimal updatedPrice)
        {
            // Your logic to update the price goes here
            var addinToUpdate = addinTypes.Find(c => c.Id == addinId);
            if (addinToUpdate != null)
            {
                addinToUpdate.Price = updatedPrice;
                coffeeService.UpdateAddIn(addinToUpdate);

                Snackbar.Add("Price updated successfully", Severity.Success);
            }
        }

    }
}