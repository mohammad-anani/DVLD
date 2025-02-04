using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsDetain
    {
        public int id {  get; set; }
        public int licenseid { get; set; }
        public DateTime detaindate { get; set; }
        public double fees { get; set; }
        public int userid { get; set; }

        public bool isreleased { get; set; }

        public DateTime releasedate { get; set; }

        public int releasedbyuserid { get; set; }

        public int releaseappid { get; set; }

        public clsDetain()
        {

        }

        public clsDetain(int id,double fees)
        {
            this.id = id;
          
            this.fees = fees;

        }

        public bool AddDetain()
        {
          this.id=clsDetainData.Add(this.licenseid, this.detaindate,this.fees,this.userid);

            return this.id != -1;
        }

        public bool Release()
        {
            return clsDetainData.Release(this.id, this.releasedate,this.releasedbyuserid, this.releaseappid);
        }

        public static clsDetain FindID(int licenseid)
        {
            int id = -1;
            double fees = -1;
            if(clsDetainData.FindByLicense(licenseid,ref id,ref fees))
            {
                return new clsDetain(id,fees);

            }
            return new clsDetain();
        }
    }
}
