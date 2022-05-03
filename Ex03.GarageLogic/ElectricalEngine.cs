using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricalEngine : Engine
    {
        
        public override string OutOfTankRangeMsg()
        {
            string outOfTankRange;

            outOfTankRange = string.Format(
@"You have currently {0} hours left on your battery
Maximum battery capacity : {1} hour/s.",
CurrentEnergyQuantity,
MaxEnergyQuantity);
            return outOfTankRange;
        }

        public override string ToString()
        {
            string currentStats;
            currentStats = string.Format(
@"Current battery hours left : {0}
Maximum battery capacity: {1} hour/s",
CurrentEnergyQuantity,
MaxEnergyQuantity);
            return currentStats;
        }
    }
}
