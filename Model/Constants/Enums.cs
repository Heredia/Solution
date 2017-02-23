using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Constants
{
    public class Enums
    {
        public object Status = ToDictionary<Status>();

        private static Dictionary<object, object> ToDictionary<T>() where T : struct
        {
            var values = Enum.GetValues(typeof(T));

            return values.Cast<object>().ToDictionary<object, object, object>(value => value.ToString(), value => (int)value);
        }
    }
}