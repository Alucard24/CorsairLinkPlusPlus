﻿using CorsairLinkPlusPlus.Common.Sensor;
using CorsairLinkPlusPlus.Driver.CorsairLink.Sensor;
using System.Text;

namespace CorsairLinkPlusPlus.Driver.CorsairLink
{
    public static class Core
    {
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        internal static byte GetRelativeThermistorByte(Sensor.BaseSensorDevice sensor, IThermistor thermistor)
        {
            if (thermistor == null)
                return 0;
            if (!(thermistor is Thermistor))
                return 7;
            Thermistor thermistorCast = (Thermistor)thermistor;
            return (byte)((sensor.device == thermistorCast.device) ? thermistorCast.id : 7);
        }

        internal static bool DoesThermistorNeedManualPush(Sensor.BaseSensorDevice sensor, IThermistor thermistor)
        {
            return GetRelativeThermistorByte(sensor, thermistor) == 7;
        }
    }
}
