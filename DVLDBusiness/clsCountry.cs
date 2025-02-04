using DVLD_data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public static class clsCountry
    {
        public static DataTable GetCountriesList()
        {
            return clsCountryData.GetCountryList();
        }

        public static int FindIDByName(string name)
        {
            return clsCountryData.FindIDByName(name);
        }
    }
}
