using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Adam
{
    public class ElectricVehicle : Vehicle
    {
        ////attributes
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        ////properties
        public float RemainingBatteryTime
        {
            get
            {
                return this.m_RemainingBatteryTime;
            }

            set
            {
                this.m_RemainingBatteryTime = value;
            }
        }

        public float MaxBatteryTime
        {
            get
            {
                return this.m_MaxBatteryTime;
            }

            set
            {
                this.m_MaxBatteryTime = value;
            }
        }

        ////methods
        public override void ChargingVehicle(float amount, string fuelType = null)
        {
            string amountToAdd = amount.ToString();

            if (OutOfRange(amountToAdd, this) == true)
            {
                throw new ValueOutOfRangeException(string.Format("Over maximum capacity"));
            }
            else
            {
                this.RemainingBatteryTime += amount;
            }
        }
    }
}