namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class ElectricCarUI : VehicleUI
    {
        public override void ShowData(Vehicle i_CurrVehicle)
        {
            Console.WriteLine("Color: {0}", (i_CurrVehicle as ElectricCar).CarColor);
            Console.WriteLine("Number of doors: {0}", (i_CurrVehicle as ElectricCar).NumOfDoors);
            Console.WriteLine("Wheel's maximum air pressure: {0}", (i_CurrVehicle as ElectricCar).Wheels[0].MaxAirPressure);
            Console.WriteLine("Battery time capacity: {0} hours", (i_CurrVehicle as ElectricCar).MaxBatteryTime);
            Console.WriteLine("Remaining battery time: {0} hours", (i_CurrVehicle as ElectricCar).RemainingBatteryTime);
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
                    (i_CurrVehicle as ElectricCar).CarColor = ElectricCar.eColor.Red;
                    break;
                case "2":
                    (i_CurrVehicle as ElectricCar).CarColor = ElectricCar.eColor.White;
                    break;
                case "3":
                    (i_CurrVehicle as ElectricCar).CarColor = ElectricCar.eColor.Black;
                    break;
                case "4":
                    (i_CurrVehicle as ElectricCar).CarColor = ElectricCar.eColor.Silver;
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
                    (i_CurrVehicle as ElectricCar).NumOfDoors = ElectricCar.eNumberOfDoors.Two;
                    break;
                case "2":
                    (i_CurrVehicle as ElectricCar).NumOfDoors = ElectricCar.eNumberOfDoors.Three;
                    break;
                case "3":
                    (i_CurrVehicle as ElectricCar).NumOfDoors = ElectricCar.eNumberOfDoors.Four;
                    break;
                case "4":
                    (i_CurrVehicle as ElectricCar).NumOfDoors = ElectricCar.eNumberOfDoors.Five;
                    break;
            }

            Console.Clear();

            Console.WriteLine("Enter vehicle's remaining battery time: ");
            string currBatteryTime = Console.ReadLine();

            try
            {
                bool isOverMax = i_CurrVehicle.OutOfRange(currBatteryTime, i_CurrVehicle);
                (i_CurrVehicle as ElectricCar).RemainingBatteryTime = float.Parse(currBatteryTime);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter another input: ");
                currBatteryTime = Console.ReadLine();
            }
        }

        public override void RefillVehicle(Vehicle i_CurrVehicle)
        {
            float chargingTime = 0;

            base.ForCharging(i_CurrVehicle, out chargingTime);

            string licenseNumber = (i_CurrVehicle as ElectricCar).LicenseNumber;

            (i_CurrVehicle as ElectricCar).ChargingVehicle(chargingTime); ////Calls the specific method
        }
    } 
}