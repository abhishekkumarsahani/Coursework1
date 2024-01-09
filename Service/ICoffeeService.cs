using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework1.Model;

namespace Coursework1.Service
{
    internal interface ICoffeeService
    {
        List<Coffee> GetCoffeeTypes();
        void UpdateCoffee(Coffee coffeeType);
        List<AddIn> GetAddIns();
        void UpdateAddIn(AddIn addIn);
    }
}
