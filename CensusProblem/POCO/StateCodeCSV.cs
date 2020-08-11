using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem.POCO
{
   public class StateCodeCSV
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeCSV(string srNo, string stateName, string tin, string stateCode)
        {
            this.srNo = (int)Convert.ToUInt32(srNo);
            this.stateName = stateName;
            this.tin = (int)Convert.ToUInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
