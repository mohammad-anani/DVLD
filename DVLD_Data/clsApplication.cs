using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsApplication
    {
        public int id {  get; set; }
        public int personid { get; set; }
        public DateTime appdate { get; set; }
        public int apptypeid { get; set; }
        public int appstatusid { get; set; }
        public DateTime laststatusdate { get; set; }

        public double paidfees { get; set; }

        public int userid { get; set; }
    }
}
