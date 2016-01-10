using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_GUI_Layer.Entities
{
    public struct CityData
    {
        public CityData(int intValue, string strValue)
        {
            IntegerData = intValue;
            StringData = strValue;
        }

        public int IntegerData { get; private set; }
        public string StringData { get; private set; }
    }
}