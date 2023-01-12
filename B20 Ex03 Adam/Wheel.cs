namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wheel
    {
        ////attributes
        private string m_ManufacturerName;
        private float m_CurrAirPressure;
        private float m_MaxAirPressure;

        ////properties
        public string ManufacturerName
        {
            get
            {
                return this.m_ManufacturerName;
            }

            set
            {
                this.m_ManufacturerName = value;
            }
        }

        public float CurrAirPressure
        {
            get
            {
                return this.m_CurrAirPressure;
            }

            set
            {
                this.m_CurrAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }

            set
            {
                this.m_MaxAirPressure = value;
            }
        }

        ///// methods
        public void WheelBlowing(float i_AirAddition)
        {
            CurrAirPressure = CurrAirPressure + i_AirAddition;
        }
    }
}