using System;
using System.IO;

namespace CensusProblem
{
    public class CensusAnalyzer
    {
        public int loadCensusData(string path)
        {
            if (!path.Contains("CensusData"))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (!path.Contains(".csv"))
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_TYPE);
            }


            string[] data = File.ReadAllLines(path);

            if (data[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
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

            return data.Length - 1;

        }


        public int loadStateCodeData(string path)
        {
            if (!path.Contains("Code"))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (!path.Contains(".csv"))
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_TYPE);
            }


            string[] data = File.ReadAllLines(path);

            if (data[0] != "SrNo,State Name,TIN,StateCode")
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

            return data.Length - 1;

        }
    }
}
