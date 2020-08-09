using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
   public interface ICsvBuilder
    {
        public object loadCensusData(string filePath, string dataHeader);
    }
}
