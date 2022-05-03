using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly short r_NumOfWheels = 4;
        private readonly float r_MaxElectricalCapacity = 3.2f;

        public enum eDoorsNumber
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }

        private eDoorsNumber m_DoorsNumber;
        private eCarColor m_CarColor;
        
        public Car(string i_ModelName, string i_LicenseNumber,  Engine.eEngineType i_eEngineType, string i_WheelManufacturer) : base(i_LicenseNumber, i_ModelName, i_eEngineType)
        {
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer,0, (float)Wheel.eMaxPSI.Car));
            }

            InitializeEnergyType();
        }

        public eDoorsNumber DoorsNumber
        {
            get
            {
                return m_DoorsNumber;
            }

            set
            {
                m_DoorsNumber = value;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public override void InitializeEnergyType()
        {
            if (this.EnergyType is FuelEngine)
            {
                ((FuelEngine)EnergyType).FuelType = FuelEngine.eFuelType.Octan95;
                EnergyType.MaxEnergyQuantity = (float)FuelEngine.eMaxFuelTankSize.Car;
            }
            else
            {
                EnergyType.MaxEnergyQuantity = r_MaxElectricalCapacity;
            }
        }

        public override string ToString()
        {
            string carStats;
            carStats = string.Format(
@"{0}
Door number: {1}
Car color: {2}",
VehicleStats(),
m_DoorsNumber.ToString(),
m_CarColor.ToString());
            return carStats;
        }
    }
}
