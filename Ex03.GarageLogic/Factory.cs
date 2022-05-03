using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        public static Vehicle CreateVehicle(
            Vehicle.eType i_VehicleType,
            Engine.eEngineType i_EngineType,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelManufacturer)
        {
            Vehicle result = null;

            switch (i_VehicleType)
            {
                case Vehicle.eType.Motorbike:
                    result = new Motorbike(i_ModelName, i_LicenseNumber, i_EngineType, i_WheelManufacturer);
                    break;

                case Vehicle.eType.Car:
                    result = new Car(i_ModelName, i_LicenseNumber, i_EngineType, i_WheelManufacturer);
                    break;

                case Vehicle.eType.Truck:
                    result = new Truck(i_ModelName, i_LicenseNumber, i_EngineType, i_WheelManufacturer);
                    break;
            }

            return result;
        }
    }
}