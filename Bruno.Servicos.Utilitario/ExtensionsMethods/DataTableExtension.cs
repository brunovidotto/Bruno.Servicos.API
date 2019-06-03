using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace Bruno.Servicos.Utilitario.ExtensionsMethods
{
    public static class DataTableExtension
    {

        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            return table.AsEnumerable().ToList<T>();
        }

        public static IList<T> ToList<T>(this IEnumerable<DataRow> table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            return table.Select(row => CreateItemFromRow<T>(row, properties)).ToList();
        }

        public static T ConvertEntity<T>(this DataRow row) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            return CreateItemFromRow<T>(row, properties);

        }

        private static T CreateItemFromRow<T>(DataRow row, IEnumerable<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var attr = property.GetCustomAttributes(typeof(ColumnAttribute), true);
                if (attr.Length > 0)
                {
                    propName = ((ColumnAttribute)attr[0]).Name;
                }
                if (!row.Table.Columns.Contains(propName)) continue;
                if (row[propName] != DBNull.Value)
                    property.SetValue(item, row[propName], null);
            }
            return item;
        }
    }
}