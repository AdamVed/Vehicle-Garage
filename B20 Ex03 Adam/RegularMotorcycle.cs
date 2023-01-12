namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RegularMotorcycle : FuelVehicle
    {
        ////attributes
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        ////properties
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

        ////constructor
        public RegularMotorcycle()
        {
            FuelType = FuelVehicle.eFuelType.Octan95;
            MaxFuelAmount = 7;

            for (int i = 0; i < 2; i++)
            {
                Wheels.Add(new Wheel());
                Wheels[i].MaxAirPressure = 30;
            }
        }
    }
}