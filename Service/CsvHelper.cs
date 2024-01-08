using Coursework1.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using CsvHelper;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace Coursework1.Service
{
    internal class MyCsvHelper : ICsvHelper 
    {
        public  List<User> ReadUsersFromCsv()
        {
            List<User> users;

            // Path to the CSV file relative to your project directory
            string csvFilePath = Path.Combine("C:\\Abhi Mud\\Coursework1\\Data\\user_credentials.csv");

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                users = csv.GetRecords<User>().ToList();
            }

            return users;
        }

        //// Method to write users to the CSV file
        //public static void WriteUsersToCsv(List<User> users)
        //{
        //    using (var writer = new StreamWriter(CsvFilePath))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(users);
        //    }
        //}
    }
}
