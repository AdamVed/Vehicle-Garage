namespace Ex03.ConsoleUI
{
    using B20_Ex03_Adam;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ElectricMotorcycleUI : VehicleUI
    {
        public override void ShowData(Vehicle i_CurrVehicle)
        {
            Console.WriteLine("License type: {0}", (i_CurrVehicle as ElectricMotorcycle).License);
            Console.WriteLine("Engine capacity: {0} cc", (i_CurrVehicle as ElectricMotorcycle).EngineCapacity);
            Console.WriteLine("Wheel's maximum air pressure: {0}", (i_CurrVehicle as ElectricMotorcycle).Wheels[0].MaxAirPressure);
            Console.WriteLine("Battery time capacity: {0} hours", (i_CurrVehicle as ElectricMotorcycle).MaxBatteryTime);
            Console.WriteLine("Remaining battery time: {0} hours", (i_CurrVehicle as ElectricMotorcycle).RemainingBatteryTime);
        }

        public override void GetUserData(Vehicle i_CurrVehicle)
        {
            string choice = null;
            bool isChoice = false;

            Console.WriteLine("Choose license type: ");
            Console.WriteLine("1. A");
            Console.WriteLine("2. A1");
            Console.WriteLine("3. AA");
            Console.WriteLine("4. B");

            while (isChoice == false) 
            {
                choice = Console.ReadLine();

                if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 4))
                {
                    isChoice = true;
                }
            }

            ////license type
            switch (choice) 
            {
                case "1":
                    (i_CurrVehicle as ElectricMotorcycle).License = ElectricMotorcycle.eLicenseType.A;
                    break;
                case "2":
                    (i_CurrVehicle as ElectricMotorcycle).License = ElectricMotorcycle.eLicenseType.A1;
                    break;
                case "3":
                    (i_CurrVehicle as ElectricMotorcycle).License = ElectricMotorcycle.eLicenseType.AA;
                    break;
                case "4":
                    (i_CurrVehicle as ElectricMotorcycle).License = ElectricMotorcycle.eLicenseType.B;
                    break;
            }

            Console.WriteLine("Enter engine capacity: ");
            choice = Console.ReadLine();
            int engineCapacity = int.Parse(choice);
            (i_CurrVehicle as ElectricMotorcycle).EngineCapacity = engineCapacity;

            Console.WriteLine("Enter vehicle's remaining battery time: ");
            string currBatteryTime = Console.ReadLine();

            try
            {
                bool isOverMax = i_CurrVehicle.OutOfRange(currBatteryTime, i_CurrVehicle);
                (i_CurrVehicle as ElectricMotorcycle).RemainingBatteryTime = float.Parse(currBatteryTime);
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

            string licenseNumber = (i_CurrVehicle as ElectricMotorcycle).LicenseNumber;

            (i_CurrVehicle as ElectricMotorcycle).ChargingVehicle(chargingTime); ////Calls the specific method
        }
    }
}