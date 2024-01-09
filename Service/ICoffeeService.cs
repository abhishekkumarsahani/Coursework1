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
        void AddCoffeeType(Coffee coffeeType);
        void UpdateCoffee(Coffee coffeeType);
        void DeleteCoffeeType(int coffeeTypeId);

        List<AddIn> GetAddIns();
        void AddAddIn(AddIn addIn);
        void UpdateAddIn(AddIn addIn);
        void DeleteAddIn(int addInId);
    }
}
