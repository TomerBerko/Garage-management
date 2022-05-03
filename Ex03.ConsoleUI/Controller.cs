using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public class Controller
    {
        private readonly Garage r_Garage = new Garage();


        private UIClass m_UIClass = new UIClass();

        public Controller()
        {
        }

        public enum eUserChoice
        {
            InsertVehicleToGarage = 1,
            DisplayLicenseNumbers,
            ChangeVehicleStatus,
            InflateWheelstoMax,
            FillEnergySource,
            DisplayFullVehicleData,
            Exit,
        }

        public void Run()
        {
            bool exit = false;
            int choice;
            eUserChoice userChoiceOption = new eUserChoice();
            while (!exit)
            {
                try
                {
                    choice = m_UIClass.PrintMenuAndReturnChoice();
                    userChoiceOption = (eUserChoice)choice;

                    switch (userChoiceOption)
                    {
                        case eUserChoice.InsertVehicleToGarage:
                            Insert();
                            break;

                        case eUserChoice.DisplayLicenseNumbers:
                            DisplayLicenseNumbersInGarage();
                            break;
                       
                        case eUserChoice.ChangeVehicleStatus:
                            ChangeVehicleStatusInGarage();
                            break;
                       
                        case eUserChoice.InflateWheelstoMax:
                            InflateWheelsToMaximum();
                            break;
                        
                        case eUserChoice.FillEnergySource:
                            FillEnergySourceInGarage();
                            break;
                       
                        case eUserChoice.DisplayFullVehicleData:
                            DisplayFullVehicleDataInGarage();
                            break;
                       
                        case eUserChoice.Exit:
                            exit = true;
                            break;
                       
                        default:
                            m_UIClass.InvalidInputTryAgainMsg();
                            break;
                    }                    
                }
                catch (ArgumentException ae)
                {
                    m_UIClass.PrintToScreen(ae.Message);
                }
                catch (FormatException)
                {
                    m_UIClass.InvalidInputTryAgainMsg();
                }
                catch (OverflowException)
                {
                    m_UIClass.SomethingWentWrongMsg();
                }
            }
        }

        public void Insert()
        {
            bool isVehicleExists = true;
            string licenseNumber = null, modelName, wheelManufacturer, ownerName, ownerPhoneNumber;
            Vehicle newVehicle;

            try
            {
                m_UIClass.GetVehicleLicenseNumber(r_Garage, out licenseNumber);
            }
            catch (ArgumentException)
            {
                isVehicleExists = false;
            }

            if (isVehicleExists)
            {
                m_UIClass.VehicleAlreadyExsistsMsg();
                r_Garage.ChangeVehicleStatus(licenseNumber, VehicleStatusInGarage.eCurrentStatus.InWork);
            }
            else
            {
                modelName = m_UIClass.GetVehicleModelName();
                wheelManufacturer = m_UIClass.GetWheelManufacturer();
                newVehicle = CreateNewVehicle(licenseNumber, modelName, wheelManufacturer, out ownerName, out ownerPhoneNumber);
                r_Garage.InsertNewVehicleToWork(newVehicle, ownerName, ownerPhoneNumber);
            }
        }
         
        private void FillEnergySourceInGarage()
        {
            string licenseNumber;            
            FuelEngine.eFuelType fuelType;
            bool isValidFuelType = false;
            m_UIClass.GetVehicleLicenseNumber(r_Garage, out licenseNumber);
            FuelEngine fuelEngine = r_Garage.VehicleStatusInGarageList[licenseNumber].Vehicle.EnergyType as FuelEngine;
            if (fuelEngine != null) 
            {
                while (!isValidFuelType)
                {
                    try
                    {
                        fuelType = (FuelEngine.eFuelType)m_UIClass.GeteFuelType();
                        fuelEngine.FuelTypeCheck(fuelType);
                        isValidFuelType  = true;
                    }
                    catch (ArgumentException)
                    {
                        m_UIClass.PrintToScreen(string.Format(
    @"please enter another fuel type to try again"));
                    }
                }
            }

            InsertAmountOfEnergyToAdd(r_Garage.VehicleStatusInGarageList[licenseNumber].Vehicle);
        }

        private void DisplayLicenseNumbersInGarage()
        {
            int displayChoice;            
            displayChoice = m_UIClass.GetSLicenseDisplayOption();
            m_UIClass.PrintLicenseNumbers(displayChoice, r_Garage.VehicleStatusInGarageList);
        }

        private void InflateWheelsToMaximum()
        {
            string licenseNumber;

            m_UIClass.GetVehicleLicenseNumber(r_Garage, out licenseNumber);
            r_Garage.VehicleStatusInGarageList[licenseNumber].FillPSIToMaximum();
        }

        private Vehicle CreateNewVehicle(string i_LicenseNumber, string i_ModelName, string i_WheelManufacturer, out string o_OwnerName, out string o_OwnerPhone)
        {
            Vehicle newVehicle;
            Vehicle.eType vehicleType;            
            Engine.eEngineType vehicleEngineType;
            bool isUserInputValid = false;

            o_OwnerName = m_UIClass.GetOwnerName();
            while (!isUserInputValid)
            {
                if (r_Garage.IsOwnerNameValid(o_OwnerName))
                {
                    isUserInputValid = true;
                }
                else
                {
                    m_UIClass.InvalidInputTryAgainMsg();
                    o_OwnerName = m_UIClass.GetOwnerName();
                }
            }

            isUserInputValid = false;
            o_OwnerPhone = m_UIClass.GetOwnerPhone();
            while (!isUserInputValid)
            {
                if (r_Garage.IsPhoneNumberValid(o_OwnerPhone))
                {
                    isUserInputValid = true;
                }
                else
                {
                    m_UIClass.InvalidInputTryAgainMsg();
                    o_OwnerPhone = m_UIClass.GetOwnerPhone();
                }
            }
           
            vehicleType = (Vehicle.eType)m_UIClass.GetVehicle();
            if (vehicleType != Vehicle.eType.Truck)
            {
                vehicleEngineType = (Engine.eEngineType)m_UIClass.GetEngineType();
            }
            else
            {
                vehicleEngineType = Engine.eEngineType.FuelEngine;
            }

            newVehicle = Factory.CreateVehicle(vehicleType, vehicleEngineType, i_LicenseNumber, i_ModelName, i_WheelManufacturer);

            InsertVehicleDetails(newVehicle, vehicleType);

            return newVehicle;
        }
         
        private void InsertVehicleDetails(Vehicle i_NewVehicle, Vehicle.eType i_vehicleType)
        {
            switch (i_vehicleType)
            {
                case Vehicle.eType.Motorbike:
                    InsertLicenseType((Motorbike)i_NewVehicle);
                    InsertEngineCapacity((Motorbike)i_NewVehicle);
                    break;
                case Vehicle.eType.Car:
                    InsertColor((Car)i_NewVehicle);
                    InsertDoorsNumber((Car)i_NewVehicle);
                    break;
                case Vehicle.eType.Truck:
                    InsertIfCarriesToxics((Truck)i_NewVehicle);
                    InsertMaxCarryingWeight((Truck)i_NewVehicle);
                    break;
            }
           
            InsertCurrrentWheelsPSI(i_NewVehicle);
            InsertAmountOfEnergyToAdd(i_NewVehicle);
        }

        private void InsertAmountOfEnergyToAdd(Vehicle i_NewVehicle)
        {           
            float AmountOfEnergyToEnter;
            bool isInputValid = false;
            AmountOfEnergyToEnter = m_UIClass.GetAmountOfEnergyMsg();
            while (!isInputValid) 
            {
                try
                {
                    i_NewVehicle.EnergyType.Refueling(AmountOfEnergyToEnter);
                    isInputValid = true;
                }
                catch (FormatException)
                {
                    m_UIClass.InvalidInputTryAgainMsg();
                    AmountOfEnergyToEnter = m_UIClass.GetAmountOfEnergyMsg();
                }
                catch (ValueOutOfRangeException)
                {
                    m_UIClass.PrintToScreen(string.Format(
@"{0}
please enter the amount to add again",
i_NewVehicle.EnergyType.OutOfTankRangeMsg()));
                    AmountOfEnergyToEnter = m_UIClass.GetAmountOfEnergyMsg();
                }
            }       
            
            i_NewVehicle.EnergyQuantityUpdate();
        }
         
        private void InsertMaxCarryingWeight(Truck i_Truck)
        {
            float maxCarrying;
            maxCarrying = m_UIClass.GetMaxCarryingWeight();
            i_Truck.MaxCarryingWeight = maxCarrying;
        }
         
        private void InsertIfCarriesToxics(Truck i_Truck)
        {
            bool isCarriesToxics = false;
            isCarriesToxics  = m_UIClass.GetIsCarriesToxics();
            i_Truck.IsCarriesToxics = isCarriesToxics;
        }
         
        private void InsertDoorsNumber(Car i_NewCar)
        {
            Car.eDoorsNumber userChoice;
            userChoice = (Car.eDoorsNumber)m_UIClass.GetDoorsNumber();
            i_NewCar.DoorsNumber = userChoice;
        }
         
        private void InsertColor(Car i_NewCar)
        {
            Car.eCarColor color;
            color = (Car.eCarColor)m_UIClass.GetCarColor();  
            i_NewCar.CarColor = (Car.eCarColor)color;
        }

        private void InsertEngineCapacity(Motorbike i_NewMotorbike)
        {
            float engineCapacity;
            engineCapacity = m_UIClass.GetEngineCapacity();
            i_NewMotorbike.EngineCapacity = engineCapacity;
        }

        private void InsertLicenseType(Motorbike i_NewMotorbike)
        {
            Motorbike.eLicenseCategories licenseType;
            licenseType = (Motorbike.eLicenseCategories)m_UIClass.GetLicenseType();
            i_NewMotorbike.LicenseCategories = licenseType;
        }

        private void InsertCurrrentWheelsPSI(Vehicle i_NewVehicle)
        {
            bool isValid = false;
            float psiToAdd;

            psiToAdd = m_UIClass.GetWheelsPSI();
            while (!isValid) 
            {
                try
                {
                    foreach (Wheel currentWheel in i_NewVehicle.Wheels)
                    {
                        currentWheel.FillPSI(psiToAdd, currentWheel);
                    }

                    isValid = true;
                }
                catch (ValueOutOfRangeException)
                {
 m_UIClass.PrintToScreen(string.Format(
 @"Maximum PSI to fill {0}
Please try again",
i_NewVehicle.Wheels[0].MaxPSI));
                    psiToAdd = m_UIClass.GetWheelsPSI();
                }
            }            
        }
       
        private void ChangeVehicleStatusInGarage()
        {
            string licenseNumber;
            VehicleStatusInGarage.eCurrentStatus chosenStatus;
            m_UIClass.GetVehicleLicenseNumber(r_Garage, out licenseNumber);
            chosenStatus = (VehicleStatusInGarage.eCurrentStatus)m_UIClass.GetChosenStatusInput();
            r_Garage.VehicleStatusInGarageList[licenseNumber].CurrentStatus = chosenStatus;
        }

        private void DisplayFullVehicleDataInGarage()
        {
            string licenseNumber;
            m_UIClass.GetVehicleLicenseNumber(r_Garage, out licenseNumber);
            m_UIClass.PrintFullVehicleData(r_Garage.VehicleStatusInGarageList[licenseNumber].ToString());
        }
    }
}
