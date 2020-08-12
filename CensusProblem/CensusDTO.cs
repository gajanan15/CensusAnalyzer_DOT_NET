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
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double housingDensity;
        public double populationDensity;

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

        public CensusDTO(USCensusCSV uSCensusCSV) {
            this.stateCode = uSCensusCSV.stateId;
            this.stateName = uSCensusCSV.stateName;
            this.population = uSCensusCSV.population;
            this.housingUnits = uSCensusCSV.housingUnits;
            this.totalArea = uSCensusCSV.totalArea;
            this.waterArea = uSCensusCSV.waterArea;
            this.landArea = uSCensusCSV.landArea;
            this.populationDensity = uSCensusCSV.populationDensity;
            this.housingDensity = uSCensusCSV.housingDensity;
        }
    }
}
