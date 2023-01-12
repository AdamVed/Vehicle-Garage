namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ElectricMotorcycle : ElectricVehicle
    {
        ////attributes
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        ////constructor
        public ElectricMotorcycle()
        {
            MaxBatteryTime = 1.2f;

            for (int i = 0; i < 2; i++)
            {
                Wheels.Add(new Wheel());
                Wheels[i].MaxAirPressure = 30;
            }
        }

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        ////properties
        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }

            set
            {
                this.m_EngineCapacity = value;
            }
        }

        public eLicenseType License
        {
            get
            {
                return this.m_LicenseType;
            }

            set
            {
                this.m_LicenseType = value;
            }
        }
    }
}