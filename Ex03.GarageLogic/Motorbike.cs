using System;

namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        private readonly short r_NumOfWheels = 2;
        private readonly float r_MaxElectricalCapacity = 1.8f;
    
        public enum eLicenseCategories
        {
            A = 1,
            AA,
            B1,
            BB,
        }

        private eLicenseCategories m_LicenseCategories ;
        private float m_EngineCapacity;

        public Motorbike(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_eEngineType, string i_WheelManufacturer) : base(i_LicenseNumber, i_ModelName, i_eEngineType)
        {
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer, 0, (float)Wheel.eMaxPSI.Motorbike));
            }

            InitializeEnergyType();
        }

        public eLicenseCategories LicenseCategories
        {
            get
            {
                return m_LicenseCategories;
            }

            set
            {
                m_LicenseCategories = value;
            }
        }

        public float EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }

        public override void InitializeEnergyType()
        {
            if (this.EnergyType is FuelEngine)
            {
                ((FuelEngine)EnergyType).FuelType = FuelEngine.eFuelType.Octan98;
                EnergyType.MaxEnergyQuantity = (float)FuelEngine.eMaxFuelTankSize.Motorbike;
            }
            else
            {
                EnergyType.MaxEnergyQuantity = r_MaxElectricalCapacity;
            }
        }

        public override string ToString()
        {
            string bikeStats;
            bikeStats = string.Format(
@"{0}
License Category: {1}
Motorbike engine capacity: {2}",
VehicleStats(),
m_LicenseCategories.ToString(),
m_EngineCapacity.ToString());
            return bikeStats;
        }
    }
}
