using Coursework1.Model;
using Coursework1.Service;
using Microsoft.AspNetCore.Components;

namespace Coursework1.Pages
{
    public partial class Index
    {
        private List<User> users;
        private ICsvHelper csvHelper;
        protected override void OnInitialized()
        {
            base.OnInitialized();

            csvHelper = new MyCsvHelper();
            users = csvHelper.GetUsers();
            if (users != null)
            {
                // Successful login, navigate to another page
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                // Failed login, display error or handle accordingly
                Console.WriteLine("Invalid username or password");
            }
        }

       
    }
}