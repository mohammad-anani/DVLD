using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTest
    {
        public int id {  get; set; }

        public int testappid { get; set; }

        public bool result { get; set; }

        public string notes { get; set; }

        public int userid { get; set; }


        public clsTest(int  id, int testappid, bool result,string notes,int userid)
        {
            this.id = id;
            this.testappid = testappid;
            this.result = result;
            this.notes = notes;
            this.userid = userid;

        }

        public clsTest()
        {
           
        }

        public bool AddTest()
        {
            this.id=clsTestData.AddTest(this.testappid,this.result,this.notes,this.userid);

            return this.id != -1;
        }


    }
}
