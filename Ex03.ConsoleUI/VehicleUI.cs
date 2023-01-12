namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class VehicleUI
    {
        public virtual void ShowData(Vehicle i_CurrVehicle)
        {
        }

        public virtual void GetUserData(Vehicle i_CurrVehicle)
        {
        }

        public virtual void RefillVehicle(Vehicle i_CurrVehicle)
        {
        }

        public void ForRefill(Vehicle i_CurrVehicle, out string o_FuelType, out float o_FuelAmount)
        {
            string choice = null;
            bool isChoice = false;

            o_FuelType = null;
            o_FuelAmount = 0;

            Console.WriteLine("Choose fuel type to refill: ");
            Console.WriteLine("1. Octan98");
            Console.WriteLine("2. Octan96");
            Console.WriteLine("3. Octan95");
            Console.WriteLine("4. Soler");

            while (isChoice == false) 
            {
                choice = Console.ReadLine();

                if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 4))
                {
                    isChoice = true;
                }
            }

            ///Fuel type
            switch (choice)
            {
                case "1":
                    o_FuelType = "Octan98";
                    break;
                case "2":
                    o_FuelType = "Octan96";
                    break;
                case "3":
                    o_FuelType = "Octan95";
                    break;
                case "4":
                    o_FuelType = "Soler";
                    break;
            }

            Console.WriteLine("Choose the amount of fuel: ");
            choice = Console.ReadLine();
            o_FuelAmount = float.Parse(choice); ////We have the type and the amount of fuel
        }

        public void ForCharging(Vehicle i_CurrVehicle, out float o_ChargingTime)
        {
            string time;

            Console.WriteLine("Enter charging time: ");
            time = Console.ReadLine();
            o_ChargingTime = float.Parse(time);
        }
    }
}