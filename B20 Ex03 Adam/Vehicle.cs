namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vehicle
    {
        ////attributes
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercent;
        private List<Wheel> m_Wheels = new List<Wheel>();

        ////properties
        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float RemainingEnergyPercent
        {
            get
            {
                return m_RemainingEnergyPercent;
            }

            set
            {
                this.m_RemainingEnergyPercent = value;
            }
        }

        ////methods
        public virtual void ChargingVehicle(float amount, string fuelType)
        {

        }

        public bool OutOfRange(string i_Amount, Vehicle i_Vehicle)
        {
            float maxAirPressure, amount;
            bool isOutOfRange = false;

            maxAirPressure = i_Vehicle.Wheels[0].MaxAirPressure;
            amount = float.Parse(i_Amount);

            if (amount > maxAirPressure || amount < 0)
            {
                //isOutOfRange = true;
                throw new ValueOutOfRangeException("Out of range");
            }

            return isOutOfRange;
        }
    }
}