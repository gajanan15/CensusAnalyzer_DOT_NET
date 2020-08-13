using CensusProblem;
using CensusProblem.POCO;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static CensusProblem.CensusAnalyzer;

namespace CensusAnalyzerProblemTest
{
    public class Tests
    {

        //Indian Census Data CSV FILE
        static string CSVFilePath = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCensusData.csv";
        static string WRONG_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\IndiaState.csv";
        static string WRONG_CSV_FILE_TYPE = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCensusData.txt";
        static string INCORRECT_DELIMITER_INDIAN_CENSUS_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectDelimiterIndiaCensusData.csv";
        static string INCORRECT_HEADER_INDIAN_CENSUS_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectHeaderIndianCensus.csv";

        //Indian State Code CSV File
        static string INDIA_STATE_CODE_CSV_FILE_PATH = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCode.csv";
        static string WRONG_STATE_CODE_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_STATE_CODE_FILE_TYPE = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCode.txt";
        static string INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectDelimiterIndiaStateCode.csv";
        static string INCORRECT_HEADER_INDIAN_STATE_CODE_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectHeaderIndianStateCode.csv";

        //US Census Data

        static string UC_CENSUS_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\USCensusData.csv";
        static string WRONG_US_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\USCensusData.csv";
        static string WRONG_US_CSV_FILE_TYPE = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\USCensusData.txt";
        static string INCORRECT_DELIMITER_US_CENSUS_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectDelimiterUSCensusData.csv";
        static string INCORRECT_HEADER_US_CENSUS_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectHeaderUSCensusData.csv";


        //HEADER
        static string INDIAN_CENSUS_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string INDIAN_STATE_CODE_HEADERS = "SrNo,State Name,TIN,StateCode";
        static string US_CENSUS_DATA_HEADERS = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        CensusAnalyzer censusAnalyzer;
        Dictionary<string,CensusDTO> numOfRecords = new Dictionary<string, CensusDTO>();
        Dictionary<string, CensusDTO> numOfRecordsStateData = new Dictionary<string, CensusDTO>();

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
        }

        [Test]
        public void GivenIndianCensusCSVFile_ShouldReturnsCorrectRecords()
        {
            numOfRecords = censusAnalyzer.LoadCensusData(Country.INDIA,CSVFilePath,INDIAN_CENSUS_HEADERS);
            Assert.AreEqual(29, numOfRecords.Count);
        }

        [Test]
        public void GivenIndiaCensusData_WhenWrongFile_ShouldThrowException()
        {
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA,WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
        }

        [Test]
        public void GivenIndiaCensusData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
           
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA,WRONG_CSV_FILE_TYPE, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void GivenIndiaCensusData_WhenIncorrectDelimiter_ShouldThrowException()
        {
          
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, INCORRECT_DELIMITER_INDIAN_CENSUS_DATA, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void GivenIndiaCensusData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
          
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA,INCORRECT_HEADER_INDIAN_CENSUS_DATA, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        ////////============= Indian State Code ======================


        [Test]
        public void GivenIndianStateCodeCSVFile_ShouldReturnsCorrectRecords()
        {
          
            numOfRecordsStateData = (Dictionary<string, CensusDTO>)censusAnalyzer.LoadCensusData(Country.INDIA,INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS);
            numOfRecords = (Dictionary<string, CensusDTO>)censusAnalyzer.LoadCensusData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS);
            Assert.AreEqual(29, numOfRecords.Count);
            Assert.AreEqual(37, numOfRecordsStateData.Count);
        }

