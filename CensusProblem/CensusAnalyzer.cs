using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CensusProblem
{
    public class CensusAnalyzer : ICsvBuilder
    {
        string[] data;
        public Dictionary<int, string> dataDictionary;
        int counter = 0;

        public delegate object CSVData(string filePath, string dataHeader);

        public object LoadCensusData(string filePath, string dataHeader)
        {
            dataDictionary = new Dictionary<int, string>();

            if (!File.Exists(filePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_TYPE);
            }


             data = File.ReadAllLines(filePath);

            if (data.ElementAt(0) != dataHeader)
            {
                throw new CensusAnalyserException("Invalid Header", CensusAnalyserException.ExceptionType.INVALID_HEADER);
            }

            foreach (string delimiter in data)
            {
                counter++;
                dataDictionary.Add(counter, delimiter);

                if (!delimiter.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }

            return dataDictionary.Skip(1).ToDictionary(d=> d.Key, d=> d.Value);

        }

        public object GetSortedData(string filePath, string sortedFilePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var data = lines.Skip(1);
            int index;
            if (sortedFilePath.Contains("filePathSorted"))
            {
                index = 0;
            }
            else {
                index = 3;
            }
            var sorted =
                from line in data
                let x = line.Split(',')
                orderby x[index]
                select line;
            File.WriteAllLines(sortedFilePath, lines.Take(1).Concat(sorted.ToArray()));
            List<string> sortedData = sorted.ToList<string>();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}
