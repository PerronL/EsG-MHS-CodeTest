using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarComparisonLib
{
    public class CarCompare
    {
        List<Vehicle> Vehicles;
        public CarCompare()
        {
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle v)
        {
            Vehicles.Add(v);
        }

        public Vehicle StringToVehicle(string input)
        {
            Vehicle output = new Vehicle();
            return output;
        }


        //Sorts by the year in ascending or descending order
        public List<Vehicle> VehiclesByYear(bool asc)
        {
            if (asc)
                Vehicles.Sort(Vehicle.sortYearAsc());
            else
                Vehicles.Sort(Vehicle.sortYearDesc());
            return Vehicles;
        }

        //Sorts by the Make name, then the model name, in ascending or descending order
        public List<Vehicle> VehiclesAlphabetized(bool asc)
        {
            if(asc)
                Vehicles.Sort(Vehicle.sortMakeModelAsc());
            else
                Vehicles.Sort(Vehicle.sortMakeModelDesc());
            return Vehicles;
        }

        //Sorts by Price, in ascending or descending order
        public List<Vehicle> VehiclesByPrice(bool asc)
        {
            if(asc)
                Vehicles.Sort(Vehicle.sortPriceAsc());
            else
                Vehicles.Sort(Vehicle.sortPriceDesc());
            return Vehicles;
        }

        //Sorts by Best value, in ascending or descending value
        public List<Vehicle> VehiclesBestValue(bool asc)
        {
            if (asc)
                Vehicles.Sort(Vehicle.sortTCCAsc());
            else
                Vehicles.Sort(Vehicle.sortTCCDesc());
            return Vehicles;
        }

        //returns List of vehicles and their fuel consumption for a given distince
        public Dictionary<Vehicle, double> FuelConsumption(double dist)
        {
            Dictionary<Vehicle, double> dict = new Dictionary<Vehicle, double>();
            foreach(Vehicle v in Vehicles)
            {
                dict.Add(v, 0f);
                dict[v] = Math.Round((dist/v.HwyMPG), 3);
            }

            return dict;
        }

        //returns a random vehicle in the list
        public Vehicle RandomVehicle()
        {
            Random random = new Random();
            int listMax = Vehicles.Count();
            return Vehicles[random.Next(listMax)];
        }

        //returns the avarage MPG of all the cars in the given year
        // in other terms, the total sum of the MPG of each car make/model with the given year, divided by the count of car make/models with the given year
        public float AverageMPGByYear(int year)
        {
            int TotalMPG = 0;
            int CountMM = 0;
            foreach(Vehicle v in Vehicles)
            {
                if(v.Year == year)
                {
                    TotalMPG += v.HwyMPG;
                    CountMM++;
                }
            }
            if(CountMM > 0)
                return (TotalMPG / CountMM);
            else
                return 0;
        }
    }
}
