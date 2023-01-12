namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ValueOutOfRangeException : Exception
    {
        ////attributes
        private float m_MaxValue;
        private float m_MinValue;

        ////properties
        public float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }

            set
            {
                this.m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return this.m_MinValue;
            }

            set
            {
                this.m_MinValue = value;
            }
        }

        ////constructor
        public ValueOutOfRangeException(string message) : base(string.Format("Value out of range! make sure you choose between 0 to your max capacity"))
        {

            m_MinValue = 0;
        }
    } 
}