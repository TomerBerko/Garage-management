using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleStatusInGarage> m_VehicleStatusInGarage = new Dictionary<string, VehicleStatusInGarage>();

        public Dictionary<string, VehicleStatusInGarage> VehicleStatusInGarageList
        {
            get
            {
                return m_VehicleStatusInGarage;
            }
        }

        public void ChangeVehicleStatus(string i_LicensePlate, VehicleStatusInGarage.eCurrentStatus i_newStatus)
        {
            m_VehicleStatusInGarage[i_LicensePlate].CurrentStatus = i_newStatus;
        }

        public void InsertNewVehicleToWork(Vehicle i_NewVehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleStatusInGarage newVehicleInGarageToAdd = new VehicleStatusInGarage(i_OwnerName, i_OwnerPhoneNumber, i_NewVehicle);

            m_VehicleStatusInGarage.Add(i_NewVehicle.LicenseNumber, newVehicleInGarageToAdd);
        }

        public void IsVehicleExists(string input)
        {
            if (m_VehicleStatusInGarage.ContainsKey(input) == false)
            {
                throw new ArgumentException(
                    string.Format(
@"Vehicle with license number: {0} doesn't exists in the garage
",
                    input));
            }
        }
         
        public bool IsOwnerNameValid(string i_OwnerName)
        {
            bool isUserInputValid = true;
            for (int i = 0; i < i_OwnerName.Length; i++)
            { 
                if (!((i_OwnerName[i] >= 'a' && i_OwnerName[i] <= 'z') || (i_OwnerName[i] >= 'A' && i_OwnerName[i] <= 'Z') || i_OwnerName[i] == ' '))
                {
                    isUserInputValid = false;
                }
            }
            return isUserInputValid;
        }
         
        public bool IsPhoneNumberValid(string i_OwnerName)
        {
            bool isUserInputValid = true;
            for (int i = 0; i < i_OwnerName.Length; i++)
            {
                if (!(i_OwnerName[i] >= '1' && i_OwnerName[i] <= '9'))
                {
                    isUserInputValid = false;
                }
            }
            return isUserInputValid;
        }
    }
}