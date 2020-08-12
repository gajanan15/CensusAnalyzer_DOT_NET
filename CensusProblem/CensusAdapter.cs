using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusProblem
{
    public abstract class CensusAdapter
    {
        protected string[] LoadData(string filePath, string header) {
            string[] data;

            if (!File.Exists(filePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_TYPE);
            }


            data = File.ReadAllLines(filePath);

            if (data.ElementAt(0) != header)
            {
                throw new CensusAnalyserException("Invalid Header", CensusAnalyserException.ExceptionType.INVALID_HEADER);
            }

            return data;
        }

    }
}
