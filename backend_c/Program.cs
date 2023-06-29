// // See https://aka.ms/new-console-template for more information
// decimal myD = 0.7131m;
// decimal myD2 = 0.7134m;
// Console.WriteLine(myD2 - myD);

// string[] arr = { "dly", "lallal" };
// string[] arr2 = new string[2];
// // Console.WriteLine(arr[0]);
// // Console.WriteLine(arr2[0]);

// for(int i = 0; i < arr.Length; i++){
//     Console.WriteLine(arr[i]);
// }

// List<string> list = new List<string>();
// list.Add("1");
// Console.WriteLine(list[0]);

// string[,] arr3 = new string[,] { { "1", "2" }, { "3", "4" } };
// Console.WriteLine(arr3[0, 1]);

// Dictionary<string, string> dict = new Dictionary<string, string>();
// dict.Add("1", "1");
// Console.WriteLine(dict["1"]);

// int in1 = 1;
// int in2 = 1;
// Console.WriteLine(in1 == in2);
// string st1 = "1";
// string st2 = "1";
// // in c#, string can be compared in ==
// Console.WriteLine(st1 == st2);
// string hi = null;
// Console.WriteLine(hi == null);

// string cow = "cow";
// string cow2 = "Cow";
// Console.WriteLine(cow.Equals(cow2, StringComparison.OrdinalIgnoreCase));
// bool result = false;
// result = cow == cow2 ? true : false;
// Console.WriteLine(result);

// // loop
// int[] ints = {1,2,3,4};
// foreach (int i in ints){
//     Console.WriteLine(i);
// }
using backend_c.models;
using backend_c.data;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;

namespace backend_c
{
    internal class Program
    {
        static void Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            Computer computer = new()
            {
                Motherboard = "John",
                CPUCores = 4,
                ReleaseDate = DateTime.Now,
                Price = 4.5m,
            };
            DapperContext dapperContext = new(configuration);
            string sql1 = @"INSERT INTO Computer (Motherboard, CPUCores, 
            ReleaseDate, Price) VALUES ('" + computer.Motherboard
             + "','" + computer.CPUCores
            + "','" + computer.ReleaseDate
            + "','" + computer.Price
            + "')";
            // dapperContext.Execute(sql1);
            // string sql2 = @"SELECT * FROM Computer;";
            // IEnumerable<Computer> result = dapperContext.QueryData<Computer>(sql2);
            // foreach (Computer myComputer in result)
            // {
            //     Console.WriteLine(myComputer.Motherboard);
            // }

            using StreamWriter sw = new("log.txt", append: true);
            sw.WriteLine(sql1);
            sw.Close();
            string[] value = File.ReadAllLines("log.txt");
            Console.WriteLine(value.Length);
            using StreamReader streamReader = new("log.txt");
            // ? can help hold a null value
            string? line = streamReader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = streamReader.ReadLine();
            }

            // read json to object, did underscore to camel mapping by jsonpropertyname
            string json = File.ReadAllText("test.json");
            IEnumerable<Computer>? computers = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(json);
            if (computers != null)
            {
                foreach (Computer item in computers)
                {
                    Console.WriteLine(item.Motherboard);
                }
            }


        }

    }

}