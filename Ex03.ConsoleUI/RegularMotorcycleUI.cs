namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class RegularMotorcycleUI : VehicleUI
    {
        public override void ShowData(Vehicle i_CurrVehicle)
        {
            Console.WriteLine("License type: {0}", (i_CurrVehicle as RegularMotorcycle).License);
            Console.WriteLine("Engine capacity: {0} cc", (i_CurrVehicle as RegularMotorcycle).EngineCapacity);
            Console.WriteLine("Wheel's maximum air pressure: {0}", (i_CurrVehicle as RegularMotorcycle).Wheels[0].MaxAirPressure);
            Console.WriteLine("Fuel type: {0}", (i_CurrVehicle as RegularMotorcycle).FuelType);
            Console.WriteLine("Fuel capacity: {0} liters", (i_CurrVehicle as RegularMotorcycle).MaxFuelAmount);
            Console.WriteLine("Remaining amount of fuel: {0} liters", (i_CurrVehicle as RegularMotorcycle).CurrFuelAmount);
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
                    (i_CurrVehicle as RegularMotorcycle).License = RegularMotorcycle.eLicenseType.A;
                    break;
                case "2":
                    (i_CurrVehicle as RegularMotorcycle).License = RegularMotorcycle.eLicenseType.A1;
                    break;
                case "3":
                    (i_CurrVehicle as RegularMotorcycle).License = RegularMotorcycle.eLicenseType.AA;
                    break;
                case "4":
                    (i_CurrVehicle as RegularMotorcycle).License = RegularMotorcycle.eLicenseType.B;
                    break;
            }

            Console.WriteLine("Enter engine capacity: ");
            choice = Console.ReadLine();
            int engineCapacity = int.Parse(choice);
            (i_CurrVehicle as RegularMotorcycle).EngineCapacity = engineCapacity;

            Console.WriteLine("Enter vehicle's current amount of fuel: ");
            string currFuelAmount = Console.ReadLine();

            try
            {
                bool isOverMax = i_CurrVehicle.OutOfRange(currFuelAmount, i_CurrVehicle);
                (i_CurrVehicle as RegularMotorcycle).CurrFuelAmount = float.Parse(currFuelAmount);
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
            bool isCorrect = false;

            base.ForRefill(i_CurrVehicle, out fuelType, out fuelAmount);

            string licenseNumber = (i_CurrVehicle as RegularMotorcycle).LicenseNumber;

            while (isCorrect == false)
            {
                try
                {
                    (i_CurrVehicle as RegularMotorcycle).ChargingVehicle(fuelAmount, fuelType); ////Calls  the specific filling method
                    isCorrect = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                    base.ForRefill(i_CurrVehicle, out fuelType, out fuelAmount);
                }
            }
        }
    }
}