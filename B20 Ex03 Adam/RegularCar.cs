namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RegularCar : FuelVehicle
    {
        ////attributes
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        ///properties
        public eNumberOfDoors NumOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }

            set
            {
                this.m_NumberOfDoors = value;
            }
        }

        public eColor CarColor
        {
            get
            {
                return this.m_Color;
            }

            set
            {
                this.m_Color = value;
            }
        }

        ///constructor
        public RegularCar()
        {
            FuelType = FuelVehicle.eFuelType.Octan96;
            MaxFuelAmount = 60;

            for (int i = 0; i < 4; i++)
            {
                Wheels.Add(new Wheel());
                Wheels[i].MaxAirPressure = 32;
            }
        }
    }
}