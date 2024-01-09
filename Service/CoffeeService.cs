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
        private string addInsFilePath = "C:\\Abhi Mud\\Coursework1\\Data\\addin_types.csv"; // Path to add-ins CSV

        public List<Coffee> GetCoffeeTypes()
        {
            using (var reader = new StreamReader(coffeeTypesFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Coffee>().ToList();
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
            using (var reader = new StreamReader(addInsFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<AddIn>().ToList();
            }
        }

        public void UpdateAddIn(AddIn updateaddIn)
        {
            var records = GetAddIns();
            var existingAdinType = records.Find(c => c.Id == updateaddIn.Id);

            if (existingAdinType != null)
            {
                existingAdinType.AddinName = updateaddIn.AddinName;
                existingAdinType.Price = updateaddIn.Price;

                WriteRecordsToFile(records);
            }
        }
        private void WriteRecordsToFile(List<AddIn> records)
        {
            using (var writer = new StreamWriter(addInsFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

    }
}
