namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FuelVehicle : Vehicle
    {
        ////attributes
        private float m_CurrFuelAmount;
        private float m_MaxFuelAmmount;
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        ////properties
        public eFuelType FuelType
        {
            get
            {
                return this.m_FuelType;
            }

            set
            {
                this.m_FuelType = value;
            }
        }

        public float CurrFuelAmount
        {
            get
            {
                return this.m_CurrFuelAmount;
            }

            set
            {
                this.m_CurrFuelAmount = value;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return this.m_MaxFuelAmmount;
            }

            set
            {
                this.m_MaxFuelAmmount = value;
            }
        }

        ////methods
        public override void ChargingVehicle(float amount, string fuelType)
        {
            bool isCorrect;
            string amountToAdd = amount.ToString();

            IsFuelTypeCorrect(fuelType, out isCorrect);

            if (isCorrect == true)
            {
                if (OutOfRange(amountToAdd, this) == true)
                {
                    throw new ValueOutOfRangeException(String.Format("Over maximum capacity"));
                }
                else
                {
                    this.CurrFuelAmount += amount;
                }
            }
            else
            {
                throw new ArgumentException(String.Format("Wrong fuel Type"));
            }
        }

        public void IsFuelTypeCorrect(string i_FuelType, out bool o_IsCorrect)
        {
            string correctFuelType;

            o_IsCorrect = false;
            correctFuelType = this.FuelType.ToString();

            if (correctFuelType == i_FuelType)
            {
                o_IsCorrect = true;
            }
        }
    }
}