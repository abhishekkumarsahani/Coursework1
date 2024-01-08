using Coursework1.Model;
using Coursework1.Service;
using Microsoft.AspNetCore.Components;

namespace Coursework1.Pages
{
    public partial class Login
    {
        private string username;
        private string password;

        private List<User> users;
        private ICsvHelper csvHelper; // Using the interface

        protected override void OnInitialized()
        {
            base.OnInitialized();

            csvHelper = new MyCsvHelper();
            users = csvHelper.ReadUsersFromCsv();
        }

        private void PerformLogin()
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Successful login, navigate to another page
                NavigationManager.NavigateTo("/admin");
            }
            else
            {
                // Failed login, display error or handle accordingly
                Console.WriteLine("Invalid username or password");
            }
        }
    }
}