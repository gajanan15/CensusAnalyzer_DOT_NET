using CensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusProblem
{
    class USCensusAdapter : CensusAdapter
    {
        string[] data;
        public Dictionary<string, CensusDTO> censusDictionary;
        public Dictionary<string, CensusDTO> LoadUSCensusData(string filePath, string dataHeader)
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
                censusDictionary.Add(column[1], new CensusDTO(new USCensusCSV(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
            }

            return censusDictionary;

        }
    }
}
