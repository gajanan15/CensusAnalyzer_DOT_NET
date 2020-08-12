using CensusProblem.POCO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CensusProblem
{
    public class CensusAnalyzer 
    {
        public enum Country { INDIA, US };

        public Dictionary<string, CensusDTO> censusDictionary;
      
        public Dictionary<string,CensusDTO> LoadCensusData(Country country, string filePath, string dataHeader)
        {
            censusDictionary = new CensusAdapterFactory().GetCensusData(country, filePath, dataHeader);
            return censusDictionary;
        }

        public object GetSortedData(Country country, string filePath, string header,string field,string order)
        {

            if (!File.Exists(filePath)) {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            var censusData = LoadCensusData(country,filePath, header);
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
                case "populationDensity":
                    return censusList.OrderBy(x => x.populationDensity).ToList();
                case "totalArea":
                    return censusList.OrderBy(x => x.totalArea).ToList();
                default: return censusList;
            }    
        }
    }
}
