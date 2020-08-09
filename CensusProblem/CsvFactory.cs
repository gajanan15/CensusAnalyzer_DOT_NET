using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
    public class CsvFactory
    {
        public ICsvBuilder getClassObject() {
            return new CensusAnalyzer();
        }
    }
}
