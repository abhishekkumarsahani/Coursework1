using Microsoft.AspNetCore.Components;

namespace Coursework1.Pages
{
    public partial class AdminSetup
    {

         private void GoToCoffeePanel()
        {
            NavigationManager.NavigateTo("/coffee-types");
        }
    }
}