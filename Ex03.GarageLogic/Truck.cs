using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly int r_NumOfWheels = 16;
        private bool m_IsCarriesToxics = false;
        private float m_MaxCarryingWeight;

        public Truck(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_eEngineType, string i_WheelManufacturer) : base(i_LicenseNumber, i_ModelName, i_eEngineType)
        {
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer, 0, (float)Wheel.eMaxPSI.Truck));
            }

            InitializeEnergyType();
        } 

        public bool IsCarriesToxics
        {
            get
            {
                return m_IsCarriesToxics;
            }

            set
            {
                m_IsCarriesToxics = value;
            }
        }

        public float MaxCarryingWeight
        {
            get
            {
                return m_MaxCarryingWeight;
            }

            set
            {
                m_MaxCarryingWeight = value;
            }
        }

        public override void InitializeEnergyType()
        {
                ((FuelEngine)EnergyType).FuelType = FuelEngine.eFuelType.Soler;
                EnergyType.MaxEnergyQuantity = (float)FuelEngine.eMaxFuelTankSize.Truck;
        }

        public override string ToString()
        {
            string truckStats;

            truckStats = string.Format(
@"{0}
Is the truck carries toxics: {1}
Truckm max carrying weight: {2}",
VehicleStats(),
m_IsCarriesToxics,
m_MaxCarryingWeight);
            return truckStats;
        }
    }
}
