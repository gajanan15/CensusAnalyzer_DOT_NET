using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CensusProblem
{
    public class CensusAnalyzer : ICsvBuilder
    {
        List<string> data = new List<string>();

        public delegate object CSVData(string filePath, string dataHeader);

        public object loadCensusData(string filePath, string dataHeader)
        {
            if (!File.Exists(filePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_TYPE);
            }


             data = File.ReadAllLines(filePath).ToList();

            if (data.ElementAt(0) != dataHeader)
            {
                throw new CensusAnalyserException("Invalid Header", CensusAnalyserException.ExceptionType.INVALID_HEADER);
            }

            foreach (string delimiter in data)
            {
                if (!delimiter.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }

            return data.Skip(1).ToList();

        }
    }
}
