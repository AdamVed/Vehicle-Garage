namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class RegularCarUI : VehicleUI
    {
        public override void ShowData(Vehicle i_CurrVehicle)
        {
            Console.WriteLine("Color: {0}", (i_CurrVehicle as RegularCar).CarColor);
            Console.WriteLine("Number of doors: {0}", (i_CurrVehicle as RegularCar).NumOfDoors);
            Console.WriteLine("Wheel's maximum air pressure: {0}", (i_CurrVehicle as RegularCar).Wheels[0].MaxAirPressure);
            Console.WriteLine("Fuel type: {0}", (i_CurrVehicle as RegularCar).FuelType);
            Console.WriteLine("Fuel capacity: {0} liters", (i_CurrVehicle as RegularCar).MaxFuelAmount);
            Console.WriteLine("Remaining amount of fuel: {0} liters", (i_CurrVehicle as RegularCar).CurrFuelAmount);
        }

        public override void GetUserData(Vehicle i_CurrVehicle)
        {
            string choice = null;
            bool isChoice = false;

            Console.WriteLine("Choose vehicle color: ");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. White");
            Console.WriteLine("3. Black");
            Console.WriteLine("4. Silver");

            while (isChoice == false)
            {
                choice = Console.ReadLine();

                if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 4))
                {
                    isChoice = true;
                }
            }

            ////vehicle colors
            switch (choice)
            {
                case "1":
                    (i_CurrVehicle as RegularCar).CarColor = RegularCar.eColor.Red;
                    break;
                case "2":
                    (i_CurrVehicle as RegularCar).CarColor = RegularCar.eColor.White;
                    break;
                case "3":
                    (i_CurrVehicle as RegularCar).CarColor = RegularCar.eColor.Black;
                    break;
                case "4":
                    (i_CurrVehicle as RegularCar).CarColor = RegularCar.eColor.Silver;
                    break;
            }

            isChoice = false;
            Console.Clear();

            Console.WriteLine("Choose number of doors: ");
            Console.WriteLine("1. Two");
            Console.WriteLine("2. Three");
            Console.WriteLine("3. Four");
            Console.WriteLine("4. Five");

            while (isChoice == false)
            {
                choice = Console.ReadLine();

                if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 4))
                {
                    isChoice = true;
                }
            }

            ////number of doors
            switch (choice)
            {
                case "1":
                    (i_CurrVehicle as RegularCar).NumOfDoors = RegularCar.eNumberOfDoors.Two;
                    break;
                case "2":
                    (i_CurrVehicle as RegularCar).NumOfDoors = RegularCar.eNumberOfDoors.Three;
                    break;
                case "3":
                    (i_CurrVehicle as RegularCar).NumOfDoors = RegularCar.eNumberOfDoors.Four;
                    break;
                case "4":
                    (i_CurrVehicle as RegularCar).NumOfDoors = RegularCar.eNumberOfDoors.Five;
                    break;
            }

            Console.Clear();

            Console.WriteLine("Enter vehicle's current amount of fuel: ");
            string currFuelAmount = Console.ReadLine();

            try
            {
                bool isOverMax = i_CurrVehicle.OutOfRange(currFuelAmount, i_CurrVehicle);
                (i_CurrVehicle as RegularCar).CurrFuelAmount = float.Parse(currFuelAmount);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter another input: ");
                currFuelAmount = Console.ReadLine();
            }
        }

        public override void RefillVehicle(Vehicle i_CurrVehicle)
        {
            string fuelType = null;
            float fuelAmount = 0;

            base.ForRefill(i_CurrVehicle, out fuelType, out fuelAmount);

            string licenseNumber = (i_CurrVehicle as RegularCar).LicenseNumber;

            (i_CurrVehicle as RegularCar).ChargingVehicle(fuelAmount, fuelType); ////Calls the specific method
        }
    }
}