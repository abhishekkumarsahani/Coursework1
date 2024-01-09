using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework1.Model;

namespace Coursework1.Service
{
    internal class CoffeeService : ICoffeeService
    {
        private string coffeeTypesFilePath = "C:\\Abhi Mud\\Coursework1\\Data\\coffee_types.csv"; // Path to coffee types CSV
        private string addInsFilePath = "C:\\Abhi Mud\\Coursework1\\Data\\add_ins.csv"; // Path to add-ins CSV

        public List<Coffee> GetCoffeeTypes()
        {
            using (var reader = new StreamReader(coffeeTypesFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Coffee>().ToList();
            }
        }
       

        public void AddCoffeeType(Coffee coffeeType)
        {
            var records = new List<Coffee>();
            records.AddRange(GetCoffeeTypes());
            records.Add(coffeeType);

            using (var writer = new StreamWriter(coffeeTypesFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public void UpdateCoffee(Coffee updatedCoffeeType)
        {
            var records = GetCoffeeTypes();
            var existingCoffeeType = records.Find(c => c.Id == updatedCoffeeType.Id);

            if (existingCoffeeType != null)
            {
                existingCoffeeType.CoffeeName = updatedCoffeeType.CoffeeName;
                existingCoffeeType.Price = updatedCoffeeType.Price;

                WriteRecordsToFile(records);
            }
        }

        public void DeleteCoffeeType(int coffeeTypeId)
        {
            var records = GetCoffeeTypes();
            var coffeeTypeToDelete = records.Find(c => c.Id == coffeeTypeId);

            if (coffeeTypeToDelete != null)
            {
                records.Remove(coffeeTypeToDelete);
                
                WriteRecordsToFile(records);
            }
        }
        private void WriteRecordsToFile(List<Coffee> records)
        {
            using (var writer = new StreamWriter(coffeeTypesFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }


        public List<AddIn> GetAddIns()
        {
            throw new NotImplementedException();
        }

        public void AddAddIn(AddIn addIn)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddIn(AddIn addIn)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddIn(int addInId)
        {
            throw new NotImplementedException();
        }
    }
}
