namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Garage
    {
        ////attributes
        private GarageServices m_services = new GarageServices();
        private ClientVehicle m_ClientVehicle = new ClientVehicle();

        ////properties
        public GarageServices Services
        {
            get
            {
                return this.m_services;
            }

            set
            {
                this.m_services = value;
            }
        }

        public ClientVehicle ClientVehicles
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

        ////methods
        public bool IsInGarage(string i_LicenseNumber, bool i_IsAddingToGarage)
        {
            bool isInGarage = false;

            if (i_IsAddingToGarage == true)
            {
                if (Services.Vehicles.ContainsKey(i_LicenseNumber))
                {
                    throw new ArgumentException(String.Format("Already in the garage, please add a non existing vehicle"));
                }
            }
            else
            {
                if (!(Services.Vehicles.ContainsKey(i_LicenseNumber)))
                {
                    throw new ArgumentException(String.Format("This vehicle isn't in the garage!"));
                }
            }

            return isInGarage;
        }

        public bool IsGarageEmpty()
        {
            bool isGarageEmpty = false;

            if (Services.Vehicles.Count == 0)
            {
                throw new ArgumentException(String.Format("The garage is empty! need to add a vehicle first"));
            }

            return isGarageEmpty;
        }

        public float FloatInputCheck(string i_UserInput)
        {
            float conversionToFloat = float.Parse(i_UserInput);

            return conversionToFloat;
        }

        public int IntInputCheck(string i_UserInput)
        {
            int conversionToFloat = int.Parse(i_UserInput);
            return conversionToFloat;
        }

        public class ClientVehicle ///Vehical + Vehicle's owner + Vehicle's condition
        {
            ////attributes
            private Client m_Client;
            private Vehicle m_Vehicle;
            private VehicleConditions m_VehicleCondition;

            public enum VehicleConditions
            {
                InRepair,
                Repaired,
                Paid
            }

            ////properties
            public VehicleConditions VehicleCondition
            {
                get
                {
                    return this.m_VehicleCondition;
                }

                set
                {
                    this.m_VehicleCondition = value;
                }
            }

            public Client Client
            {
                get
                {
                    return this.m_Client;
                }

                set
                {
                    this.m_Client = value;
                }
            }

            public Vehicle Vehicle
            {
                get
                {
                    return this.m_Vehicle;
                }

                set
                {
                    this.m_Vehicle = value;
                }
            }
        }

        public class GarageServices
        {
            ////attributes
            private Dictionary<string, ClientVehicle> m_Vehicles = new Dictionary<string, ClientVehicle>();

            ////properties
            public Dictionary<string, ClientVehicle> Vehicles
            {
                get
                {
                    return this.m_Vehicles;
                }

                set
                {
                    this.m_Vehicles = value;
                }
            }

            ////methods
            public void AddVehicle(string i_LisenceNumber, ClientVehicle i_CurrVehicle)
            {
                Vehicles.Add(i_LisenceNumber, i_CurrVehicle);
            }

            public void ChangeVehicleCondition(string i_LicenseNumber, string i_Condition)
            {
                if (i_Condition == "InRepair")
                {
                    Vehicles[i_LicenseNumber].VehicleCondition = ClientVehicle.VehicleConditions.InRepair;
                }
                else
                {
                    if (i_Condition == "Repaired")
                    {
                        Vehicles[i_LicenseNumber].VehicleCondition = ClientVehicle.VehicleConditions.Repaired;
                    }
                    else
                    {
                        if (i_Condition == "Paid")
                        {
                            Vehicles[i_LicenseNumber].VehicleCondition = ClientVehicle.VehicleConditions.Paid;
                        }
                    }
                }
            }

            public void WheelBlowingToMax(string i_LicenseNumber)
            {
                float currAirPressure, maxAirPressure, airAddition;

                maxAirPressure = Vehicles[i_LicenseNumber].Vehicle.Wheels[0].MaxAirPressure;

                ////Runs through all the wheels
                for (int i = 0; i < Vehicles[i_LicenseNumber].Vehicle.Wheels.Count; i++) 
                {
                    currAirPressure = Vehicles[i_LicenseNumber].Vehicle.Wheels[i].CurrAirPressure; ////Current wheel's air pressure
                    airAddition = maxAirPressure - currAirPressure;

                    Vehicles[i_LicenseNumber].Vehicle.Wheels[i].WheelBlowing(airAddition); ////Fills air to max
                }
            }
        }
    }
}