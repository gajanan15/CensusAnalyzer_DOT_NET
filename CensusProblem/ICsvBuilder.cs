using CensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
   public interface ICsvBuilder
    {
        public Dictionary<string,CensusDTO> LoadCensusData(string filePath, string dataHeader);
    }
}
