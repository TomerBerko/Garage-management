using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIClass
    {
        public UIClass()
        {
        }

        public int PrintMenuAndReturnChoice()
        {
            int userChoice = 0;
            bool isUserChoiceValid = false;
            string menu = string.Format(@"Please select the service you would like to do:
 1. Insert a new vehicle to the garage
 2. Display a list of license numbers currently in the garage
 3. Change a certain vehicle’s status
 4. Inflate tires to maximum
 5. Refuel energy
 6. Display vehicle information
 7. Exit the garage");
            Console.WriteLine(menu);
            while (isUserChoiceValid == false)
            {
                userChoice = int.Parse(Console.ReadLine()); 
                if (userChoice < 1 || userChoice > 7)
                {
                    Console.WriteLine("invalid input try again");
                }
                else
                {
                    isUserChoiceValid = true;
                }
            }

            return userChoice;
        }
         
        public void GetVehicleLicenseNumber(Garage i_Garage, out string i_LicenseNumber)
        {
            do
            {
                Console.WriteLine("->Insert vehicle license number");
                i_LicenseNumber = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(i_LicenseNumber));
            i_Garage.IsVehicleExists(i_LicenseNumber);
        }

        public void VehicleAlreadyExsistsMsg()
        {
            Console.WriteLine("The vehicle exsits in the system, his status changed to in work");
        }

        public string GetVehicleModelName()
        {
            string vehicleModelName;
            
            Console.WriteLine("->Insert vehicle model name");
            vehicleModelName = Console.ReadLine();
            while (vehicleModelName == null)
            {
                Console.WriteLine("invalid input try again");
                vehicleModelName = Console.ReadLine();
            }
           
            return vehicleModelName;
        }

        public string GetWheelManufacturer()
        {
            string input;

            Console.WriteLine("->Insert wheel manufacturer model name");
            input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("invalid input try again");
                input = Console.ReadLine();
            }

            return input;
        }

        public string GetOwnerName()
        {
            string ownerName;

                Console.WriteLine("->Insert owner full name");
                ownerName = Console.ReadLine();
            while (ownerName == null)
            {
                Console.WriteLine("invalid input try again");
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        public void SomethingWentWrongMsg()
        {
            Console.WriteLine("Something went wrong, try a smaller input");
        }

         public string GetOwnerPhone()
        {
            string input;

            Console.WriteLine("->Insert Phone number ");
            input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("invalid input try again");
                input = Console.ReadLine();
            }

            return input;
        }

        public void PrintFullVehicleData(string i_FullData)
        {
            Console.WriteLine(i_FullData);
        }

        public int GetVehicle()
        {
            int returnValue;
            string printchoice = string.Format
(@"Please select vehicle type (insert the associated number)
1.Motorbike
2.Car
3.Truck ");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 3)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public int GetEngineType()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select engine type (insert the associated number)
1.Fuel Engine
2.Electrical Engine ");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 2)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public int GetLicenseType()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select license type (insert the associated number)
1.A
2.AA
3.B1
4.BB");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 4)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public float GetEngineCapacity()
        {
            float returnValue;
            string printchoice = string.Format(@"Please enter engine capacity number)");
            Console.WriteLine(printchoice);
            returnValue = float.Parse(Console.ReadLine());
            return returnValue;
        }

        public int GetDoorsNumber()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select number of doors type (insert the associated number)
1.2
2.3
3.4
4.5");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 4)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public float GetAmountOfEnergyMsg()
        {
            float returnAmountOfEnergy;
            string printChoice = string.Format(@"Please enter Amount Of Energy number)");
            Console.WriteLine(printChoice);
            returnAmountOfEnergy = float.Parse(Console.ReadLine());
            return returnAmountOfEnergy;
        }

        public int GetCarColor()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select the car color (insert the associated number)
1.Red
2.Silver
3.White
4.Black ");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 4)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public void PrintToScreen(string i_StringToPrint)
           {
                Console.WriteLine(i_StringToPrint);
           }
        
        public bool GetIsCarriesToxics()
        {
            bool returnAnswer = false;
            int userAnswer;
            string printChoice = string.Format(@"Please select if truck carries toxic (insert the associated number)
1.yes
2.no ");
            Console.WriteLine(printChoice);
            userAnswer = int.Parse(Console.ReadLine());
            while (userAnswer < 1 || userAnswer > 2)
            {
                Console.WriteLine("invalid input try again");
                userAnswer = int.Parse(Console.ReadLine());
            }

            if (userAnswer == 1)
            {
                returnAnswer = true;
            }
            else
            {
                returnAnswer = false;
            }

            return returnAnswer;
        }

        public float GetMaxCarryingWeight()
        {
            float returnMaxCarry;
            string printchoice = string.Format(@"Please enter max carrying weight number)");
            Console.WriteLine(printchoice);
            returnMaxCarry = float.Parse(Console.ReadLine());
            
            return returnMaxCarry;
        }

        public float GetWheelsPSI()
        {
            float returnWheelsPSI;
            string printChoice = string.Format(@"Please enter wheels PSI number)");
            Console.WriteLine(printChoice);
            returnWheelsPSI = float.Parse(Console.ReadLine());

            return returnWheelsPSI;
        }

        public int GeteFuelType()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select Fuel type (insert the associated number)
1.Octan98
2.Octan96
3.Octan95
4.Soler");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 4)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public void InvalidInputTryAgainMsg()
        {
            Console.WriteLine("Invalid input, try again");
        }

        public void PrintLicenseNumbers(int i_UserChoice, Dictionary<string, VehicleStatusInGarage> i_Garage)
        {
            bool isUserChoiceIsAll = false;
            VehicleStatusInGarage.eCurrentStatus userChoice = VehicleStatusInGarage.eCurrentStatus.Fixed;
            if (i_UserChoice == 4)
            {
                isUserChoiceIsAll = true;
            }
            else
            {
                userChoice = (VehicleStatusInGarage.eCurrentStatus)i_UserChoice;
            }

            foreach (VehicleStatusInGarage current in i_Garage.Values)
            {
                if (current.CurrentStatus == userChoice || isUserChoiceIsAll)
                {
                    Console.WriteLine(current.Vehicle.LicenseNumber);
                }
            }
        }

        public int GetSLicenseDisplayOption()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select license display option (insert the associated number)
1.InWork
2.Fixed
3.Paid
4.AllVehicls");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 4)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }

        public int GetChosenStatusInput()
        {
            int returnValue;
            string printchoice = string.Format(@"Please select the new Status (insert the associated number)
1.InWork
2.Fixed
3.Paid");
            Console.WriteLine(printchoice);
            returnValue = int.Parse(Console.ReadLine());
            while (returnValue < 1 || returnValue > 3)
            {
                Console.WriteLine("invalid input try again");
                returnValue = int.Parse(Console.ReadLine());
            }

            return returnValue;
        }
    }   
}
