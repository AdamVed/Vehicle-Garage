namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class TruckUI : VehicleUI
    {
        public override void ShowData(Vehicle i_CurrVehicle)
        {
            Console.WriteLine("Transporting hazardous materials: {0}", (i_CurrVehicle as Truck).IsHazardousMaterials);
            Console.WriteLine("Cargo volume: {0}", (i_CurrVehicle as Truck).CargoVolume);
            Console.WriteLine("Wheel's maximum air pressure: {0}", (i_CurrVehicle as Truck).Wheels[0].MaxAirPressure);
            Console.WriteLine("Fuel type: {0}", (i_CurrVehicle as Truck).FuelType);
            Console.WriteLine("Fuel capacity: {0} liters", (i_CurrVehicle as Truck).MaxFuelAmount);
            Console.WriteLine("Remaining amount of fuel: {0} liters", (i_CurrVehicle as Truck).CurrFuelAmount);
        }

        public override void GetUserData(Vehicle i_CurrVehicle)
        {
            string choice = null;
            bool isChoice = false;

            Console.WriteLine("Is transporting hazardous materials?");
            Console.WriteLine("1. yes");
            Console.WriteLine("2. no");

            while (isChoice == false)
            {
                choice = Console.ReadLine();

                if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 2))
                {
                    isChoice = true;
                }
            }

            ////yes or no
            switch (choice)
            {
                case "1":
                    (i_CurrVehicle as Truck).IsHazardousMaterials = true;
                    break;
                case "2":
                    (i_CurrVehicle as Truck).IsHazardousMaterials = false;
                    break;
            }

            Console.WriteLine("Enter cargo capacity: ");
            choice = Console.ReadLine();
            float cargoVolume = float.Parse(choice);
            (i_CurrVehicle as Truck).CargoVolume = cargoVolume;

            Console.WriteLine("Enter vehicle's current amount of fuel: ");
            string currFuelAmount = Console.ReadLine();

            try
            {
                bool isOverMax = i_CurrVehicle.OutOfRange(currFuelAmount, i_CurrVehicle);
                (i_CurrVehicle as Truck).CurrFuelAmount = float.Parse(currFuelAmount);
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

            string licenseNumber = (i_CurrVehicle as Truck).LicenseNumber;

            (i_CurrVehicle as Truck).ChargingVehicle(fuelAmount, fuelType); ///we call the specific method
        }
    }
}