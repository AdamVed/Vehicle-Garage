namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using B20_Ex03_Adam;

    public class UserInterface
    {
        ////attributes
        private Dictionary<string, VehicleUI> m_VehicleType = new Dictionary<string, VehicleUI>();
        private Garage m_Garage = new Garage();

        ////properties
        public Garage Garage
        {
            get
            {
                return this.m_Garage;
            }

            set
            {
                this.m_Garage = value;
            }
        }

        public Dictionary<string, VehicleUI> VehicleType
        {
            get
            {
                return this.m_VehicleType;
            }

            set
            {
                this.m_VehicleType = value;
            }
        }

        ////methods
        public void GarageManagement()
        {
            string userInput;

            InitializeVehicleTypeDictionary();

        Entry: 
            Console.WriteLine("Please press the number of the wanted operation: {0}", System.Environment.NewLine);
            Console.WriteLine("1. Register a vehicle to the garage");
            Console.WriteLine("2. Display all registered vehicle licenses");
            Console.WriteLine("3. Change status of a vehicle");
            Console.WriteLine("4. Fill vehicle's wheels with air to the maximum");
            Console.WriteLine("5. Refill / recharge a vehicle");
            Console.WriteLine("6. Get full-information about a vehicle");
            Console.WriteLine();

            userInput = Console.ReadLine();

            if (userInput.Length != 1 || char.IsDigit(userInput[0]) == false || int.Parse(userInput) > 6 || int.Parse(userInput) < 1) 
            {
                Console.WriteLine("{0}Wrong input! Try again{0}", System.Environment.NewLine);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                goto Entry;
            }

            switch (userInput)
            {
                case "1":
                    RegisterVehicle();
                    goto Entry;
                case "2":
                    DisplayAllLisence();
                    goto Entry;
                case "3":
                    ChangeVehicleStatus();
                    goto Entry;
                case "4":
                    FillMaxAir();
                    goto Entry;
                case "5":
                    RefillVehicle();
                    goto Entry;
                case "6":
                    ShowFullInformation();
                    goto Entry;
            }
        }

        ////methods
        public void PrintVehicleOptions(VehicleCreation create) 
        {
            for (int i = 0; i < create.AvailableVehicles.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, create.AvailableVehicles[i]);
            }
        }

        public void AddToDictionary(string i_Type, VehicleUI i_VehicleUi)
        {
            VehicleType.Add(i_Type, i_VehicleUi);
        }

        public void InitializeVehicleTypeDictionary() 
        {
            RegularCarUI regularCarUi = new RegularCarUI();
            RegularMotorcycleUI regularMotorcycleUi = new RegularMotorcycleUI();
            ElectricMotorcycleUI electricMotorcycleUi = new ElectricMotorcycleUI();
            ElectricCarUI electricCarUi = new ElectricCarUI();
            TruckUI truckUi = new TruckUI();

            AddToDictionary("Regular Car", regularCarUi); 
            AddToDictionary("RegularCar", regularCarUi);

            AddToDictionary("Regular Motorcycle", regularMotorcycleUi);
            AddToDictionary("RegularMotorcycle", regularMotorcycleUi);

            AddToDictionary("Electric Car", electricCarUi);
            AddToDictionary("ElectricCar", electricCarUi);

            AddToDictionary("Electric Motorcycle", electricMotorcycleUi);
            AddToDictionary("ElectricMotorcycle", electricMotorcycleUi);

            AddToDictionary("Truck", truckUi);
        }

        public VehicleUI GetVehicleUi(string i_Type) ////Gets vehicles's- UI object based by it's key (it's name)
        {
            return m_VehicleType[i_Type];
        }

        public void RegisterVehicle()
        {
            string vehicleName, choice = null, licenseNumber, model, energyPercent, name, phoneNumber, currAirPressure = null;
            int wheelNum = 0;
            bool isChoice = false, isInGarage = false, isCorrect = false, isAddingToGarage = true, isValid = false;
            VehicleUI vehicleUi = null;
            Vehicle vehicle = new Vehicle();
            VehicleCreation currVehicle = new VehicleCreation();
            Garage.ClientVehicle ourClient = new Garage.ClientVehicle();

            Console.Clear();

            Console.WriteLine("Enter vehicle's license number: ");
            licenseNumber = Console.ReadLine(); 

            while (isCorrect == false)
            {
                try
                {
                    int check = Garage.IntInputCheck(licenseNumber);
                    isCorrect = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input, only numbers are acceptable, choose another input: ");
                    licenseNumber = Console.ReadLine();
                }
            }

            isCorrect = false;
            bool isContinue = false;

            try
            {
                isInGarage = Garage.IsInGarage(licenseNumber, isAddingToGarage);
                isContinue = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Garage.Services.Vehicles[licenseNumber].VehicleCondition = Garage.ClientVehicle.VehicleConditions.InRepair; ////if the vehicle is already in -> 'in repair' status again
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            if (isContinue == true)
            {
                Console.Clear();

                while (isChoice == false)
                {
                    Console.WriteLine("Please choose your vehicle type: \n");
                    PrintVehicleOptions(currVehicle);

                    choice = Console.ReadLine();

                    if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > currVehicle.AvailableVehicles.Count))
                    {
                        isChoice = true;
                    }

                    Console.Clear();
                }

                Console.Clear();

                ////After we chose a vehicle type option
                vehicleName = currVehicle.AvailableVehicles[int.Parse(choice) - 1]; ////The type of car we have
                vehicle = currVehicle.CreateVehicle(vehicleName) as Vehicle; ////Gets the car object we created 

                ////User's input
                Console.WriteLine("Enter client's name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter client's phone number: ");
                phoneNumber = Console.ReadLine(); 

                while (isCorrect == false)
                {
                    try
                    {
                        float check = Garage.FloatInputCheck(phoneNumber);
                        isCorrect = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input, only numbers are acceptable, choose another input: ");
                        phoneNumber = Console.ReadLine();
                    }
                }

                isCorrect = false;

                Console.WriteLine("Enter vehicle's model: ");
                model = Console.ReadLine();

                Console.WriteLine("Enter vehicle's left energy percent: ");
                energyPercent = Console.ReadLine(); 

                while (isCorrect == false) 
                {
                    try
                    {
                        float check = Garage.FloatInputCheck(energyPercent);
                        isCorrect = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input, only numbers are acceptable, choose another input: ");
                        energyPercent = Console.ReadLine();
                    }
                }

                isCorrect = false;

                Console.WriteLine("Enter wheel's manufecturer name: ");
                string manufecturerName = Console.ReadLine();

                ////Current air pressure in each wheel
                for (int i = 0; i < vehicle.Wheels.Count; i++)
                {
                    Console.WriteLine("Enter wheel number {0}'s current air pressure", i + 1);
                    currAirPressure = Console.ReadLine();

                    while (isCorrect == false)
                    {
                        try
                        {
                            float check = Garage.FloatInputCheck(currAirPressure);
                            isCorrect = true;

                            while (isValid == false)
                            {
                                try
                                {
                                    bool isOverMax = vehicle.OutOfRange(currAirPressure, vehicle);
                                    isValid = true;
                                }
                                catch (ValueOutOfRangeException ex)
                                {
                                    Console.WriteLine("{0}", ex.Message);
                                    currAirPressure = Console.ReadLine();
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong input, only numbers are acceptable, choose another input: ");
                            currAirPressure = Console.ReadLine();
                        }
                    }

                    isCorrect = false;

                    wheelNum = i;

                    currVehicle.WheelInput(vehicle, wheelNum, currAirPressure, manufecturerName);
                }

                System.Threading.Thread.Sleep(1000);
                Console.Clear();

                ourClient.Client = new Client(); 
                
                ourClient.Vehicle = vehicle;
                ourClient.Client.ClientName = name;
                ourClient.Client.ClientPhoneNumber = phoneNumber; 

                currVehicle.VehicleInput(vehicle, licenseNumber, model, energyPercent, name, phoneNumber);

                vehicleUi = GetVehicleUi(vehicleName);
                vehicleUi.GetUserData(vehicle); 
                Garage.Services.AddVehicle(licenseNumber, ourClient); ////Adds the vehicle to the garage
                Console.WriteLine();
                Console.WriteLine("The vehicle was added to the garage");

                Garage.Services.Vehicles[licenseNumber].VehicleCondition = Garage.ClientVehicle.VehicleConditions.InRepair; ////If it's a new vehicle puts in  'in repair' status
            }
        }

        public void DisplayAllLisence()
        {
            bool isEmpty = false;
            string choice = null;

            try
            {
                isEmpty = Garage.IsGarageEmpty();

                Console.WriteLine("Do you want to order by vehicle's status? (yes / no)");
                choice = Console.ReadLine();

                while (choice != "yes" && choice != "Yes" && choice != "no" && choice != "No")
                {
                    choice = Console.ReadLine();
                }

                if (choice == "yes" || choice == "Yes")
                {
                    Console.Write("In Repair: ");
                    foreach (KeyValuePair<string, Garage.ClientVehicle> vehicle in Garage.Services.Vehicles)
                    {
                        if (vehicle.Value.VehicleCondition == Garage.ClientVehicle.VehicleConditions.InRepair)
                        {
                            Console.Write("{0} ", vehicle.Key);
                        }
                    }

                    Console.WriteLine();

                    Console.Write("Repaired: ");
                    foreach (KeyValuePair<string, Garage.ClientVehicle> vehicle in Garage.Services.Vehicles)
                    {
                        if (vehicle.Value.VehicleCondition == Garage.ClientVehicle.VehicleConditions.Repaired)
                        {
                            Console.Write("{0} ", vehicle.Key);
                        }
                    }

                    Console.WriteLine();

                    Console.Write("Paid: ");
                    foreach (KeyValuePair<string, Garage.ClientVehicle> vehicle in Garage.Services.Vehicles)
                    {
                        if (vehicle.Value.VehicleCondition == Garage.ClientVehicle.VehicleConditions.Paid)
                        {
                            Console.Write("{0} ", vehicle.Key);
                        }
                    }
                }
                else
                {
                    if (choice == "no" || choice == "No")
                    {
                        Console.WriteLine("License numbers of the vehicles in the garage: ");

                        foreach (KeyValuePair<string, Garage.ClientVehicle> vehicle in Garage.Services.Vehicles)
                        {
                            Console.Write("{0} ", vehicle.Key);
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }

            System.Threading.Thread.Sleep(5000);
            Console.Clear();
        }

        public void ShowFullInformation()
        {
            string licenseNumber = null, vehicleType = null;
            bool isInGarage = false;

            Console.WriteLine("Enter a license number: ");
            licenseNumber = Console.ReadLine();

            ////Checks if the vehicle is in the garage
            foreach (KeyValuePair<string, Garage.ClientVehicle> clientVehicle in Garage.Services.Vehicles) 
            {
                if (clientVehicle.Key.Contains(licenseNumber))
                {
                    isInGarage = true;
                }
            }

            if (isInGarage == true)
            {
                if (Garage.Services.Vehicles.ContainsKey(licenseNumber))
                {
                    vehicleType = (Garage.Services.Vehicles[licenseNumber]).Vehicle.GetType().Name; ////For example - RegularCar
                }

                if (VehicleType.ContainsKey(vehicleType))
                {
                    VehicleType[vehicleType].ShowData(Garage.Services.Vehicles[licenseNumber].Vehicle);
                }

                foreach (KeyValuePair<string, Garage.ClientVehicle> clientVehicle in Garage.Services.Vehicles)
                {
                    if (clientVehicle.Key.Contains(licenseNumber))
                    {
                        Console.WriteLine("License number: {0}", clientVehicle.Key);
                        Console.WriteLine("Client's name: {0}", clientVehicle.Value.Client.ClientName);
                        Console.WriteLine("Client's phone number: {0}", clientVehicle.Value.Client.ClientPhoneNumber);
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vehicle's model: {0}", clientVehicle.Value.Vehicle.ModelName);
                        Console.WriteLine("Remaining energy percent: {0}%", clientVehicle.Value.Vehicle.RemainingEnergyPercent);
                        Console.WriteLine("Number of wheels: {0}", clientVehicle.Value.Vehicle.Wheels.Count);
                        Console.WriteLine("Current wheel's air pressure: ");
                        for (int i = 0; i < clientVehicle.Value.Vehicle.Wheels.Count; i++)
                        {
                            Console.WriteLine("Wheel number {0}: {1}", i + 1, clientVehicle.Value.Vehicle.Wheels[i].CurrAirPressure);
                        }

                        Console.WriteLine("Wheel's manufecturer name: {0}", clientVehicle.Value.Vehicle.Wheels[0].ManufacturerName);
                        Console.WriteLine("Vehicle's condition: {0}", clientVehicle.Value.VehicleCondition);
                    }
                }
            }
            else
            {
                Console.WriteLine("This vehicle isn't in the garage");
            }

            System.Threading.Thread.Sleep(6000);
            Console.Clear();
        }

        public void FillMaxAir()
        {
            bool isInGarage = false, isAddingToGarage = false;

            try
            {
                bool isGarageEmpty = Garage.IsGarageEmpty();

                Console.WriteLine("Enter a license number: ");
                string licenseNumber = Console.ReadLine();

                try
                {
                    isInGarage = Garage.IsInGarage(licenseNumber, isAddingToGarage);

                    Garage.Services.WheelBlowingToMax(licenseNumber);
                }
                catch (ArgumentException exp)
                {
                    Console.WriteLine("{0}", exp.Message);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public void ChangeVehicleStatus()
        {
            string licenseNumber, choice = null, condition = null;
            bool isInGarage = false, isChoice = false, isAddingToGarage = false;

            try
            {
                bool isEmpty = Garage.IsGarageEmpty();

                Console.WriteLine("Enter license number: ");
                licenseNumber = Console.ReadLine();

                try
                {
                    isInGarage = Garage.IsInGarage(licenseNumber, isAddingToGarage);

                    Console.WriteLine("Choose the new vehicle's condition: ");
                    Console.WriteLine("1. InRepair");
                    Console.WriteLine("2. Repaired");
                    Console.WriteLine("3. Paid");

                    while (isChoice == false)
                    {
                        choice = Console.ReadLine();

                        if (!(choice.Length != 1 || char.IsDigit(choice[0]) == false || int.Parse(choice) < 1 || int.Parse(choice) > 3))
                        {
                            isChoice = true;
                        }
                    }

                    ///Vehical's status
                    switch (choice)
                    {
                        case "1":
                            condition = "InRepair";
                            break;
                        case "2":
                            condition = "Repaired";
                            break;
                        case "3":
                            condition = "Paid";
                            break;
                    }

                    Garage.Services.ChangeVehicleCondition(licenseNumber, condition);
                }
                catch (ArgumentException exp)
                {
                    Console.WriteLine("{0}", exp.Message);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public void RefillVehicle()
        {
            string licenseNumber;
            bool isInGarage = false, isAddingToGarage = false;

            try
            {
                bool isEmpty = Garage.IsGarageEmpty();

                Console.WriteLine("Enter license number: ");
                licenseNumber = Console.ReadLine();

                try
                {
                    isInGarage = Garage.IsInGarage(licenseNumber, isAddingToGarage);

                    VehicleUI vehicleUi = GetVehicleUi(Garage.Services.Vehicles[licenseNumber].Vehicle.GetType().Name);
                    vehicleUi.RefillVehicle(Garage.Services.Vehicles[licenseNumber].Vehicle);
                }
                catch (ArgumentException exp)
                {
                    Console.WriteLine("{0}", exp.Message);
                }
                catch (ValueOutOfRangeException exp)
                {
                    Console.WriteLine("{0}", exp.Message);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}