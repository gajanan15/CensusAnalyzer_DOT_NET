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
        public Dictionary<string, CensusDTO> censusDictionary;
      
        public Dictionary<string,CensusDTO> LoadCensusData(string filePath, string dataHeader)
        {
            censusDictionary = new Dictionary<string, CensusDTO>();

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

               
                string[] column = delimiter.Split(",");
                if (filePath.Contains("IndiaStateCensusData")) {
                    censusDictionary.Add(column[0],new CensusDTO(new StateCensusCSV(column[0], column[1], column[2], column[3])));
                }
                if (filePath.Contains("IndiaStateCode")) {
                    censusDictionary.Add(column[1], new CensusDTO(new StateCodeCSV(column[0], column[1], column[2], column[3])));
                }
                if (filePath.Contains("USCensusData")) {
                    censusDictionary.Add(column[1], new CensusDTO(new USCensusCSV(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
                }
            }

            return censusDictionary;

        }

        public object GetSortedData(string filePath, string header,string field,string order)
        {

            if (!File.Exists(filePath)) {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            var censusData = LoadCensusData(filePath, header);
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
                case "density":
                    return censusList.OrderBy(x => x.density).ToList();
                case "area":
                    return censusList.OrderBy(x => x.area).ToList();
                default: return censusList;
            }    
        }

        public Dictionary<string, CensusDTO> LoadUsCensusData(string filePath,string dataHeader) 
        {
           
            return LoadCensusData(filePath, dataHeader);

        }
    }
}
