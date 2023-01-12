namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Client
    {
        ////attributes
        private string m_ClientName;
        private string m_ClientPhoneNumber;
        private Vehicle m_ClientVehicle;

        ////properties
        public string ClientName
        {
            get
            {
                return this.m_ClientName;
            }

            set
            {
                this.m_ClientName = value;
            }
        }

        public string ClientPhoneNumber
        {
            get
            {
                return m_ClientPhoneNumber;
            }

            set
            {
                this.m_ClientPhoneNumber = value;
            }
        }

        public Vehicle ClientVehicle
        {
            get
            {
                return this.m_ClientVehicle;
            }

            set
            {
                this.m_ClientVehicle = value;
            }
        }
    }
}