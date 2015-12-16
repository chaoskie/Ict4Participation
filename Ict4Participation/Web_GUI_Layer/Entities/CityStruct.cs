using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_GUI_Layer.Entities
{
    public struct CityStruct
    {
        public string Name;
        public decimal Percentage;

        public CityStruct(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }
}