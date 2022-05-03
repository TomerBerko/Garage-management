using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleStatusInGarage
    {
        public enum eCurrentStatus
        {
            InWork = 1,
            Fixed,
            Paid,
        }

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eCurrentStatus m_CurrentStatus;
        private Vehicle m_Vehicle;

        public VehicleStatusInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_CurrentStatus = eCurrentStatus.InWork;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public eCurrentStatus CurrentStatus
        {
            get
            {
                return m_CurrentStatus;
            }

            set
            {
                m_CurrentStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder allData = new StringBuilder();
            string vehicleStats;
            vehicleStats = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Vehicle status in garage: {2}
",
m_OwnerName,
m_OwnerPhoneNumber,
m_CurrentStatus.ToString());
            allData.Append(vehicleStats);
            allData.Append(m_Vehicle.ToString());
            return allData.ToString();
        }

        public void FillPSIToMaximum()
        {
            float numberOfPsiToFill = 0;
            for (int i = 0; i < m_Vehicle.Wheels.Count; i++)
            {
                numberOfPsiToFill = m_Vehicle.Wheels[i].MaxPSI - m_Vehicle.Wheels[i].CurrentPSI;
                m_Vehicle.Wheels[i].FillPSI(numberOfPsiToFill, m_Vehicle.Wheels[i]);
            }
        }   
    }
}
