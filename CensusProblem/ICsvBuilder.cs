using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
   public interface ICsvBuilder
    {
        public object LoadCensusData(string filePath, string dataHeader);
    }
}
