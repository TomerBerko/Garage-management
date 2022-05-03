using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public enum eMaxPSI
        {
            Motorbike = 30,
            Car = 32,
            Truck = 26
        }

        private readonly string r_Manufacturer;
        private readonly float r_MaxPSI;
        private float m_CurrentPSI = 0;

        public Wheel(string i_Manufacturer,float i_CurrentPSI, float i_MaxPSI)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentPSI = i_CurrentPSI;
            r_MaxPSI = i_MaxPSI;
        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public float CurrentPSI
        {
            get
            {
                return m_CurrentPSI;
            }

            set
            {
                m_CurrentPSI = value;
            }
        }

        public float MaxPSI
        {
            get
            {
                return r_MaxPSI;
            }
        }

        public void FillPSI(float psiNeedToBeAdded, Wheel i_CurrentWheel)
        {
            if (i_CurrentWheel.CurrentPSI + psiNeedToBeAdded > MaxPSI || i_CurrentWheel.CurrentPSI + psiNeedToBeAdded < 0)
            {
                throw new ValueOutOfRangeException(0, MaxPSI);
            }
            else
            {
                i_CurrentWheel.CurrentPSI = i_CurrentWheel.CurrentPSI + psiNeedToBeAdded;
            }
        }

        public override string ToString()
        {
            string currentStatus;
            currentStatus = string.Format(
@"Air pressure: {0}
Manufacturer: {1}",
m_CurrentPSI,
r_Manufacturer);
            return currentStatus;
        }
    }
}