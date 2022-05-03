using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eType
        {
            Motorbike = 1,
            Car,
            Truck,
        }

        private readonly Engine r_EnergyType;
        private readonly string r_LicenseNumber;
        private readonly string r_ModelMame;
        private List<Wheel> m_Wheels;
        private float m_EnergyQuantity;

        public Vehicle(string i_LisenceNumber, string i_ModelName, Engine.eEngineType i_EngineType)
        {
            r_ModelMame = i_ModelName;
            r_LicenseNumber = i_LisenceNumber;
            m_Wheels = new List<Wheel>();

            if (i_EngineType == Engine.eEngineType.FuelEngine)
            {
                r_EnergyType = new FuelEngine();
            }
            else
            {
                r_EnergyType = new ElectricalEngine();
            }
        }

        public void EnergyQuantityUpdate()
        {
            EnergyQuantity = EnergyType.CurrentEnergyQuantity;
        }

        public abstract void InitializeEnergyType();

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelMame;
            }
        }

        public float EnergyQuantity
        {
            get
            {
                return m_EnergyQuantity;
            }

            set
            {
                m_EnergyQuantity = value;
            }
        }

        public Engine EnergyType
        {
            get
            {
                return r_EnergyType;
            }
        }

        public string VehicleStats()
        {
            string vehicleDetails;
            vehicleDetails = string.Format(
@"Vehicel model name: {0}
Vehicel license number: {1}

Wheels info: 
{2}

Engine info: 
{3}",
ModelName,
LicenseNumber,
m_Wheels[0].ToString(),
r_EnergyType.ToString());
            return vehicleDetails;
        }

        public abstract override string ToString();
    }
}
