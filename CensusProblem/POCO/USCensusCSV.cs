using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem.POCO
{
   public class USCensusCSV
    {
        public string state;
        public long population;
        public long totalArea;
        public long populationDensity;

        public USCensusCSV(string state, string population, string totalArea, string populationDensity)
        {
            this.state = state;
            this.population =Convert.ToUInt32(population);
            this.totalArea = Convert.ToUInt32(totalArea);
            this.populationDensity = Convert.ToUInt32(populationDensity);
        }
    }
}
