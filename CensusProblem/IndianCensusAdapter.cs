using CensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusProblem
{
    class IndianCensusAdapter : CensusAdapter
    {
        string[] data;
        public Dictionary<string, CensusDTO> censusDictionary;
        public Dictionary<string, CensusDTO> LoadCensusData(string filePath, string dataHeader)
        {
            censusDictionary = new Dictionary<string, CensusDTO>();

            data = LoadData(filePath, dataHeader);

            foreach (string delimiter in data.Skip(1))
            {

                if (!delimiter.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }

                string[] column = delimiter.Split(",");

                if (filePath.Contains("IndiaStateCensusData"))
                {
                    censusDictionary.Add(column[0], new CensusDTO(new StateCensusCSV(column[0], column[1], column[2], column[3])));
                }
                if (filePath.Contains("IndiaStateCode"))
                {
                    censusDictionary.Add(column[1], new CensusDTO(new StateCodeCSV(column[0], column[1], column[2], column[3])));
                }
            }

            return censusDictionary;

        }
    }
}
