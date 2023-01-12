namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ElectricCar : ElectricVehicle
    {
        ////attributes
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        ////constructor
        public ElectricCar()
        {
            MaxBatteryTime = 2.1f;

            for (int i = 0; i < 4; i++)
            {
                Wheels.Add(new Wheel());
                Wheels[i].MaxAirPressure = 32;
            }
        }

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

        ////properties
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
    }
}