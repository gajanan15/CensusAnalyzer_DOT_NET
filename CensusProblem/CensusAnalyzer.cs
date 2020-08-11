using CensusProblem.POCO;
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
        public Dictionary<int, CensusDTO> stateDictionary = new Dictionary<int, CensusDTO>();
        int counter = 0;

        public delegate object CSVData(string filePath, string dataHeader);

        public object LoadCensusData(string filePath, string dataHeader)
        {
            stateDictionary = new Dictionary<int, CensusDTO>();

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

            foreach (string delimiter in data.Skip(1))
            {
          
                if (!delimiter.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }

                counter++;
                string[] column = delimiter.Split(",");
                if (filePath.Contains("IndiaStateCensusData")) {
                    stateDictionary.Add(counter,new CensusDTO(new StateCensusCSV(column[0], column[1], column[2], column[3])));
                }
                if (filePath.Contains("IndiaStateCode")) {
                    stateDictionary.Add(counter, new CensusDTO(new StateCodeCSV(column[0], column[1], column[2], column[3])));
                }
            }

            return stateDictionary.ToDictionary(d=> d.Key, d=> d.Value);

        }

        public object GetSortedData(string filePath, string header,string field,string order)
        {
            if (!File.Exists(filePath)) {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            var censusData = (Dictionary<int, CensusDTO>)LoadCensusData(filePath, header);
            List<CensusDTO> censusList = censusData.Values.ToList();
            List<CensusDTO> sortedLists = getSoretdField(field, censusList);

            if (order.Contains("DESC"))
                sortedLists.Reverse();
            return JsonConvert.SerializeObject(sortedLists);
        }


        public List<CensusDTO> getSoretdField(string filed,List<CensusDTO> censusList) {
            switch (filed)
            {
                case "stateName": 
                    return censusList.OrderBy(x => x.stateName).ToList();
                case "stateCode": 
                    return censusList.OrderBy(x => x.stateCode).ToList();
                case "population":
                    return censusList.OrderBy(x => x.population).ToList();
                default: return censusList;
            }    
        }
    }
}
