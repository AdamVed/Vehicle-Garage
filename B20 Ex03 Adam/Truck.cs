namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Truck : FuelVehicle
    {
        ////attributes
        private bool m_IsTransportingHazardousMaterials;
        private float m_CargoVolume;

        ////properties
        public bool IsHazardousMaterials
        {
            get
            {
                return this.m_IsTransportingHazardousMaterials;
            }

            set
            {
                this.m_IsTransportingHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }

            set
            {
                this.m_CargoVolume = value;
            }
        }

        ////constructor
        public Truck()
        {
            FuelType = FuelVehicle.eFuelType.Soler;
            MaxFuelAmount = 120;

            for (int i = 0; i < 16; i++)
            {
                Wheels.Add(new Wheel());
                Wheels[i].MaxAirPressure = 28;
            }
        }
    }
}