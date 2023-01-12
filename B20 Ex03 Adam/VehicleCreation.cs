namespace B20_Ex03_Adam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VehicleCreation ////Class that creates the object of the vehicles
    {
        ////attributes
        private List<string> m_AvailableVehicles = new List<string> { "Regular Car", "Regular Motorcycle", "Electric Motorcycle", "Electric Car", "Truck" };

        ////properties
        public List<string> AvailableVehicles
        {
            get
            {
                return this.m_AvailableVehicles;
            }
        }

        ////methods
        public object CreateVehicle(string vehicleName)
        {
            object temp;

            switch (vehicleName)
            {
                case "Regular Car":
                    temp = new RegularCar();
                    break;
                case "Regular Motorcycle":
                    temp = new RegularMotorcycle();
                    break;
                case "Truck":
                    temp = new Truck();
                    break;
                case "Electric Car":
                    temp = new ElectricCar();
                    break;
                case "Electric Motorcycle":
                    temp = new ElectricMotorcycle();
                    break;
                default:
                    temp = null;
                    break;
            }

            return temp;
        }

        public void VehicleInput(Vehicle i_Vehicle, string i_LicenseNumber, string i_Model, string i_EnergyPercent, string i_Name, string i_PhoneNumber)
        {
            i_Vehicle.LicenseNumber = i_LicenseNumber;
            i_Vehicle.ModelName = i_Model;
            i_Vehicle.RemainingEnergyPercent = float.Parse(i_EnergyPercent);
        }

        public void WheelInput(Vehicle i_Vehicle, int i_WheelIndex, string i_CurrAirPressure, string i_ManufecturerName)
        {
            i_Vehicle.Wheels[i_WheelIndex].CurrAirPressure = float.Parse(i_CurrAirPressure);
            i_Vehicle.Wheels[i_WheelIndex].ManufacturerName = i_ManufecturerName;
        }
    }
}