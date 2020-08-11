using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem.POCO
{
   public class CensusDTO
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;

        public CensusDTO(StateCodeCSV stateCodeCSVDAO)
        {
            this.srNo = stateCodeCSVDAO.srNo;
            this.stateName = stateCodeCSVDAO.stateName;
            this.tin = stateCodeCSVDAO.tin;
            this.stateCode = stateCodeCSVDAO.stateCode;
        }

        public CensusDTO(StateCensusCSV censusCSV) {
            this.stateName = censusCSV.stateName;
            this.population = censusCSV.population;
            this.area = censusCSV.area;
            this.density = censusCSV.density;
        }
    }
}
