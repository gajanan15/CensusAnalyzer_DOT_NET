﻿using Newtonsoft.Json;
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

        public object LoadCensusData(string filePath, string dataHeader)
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

        public object GetSortedData(string filePath, string sortedFilePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var data = lines.Skip(1);
            var sorted =
                from line in data
                let x = line.Split(',')
                orderby x[0]
                select line;
            File.WriteAllLines(sortedFilePath, lines.Take(1).Concat(sorted.ToArray()));
            List<string> sortedData = sorted.ToList<string>();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}
