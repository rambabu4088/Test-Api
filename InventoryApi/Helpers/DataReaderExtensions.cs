using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InventoryApi.Helpers
{
    public static class DataReaderExtensions
    {
        public static List<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var enities = new List<T>();
                var proDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                proDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                while (dr.Read())
                {
                    T newobject = new T();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (proDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = proDict[dr.GetName(index).ToUpper()];
                            if (info != null && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                info.SetValue(newobject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    enities.Add(newobject);
                }
                return enities;
            }
            return null;
        }
    }
}
