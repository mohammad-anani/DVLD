using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data;

namespace DVLD_Business
{
    public class GenerateScript
    {

        public static void GenerateScriptDB() {
            GenerateDatabase.GenerateScript();
        }
    }
}
