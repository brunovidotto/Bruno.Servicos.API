using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace Bruno.Servicos.Utilitario.ExtensionsMethods
{
    public static class DataReaderExtension
    {
        public static T ConvertedEntity<T>(this IDataReader dr) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            var returnObject = new T();

            for (var i = 0; i < dr.FieldCount; i++)
            {
                var colName = dr.GetName(i);
                var pInfo = properties.FirstOrDefault(p => p.GetCustomAttributes(typeof(ColumnAttribute), true).Length > 0 &&
                    ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute), true)[0]).Name == colName);

                if (pInfo == null) continue;

                var attr = pInfo.GetCustomAttributes(typeof(ColumnAttribute), true);

                var propName = ((ColumnAttribute)attr[0]).Name;
                var val = dr[propName];
                var isNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);

                if (val is DBNull)
                {
                    val = null;
                }
                else
                {
                    val = isNullable ? Convert.ChangeType(val, pInfo.PropertyType.BaseType == typeof(Enum) ? typeof(int) : Nullable.GetUnderlyingType(pInfo.PropertyType)) : Convert.ChangeType(val, pInfo.PropertyType.BaseType == typeof(Enum) ? typeof(int) : pInfo.PropertyType);
                }
                pInfo.SetValue(returnObject, val, null);
            }
            return returnObject;
        }

        public static T GetEntity<T>(this IDataReader dr) where T : new()
        {
            var objReturn = default(T);

            while (dr.Read())
            {
                objReturn = dr.ConvertedEntity<T>();
            }
            dr.Close();

            return objReturn;
        }

        public static IList<T> ToList<T>(this IDataReader dr) where T : new()
        {
            var objReturn = new List<T>();
            while (dr.Read())
            {

                var objAdd = dr.ConvertedEntity<T>();
                objReturn.Add(objAdd);

            }
            dr.Close();

            return objReturn;
        }
    }
}
