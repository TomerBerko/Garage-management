using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Octan98 = 1,
            Octan96,
            Octan95,
            Soler,
        }

        public enum eMaxFuelTankSize
        {
            Motorbike = 6,
            Car = 45,
            Truck = 120,
        }

         
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            } 

            set
            {
                m_FuelType = value;
            }
        }

        public bool FuelTypeCheck(eFuelType fuelType)
        {
            bool isFuelTypeValid = false;
            if (fuelType != m_FuelType)
            {
                throw new ArgumentException(
                    string.Format(
                    "You enterd an improper fuel type, {0} insted of {1}",
                    fuelType,
                    m_FuelType));
            }

            isFuelTypeValid  = true;
            return isFuelTypeValid;
        }

        public void Fueling(float i_NumberOfLiters, eFuelType fuelType)
        {
            if (FuelTypeCheck(fuelType))
            {
                Refueling(i_NumberOfLiters);
            }
        }

        public override string OutOfTankRangeMsg()
        {
            string outOfTankRange;

            outOfTankRange = string.Format(
@"You have currently {0} liters in your fuel tank
Maximum liters you may fill in your fuel tank: {1}.",
CurrentEnergyQuantity,
MaxEnergyQuantity);
            return outOfTankRange;
        }

        public override string ToString()
        {
            string currentStats;
            currentStats = string.Format(
@"Fuel Type: {0}
Current fuel Quantity : {1}
Maximum fuel Quantity : {2}",
m_FuelType,
CurrentEnergyQuantity,
MaxEnergyQuantity);
            return currentStats;
        }
    }
}
