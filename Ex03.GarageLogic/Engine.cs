using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            FuelEngine = 1,
            ElectircalEngine,
        }

        private float m_CurrentEnergtQuantity;
        private float m_MaxEnergyQuantity;

        public float CurrentEnergyQuantity
        {
            get
            {
                return m_CurrentEnergtQuantity;
            }

            set
            {
                m_CurrentEnergtQuantity = value;
            }
        }

        public float MaxEnergyQuantity
        {
            get
            {
                return m_MaxEnergyQuantity;
            }

            set
            {
                m_MaxEnergyQuantity = value;
            }
        }

        public void Refueling(float i_FuelQuantity)
        {
            if (m_CurrentEnergtQuantity + i_FuelQuantity > m_MaxEnergyQuantity || m_CurrentEnergtQuantity + i_FuelQuantity < 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyQuantity);
            }

            m_CurrentEnergtQuantity = m_CurrentEnergtQuantity + i_FuelQuantity;
        }

        public abstract string OutOfTankRangeMsg();

        public abstract override string ToString();
    }
}
