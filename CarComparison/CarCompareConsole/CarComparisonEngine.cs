using System;
using System.Collections.Generic;
using System.Text;
using CarComparisonLib;
using NUnit.Framework;

namespace CarCompareConsole
{
    
    public class CarComparisonEngine
    {
        CarCompare CarCompare;
        public bool CloseWindow = false;
        /*Using the given data
        Make Model       Color Year    Price TCC Rating Hwy MPG
Honda       CRV Green 	2016 	$23,845		8				33
Ford Escape      Red 	2017 	$23,590		7.8				32
Hyundai Sante Fe Grey 	2016 	$24,950		8				27
Mazda CX-5 		Red 	2017 	$21,795		8				35
Subaru Forester    Blue	2016 	$22,395		8.4				32
        */

        public CarComparisonEngine() 
        {
            CarCompare = new CarCompare();
            CloseWindow = false;
            CarCompare.AddVehicle(new Vehicle("Honda", "CRV", "Green", 2016, 23845, 8f, 33));
            CarCompare.AddVehicle(new Vehicle("Ford", "Escape", "Red", 2017, 23590, 7.8f, 32));
            CarCompare.AddVehicle(new Vehicle("Hyundai", "Santa Fe", "Grey", 2016, 24950, 8f, 27));
            CarCompare.AddVehicle(new Vehicle("Madza", "CX-5", "Red", 2017, 21795, 8f, 35));
            CarCompare.AddVehicle(new Vehicle("Subaru", "Forester", "Blue", 2016, 22395, 8.4f, 32));
        }
        public CarComparisonEngine(CarCompare cc)
        {
            CarCompare = cc;
            CloseWindow = false;
            CarCompare.AddVehicle(new Vehicle("Honda", "CRV", "Green", 2016, 23845, 8f, 33));
            CarCompare.AddVehicle(new Vehicle("Ford", "Escape", "Red", 2017, 23590, 7.8f, 32));
            CarCompare.AddVehicle(new Vehicle("Hyundai", "Santa Fe", "Grey", 2016, 24950, 8f, 27));
            CarCompare.AddVehicle(new Vehicle("Madza", "CX-5", "Red", 2017, 21795, 8f, 35));
            CarCompare.AddVehicle(new Vehicle("Subaru", "Forester", "Blue", 2016, 22395, 8.4f, 32));
        }

        public void PlayerInput(string funcNum)
        {

            switch (funcNum.ToLower())
            {
                case "1":
                    Console.WriteLine("Below is a list of vehicles ordered by year: ");
                    Console.WriteLine(VehiclesByYear());
                    break;
                case "2":
                    Console.WriteLine("Below is a list of vehicles Alphabetized by Make and then by Model");
                    Console.WriteLine(VehiclesByMakeModel());
                    break;
                case "3":
                    Console.WriteLine("Below is a list of vehicles ordered by Price");
                    Console.WriteLine(VehiclesByPrice());
                    break;
                case "4":
                    Console.WriteLine("Below is a list of vehicles ordered by value");
                    Console.WriteLine(VehiclesByValue());
                    break;
                case "5":
                    Console.WriteLine("Please enter the Distance");
                    Console.WriteLine();
                    double distance = 0;
                    if (double.TryParse(Console.ReadLine(), out distance))
                    {
                        Console.WriteLine(VehiclesFuelConsumption(distance));
                    }
                    else
                    {
                        Console.WriteLine("This may not be a number. Please try again.");
                        Console.WriteLine();
                        PlayerInput("5");
                    }
                    break;
                case "6":
                    Console.WriteLine("Below is a random car from the list of cars");
                    Console.WriteLine(VehicleRandom());
                    break;
                case "7":
                    Console.WriteLine("Please enter a year");
                    Console.WriteLine();
                    int year = 0;
                    if (int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine(VehicleAverageMPG(year));
                    }
                    else
                    {
                        Console.WriteLine("This may not be a Year. Please try again.");
                        Console.WriteLine();
                        PlayerInput("7");
                    }
                    break;
                case "x":
                    Console.WriteLine("Hope you had fun!");
                    CloseWindow = true;
                    break;
                default:
                    Console.WriteLine("NoFunction");
                    break;
            }
        }

        public string VehiclesByYear()
        {
            List<Vehicle> cars = CarCompare.VehiclesByYear(true);
            string output = "";
            foreach (Vehicle v in cars)
            {
                if (output.Length > 0)
                    output += ", \n\r";
                output += string.Format("{0}:{1} ({2})", v.Make, v.Model, v.Year.ToString());
            }
            return output;
        }

        public string VehiclesByMakeModel()
        {
            List<Vehicle> cars = CarCompare.VehiclesAlphabetized(true);
            string output = "";
            foreach (Vehicle v in cars)
            {
                if (output.Length > 0)
                    output += ", \n\r";
                output += string.Format("{0}:{1}", v.Make, v.Model);
            }
            return output;   
        }

        public string VehiclesByPrice()
        {
            List<Vehicle> cars = CarCompare.VehiclesByPrice(true);
            string output = "";
            foreach (Vehicle v in cars)
            {
                if (output.Length > 0)
                    output += ", \n\r";
                output += string.Format("{0}:{1}(${2})", v.Make, v.Model, v.Price.ToString());
            }
            return output;
        }

        public string VehiclesByValue()
        {
            List<Vehicle> cars = CarCompare.VehiclesBestValue(true);
            string output = "";
            foreach (Vehicle v in cars)
            {
                if (output.Length > 0)
                    output += ", \n\r";
                output += string.Format("{0}:{1}({2})", v.Make, v.Model, v.TCC.ToString());
            }
            return output;
        }

        public string VehiclesFuelConsumption(double dist)
        {
            Dictionary<Vehicle, double> consumption = CarCompare.FuelConsumption(dist);
            string output = "";
            foreach(KeyValuePair<Vehicle, double> kvp in consumption)
            {
                if (output.Length > 0)
                    output += ", \n\r";
                output += string.Format("{0}:{1} ({2}% Gallons)", kvp.Key.Make, kvp.Key.Model, kvp.Value);
            }

            return output;
        }

        public string VehicleRandom()
        {
            Vehicle v = CarCompare.RandomVehicle();
            return string.Format("{0}:{1} ({2})", v.Make, v.Model, v.Year.ToString());
        }

        public string VehicleAverageMPG(int year)
        {
            
            return string.Format("The average MPG for cars in year {0} is {1}.", year.ToString(), CarCompare.AverageMPGByYear(year).ToString());
        }
    }
}
