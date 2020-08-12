using CensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
    public class CensusAdapterFactory
    {
        public Dictionary<string,CensusDTO> GetCensusData(CensusAnalyzer.Country country,string filePath,string headers) {
            if (country.Equals(CensusAnalyzer.Country.INDIA))
                return new IndianCensusAdapter().LoadCensusData(filePath, headers);
            else if (country.Equals(CensusAnalyzer.Country.US))
                return new USCensusAdapter().LoadUSCensusData(filePath, headers);
            else
                throw new CensusAnalyserException("Incorrect Country", CensusAnalyserException.ExceptionType.INVALID_COUNTRY);
        }
    }
}