        [Test]
        public void GivenIndiaStateCodeData_WhenWrongFile_ShouldThrowException()
        {
          
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, WRONG_STATE_CODE_FILE_PATH, INDIAN_STATE_CODE_HEADERS));
            var wrongCensusFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongCensusFile.type);

        }

        [Test]
        public void GivenIndiaStateCodeData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
           
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, WRONG_STATE_CODE_FILE_TYPE, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void GivenIndiaStateCodeData_WhenIncorrectDelimiter_ShouldThrowException()
        {
           
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void GivenIndiaStateCodeData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
           
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, INCORRECT_HEADER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        //Sorted Data Indian Census Data

        [Test]
        public void GivenIndiaCensusData_WhenSortedOnState_ShouldReturnSortedResult()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "stateName", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void GivenIndiaCensusData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS,"stateName", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length - 1;
            Assert.AreEqual("West Bengal", sortedIndianCensusData[lengthOfSoretedData].stateName);
        }

        //Most Population State
        [Test]
        public void GivenIndianCensusData_WhenSortedOnPopulation_ShouldReturnMostPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "population", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].stateName);
        }

        //Least Population State
        [Test]
        public void GivenIndianCensusData_WhenSortedOnPopulation_ShouldReturnLeastPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "population", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void GivenIndianCensusData_WhenIncorrectFile_ShouldThrowException()
        {
            var sortedIndianCensusData = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.GetSortedData(Country.INDIA, WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS, "population", "DESC"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, sortedIndianCensusData.type);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedOnDensity_ShouldReturnMostPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "density", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedOnDensity_ShouldReturnLeastPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "density", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedOnTotalArea_ShouldReturnLargestState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "area", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedOnTotalArea_ShouldReturnSmallestState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "area", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Goa", sortedIndianCensusData[0].stateName);
        }


        //Sorted Indian State Code Data

        [Test]
        public void GivenIndiaStateCodeData_WhenSortedOnStateCode_ShouldReturnSortedResult()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS, "stateCode", "ASC").ToString();
            StateCodeCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCodeCSV[]>(sortedData);
            Assert.AreEqual("AD", sortedIndianCensusData[0].stateCode);
        }

        [Test]
        public void GivenIndiaStateCodeData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.INDIA, INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS, "stateCode","ASC").ToString();
            StateCodeCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCodeCSV[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length - 1;
            Assert.AreEqual("WB", sortedIndianCensusData[lengthOfSoretedData].stateCode);
        }


        //US Census Data

        [Test]
        public void GivenUsCensusCSVFile_ShouldReturnsCorrectRecords() {
            numOfRecords = censusAnalyzer.LoadCensusData(Country.US, UC_CENSUS_DATA,US_CENSUS_DATA_HEADERS);
            Assert.AreEqual(51, numOfRecords.Count);
        }


        [Test]
        public void GivenUSCensuseData_WhenWrongFile_ShouldThrowException()
        {
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.US, WRONG_US_CSV_FILE_PATH, US_CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
        }

        [Test]
        public void GivenUSCensuseData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.US, WRONG_US_CSV_FILE_PATH, US_CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
        }

        [Test]
        public void GivenUSCensusData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.US, WRONG_US_CSV_FILE_TYPE, US_CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void GivenUSCensusData_WhenIncorrectDelimiter_ShouldThrowException()
        {
    
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.US, INCORRECT_DELIMITER_US_CENSUS_DATA, US_CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void GivenUSCensusData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
        
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.US, INCORRECT_HEADER_US_CENSUS_DATA, US_CENSUS_DATA_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        [Test]
        public void GivenUSCensusData_WhenSortedOnPopulation_ShouldReturnMostPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS,"population","DESC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("California", sortedUSCensusCSV[0].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedOnPopulation_ShouldReturnLeastPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "population", "ASC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("Wyoming", sortedUSCensusCSV[0].stateName);
        }


        [Test]
        public void GivenUSCensusData_WhenSortedOnPopulationDensity_ShouldReturnMostPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "populationDensity", "DESC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusCSV[0].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedOnPopulationDensity_ShouldReturnLeastPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "populationDensity", "ASC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusCSV[0].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedOnTotalArea_ShouldReturnMostTotalAreaState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "totalArea", "DESC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusCSV[0].stateName);
        }

        [Test]
        public void GivenUSCensusData_WhenSortedOnTotalArea_ShouldReturnLeastTotalAreaState()
        {
            string sortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "totalArea", "ASC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusCSV[0].stateName);
        }

        [Test]
        public void GievnCensusData_WhenSortedUSAndIndiaOnPopulationDensity_SholudReturnMostPopulousState()
        {
            string indianSortedData = censusAnalyzer.GetSortedData(Country.INDIA, CSVFilePath, INDIAN_CENSUS_HEADERS, "density", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusCSV = JsonConvert.DeserializeObject<StateCensusCSV[]>(indianSortedData);

            string usSortedData = censusAnalyzer.GetSortedData(Country.US, UC_CENSUS_DATA, US_CENSUS_DATA_HEADERS, "populationDensity", "DESC").ToString();
            USCensusCSV[] sortedUSCensusCSV = JsonConvert.DeserializeObject<USCensusCSV[]>(usSortedData);
            Assert.AreEqual(true, ((sortedIndianCensusCSV[0].density).CompareTo((long)sortedUSCensusCSV[0].populationDensity)) < 0);
        }
    }
}
