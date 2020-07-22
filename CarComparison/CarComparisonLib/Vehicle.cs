using System;
using System.Collections;
using System.Collections.Generic;

namespace CarComparisonLib
{
    public class Vehicle
    {
        /*Vehicle
         * I am staring this test by making a Vehicle class. 
         * this will have a make, model, color, price, tcc, and mpg. 
         * all the properties that were listed for each of the cars in the car comparison text file.
         * I am doing this so that later, I can turn the text file into a list of objcets,
         * and use the properties in those objects to complete the functions
         * 
         * I am using an IComparable interface because this will make it simple to compare the cars later on
         */

        //here you see the the properties of the cars
        public string Make;
        public string Model;
        public string Color;
        public int Year;
        public int Price;
        public float TCC;
        public int HwyMPG;

        /*
         * the next three tiems are constructors.
         * I always try to include a null constructor in any class, 
         * because later on I may need the instance of that object 
         * without anything for its properties
         */
        public Vehicle() 
        {
            Make = "No Make";
            Model = "No Model";
        }

        public Vehicle(string mk, string md)
        {
            Make = mk;
            Model = md;
            Color = "Clear";
            Year = DateTime.Now.Year;
            Price = 0;
            TCC = 0;
            HwyMPG = 0;
        }

        public Vehicle(string mk, string md, string clr, int yr, int pc, float tcc, int mpg)
        {
            Make = mk;
            Model = md;
            Color = clr;
            Year = yr;
            Price = pc;
            TCC = tcc;
            HwyMPG = mpg;
        }

        public static IComparer<Vehicle> sortYearAsc()
        {
            //Calls Comparer
            return new sortYearAscHelper();
        }

        public static IComparer<Vehicle> sortYearDesc()
        {
            //Calls Comparer
            return new sortYearDescHelper();
        }

        public static IComparer<Vehicle> sortMakeModelAsc()
        {
            return new sortMakeModelAscHelper();
        }

        public static IComparer<Vehicle> sortMakeModelDesc()
        {
            return new sortMakeModelDescHelper();
        }

        public static IComparer<Vehicle> sortPriceAsc()
        {
            return new sortPriceAscHelper();
        }

        public static IComparer<Vehicle> sortPriceDesc()
        {
            return new sortPriceDescHelper();
        }

        public static IComparer<Vehicle> sortTCCAsc()
        {
            return new sortTCCAscHelper();
        }

        public static IComparer<Vehicle> sortTCCDesc()
        {
            return new sortTCCDescHelper();
        }

        public static IComparer<Vehicle> sortValueAsc()
        {
            return new sortValueAscHelper();
        }

        public static IComparer<Vehicle> sortValueDesc()
        {
            return new sortValueDescHelper(); 
        }

        /*
         * Various IComparer classes below and instances of those classes above, used later to sort Lists of Vehicles
         * I make an Ascending and a Descending version for each, because while this exercise calls for just one direction
         * a real application would need either one, and it's very simple to make. 
         */
        private class sortYearAscHelper : IComparer<Vehicle>
        {
            public sortYearAscHelper() { }

            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Year > v2.Year)
                    return 1;
                if (v1.Year < v2.Year)
                    return -1;
                else
                    return 0;
            }
        }

        private class sortYearDescHelper : IComparer<Vehicle>
        {
            public sortYearDescHelper() { }

            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Year < v2.Year)
                    return 1;
                if (v1.Year > v2.Year)
                    return -1;
                else
                    return 0;
            }
        }
        private class sortMakeModelAscHelper : IComparer<Vehicle>
        {
            public sortMakeModelAscHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Make == v2.Make)
                    return String.Compare(v1.Model, v2.Model);
                else
                    return String.Compare(v1.Make, v2.Make);
            }
        }
        private class sortMakeModelDescHelper : IComparer<Vehicle>
        {
            public sortMakeModelDescHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v2.Make == v1.Make)
                    return String.Compare(v2.Model, v1.Model);
                else
                    return String.Compare(v2.Make, v1.Make);
            }
        }
        private class sortPriceAscHelper : IComparer<Vehicle>
        {
            public sortPriceAscHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Price > v2.Price)
                    return 1;
                if (v1.Price < v2.Price)
                    return -1;
                else
                    return 0;
            }
        }
        private class sortPriceDescHelper : IComparer<Vehicle>
        {
            public sortPriceDescHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Price < v2.Price)
                    return 1;
                if (v1.Price > v2.Price)
                    return -1;
                else
                    return 0;
            }
        }

        private class sortTCCAscHelper : IComparer<Vehicle>
        {
            public sortTCCAscHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.TCC > v2.TCC)
                    return 1;
                if (v1.TCC < v2.TCC)
                    return -1;
                else
                    return 0;
            }
        }

        private class sortTCCDescHelper : IComparer<Vehicle>
        {
            public sortTCCDescHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.TCC < v2.TCC)
                    return 1;
                if (v1.TCC > v2.TCC)
                    return -1;
                else
                    return 0;
            }
        }


        private class sortValueAscHelper : IComparer<Vehicle>
        {
            public sortValueAscHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Price > v2.Price && v1.Year > v2.Year && v1.TCC > v2.TCC && v1.HwyMPG > v2.HwyMPG)
                    return 1;
                if (v1.Price < v2.Price && v1.Year < v2.Year && v1.TCC < v2.TCC && v1.HwyMPG < v2.HwyMPG)
                    return -1;
                else
                    return 0;
            }
        }

        private class sortValueDescHelper : IComparer<Vehicle>
        {
            public sortValueDescHelper() { }
            public int Compare(Vehicle x, Vehicle y)
            {
                Vehicle v1 = x;
                Vehicle v2 = y;
                if (v1.Price < v2.Price && v1.Year < v2.Year && v1.TCC < v2.TCC && v1.HwyMPG < v2.HwyMPG) 
                    return 1;
                if (v1.Price > v2.Price && v1.Year > v2.Year && v1.TCC > v2.TCC && v1.HwyMPG > v2.HwyMPG)
                    return -1;
                else
                    return 0;
            }
        }

    }
}
