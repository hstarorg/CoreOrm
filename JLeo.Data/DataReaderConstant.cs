using System;
using System.Data;

namespace JLeo.Data
{
    public static class DataReaderConstant
    {
        public static bool GetBoolean(IDataReader reader, int ordinal)
        {
            return reader.GetBoolean(ordinal);
        }

        public static byte GetByte(IDataReader reader, int ordinal)
        {
            return reader.GetByte(ordinal);
        }

        public static char GetChar(IDataReader reader, int ordinal)
        {
            return reader.GetChar(ordinal);
        }

        public static DateTime GetDateTime(IDataReader reader, int ordinal)
        {
            return reader.GetDateTime(ordinal);
        }

        public static decimal GetDecimal(IDataReader reader, int ordinal)
        {
            return reader.GetDecimal(ordinal);
        }

        public static double GetDouble(IDataReader reader, int ordinal)
        {
            return reader.GetDouble(ordinal);
        }

        public static float GetFloat(IDataReader reader, int ordinal)
        {
            return reader.GetFloat(ordinal);
        }

        public static Guid GetGuid(IDataReader reader, int ordinal)
        {
            return reader.GetGuid(ordinal);
        }

        public static short GetInt16(IDataReader reader, int ordinal)
        {
            return reader.GetInt16(ordinal);
        }

        public static int GetInt32(IDataReader reader, int ordinal)
        {
            return reader.GetInt32(ordinal);
        }

        public static long GetInt64(IDataReader reader, int ordinal)
        {
            return reader.GetInt64(ordinal);
        }

        public static string GetString(IDataReader reader, int ordinal)
        {
            return reader.GetString(ordinal);
        }

        public static T GetEnum<T>(IDataReader reader, int ordinal) where T : struct
        {
            int value = reader.GetInt32(ordinal);
            T t = (T)Enum.ToObject(typeof(T), value);
            return t;
        }

        public static object GetValue(IDataReader reader, int ordinal)
        {
            object o = reader.GetValue(ordinal);
            if (o == DBNull.Value)
            {
                return null;
            }
            return o;
        }
    }
}
