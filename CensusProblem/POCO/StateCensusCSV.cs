using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem.POCO
{
   public class StateCensusCSV
    {
        public string stateName;
        public long population;
        public long area;
        public long density;
       
        public StateCensusCSV(string state, string population, string area, string density)
        {
            this.stateName = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
