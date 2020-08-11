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
        static string INDIAN_SORTED_FILE_PATH = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\filePathSorted.csv";

        //Indian State Code CSV File
        static string INDIA_STATE_CODE_CSV_FILE_PATH = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCode.csv";
        static string WRONG_STATE_CODE_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_STATE_CODE_FILE_TYPE = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IndiaStateCode.txt";
        static string INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectDelimiterIndiaStateCode.csv";
        static string INCORRECT_HEADER_INDIAN_STATE_CODE_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\IncorrectHeaderIndianStateCode.csv";
        static string SORTED_INDIAN_STATE_CODE_DATA = @"C:\Users\Admin\source\repos\CensusProblem\CensusAnalyzerProblemTest\CSV Files\SortedIndiaStateCode.csv";

        //HEADER
        static string INDIAN_CENSUS_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string INDIAN_STATE_CODE_HEADERS = "SrNo,State Name,TIN,StateCode";

        CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
        CSVData csvData;
        CsvFactory csvFactory;
        Dictionary<int,CensusDTO> numOfRecordsCensusData = new Dictionary<int, CensusDTO>();
        Dictionary<int, CensusDTO> numOfRecordsStateData = new Dictionary<int, CensusDTO>();

        [SetUp]
        public void Setup()
        {
            csvFactory = new CsvFactory();
        }

        [Test]
        public void givenIndianCensusCSVFileReturnsCorrectRecords()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            numOfRecordsCensusData = (Dictionary<int, CensusDTO>)csvData(CSVFilePath,INDIAN_CENSUS_HEADERS);
            Assert.AreEqual(29, numOfRecordsCensusData.Count);
        }

        [Test]
        public void givenindiacensusdata_whenwrongfile_shouldthrowexception()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_CSV_FILE_PATH,INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
        }

        [Test]
        public void givenindiacensusdata_whencorrectfilebuttypeincorrect_shouldthrowexception()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_CSV_FILE_TYPE,INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void givenindiacensusdata_WhenIncorrectDelimiter_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => csvData(INCORRECT_DELIMITER_INDIAN_CENSUS_DATA,INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIndiaCensusData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => csvData(INCORRECT_HEADER_INDIAN_CENSUS_DATA,INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        ////////============= Indian State Code ======================


        [Test]
        public void givenIndianStateCodeCSVFileReturnsCorrectRecords()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            numOfRecordsStateData = (Dictionary<int, CensusDTO>)csvData(INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS);
            numOfRecordsCensusData = (Dictionary<int, CensusDTO>)csvData(CSVFilePath, INDIAN_CENSUS_HEADERS);
            Assert.AreEqual(29, numOfRecordsCensusData.Count);
            Assert.AreEqual(37, numOfRecordsStateData.Count);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenWrongFile_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_STATE_CODE_FILE_PATH, INDIAN_STATE_CODE_HEADERS));
            var wrongCensusFile = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongCensusFile.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => csvData(WRONG_STATE_CODE_FILE_TYPE, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenIncorrectDelimiter_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => csvData(INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
            censusAnalyzer = (CensusAnalyzer)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyzer.LoadCensusData);
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => csvData(INCORRECT_HEADER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        //Sorted Data Indian Census Data

        [Test]
        public void givenIndiaCensusData_WhenSortedOnState_ShouldReturnSortedResult()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS, "stateName", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void givenIndiaCensusData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS,"stateName", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length - 1;
            Assert.AreEqual("West Bengal", sortedIndianCensusData[lengthOfSoretedData].stateName);
        }

        //Most Population State
        [Test]
        public void givenIndianCensusData_WhenSortedOnPopulation_ShouldReturnMostPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS, "population", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].stateName);
        }

        //Least Population State
        [Test]
        public void givenIndianCensusData_WhenSortedOnPopulation_ShouldReturnLeastPopulationState()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS, "population", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void givenIndianCensusData_WhenIncorrectFile_ShouldThrowException()
        {
            var sortedIndianCensusData = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.GetSortedData(WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS, "population", "DESC"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, sortedIndianCensusData.type);
        }

        [Test]
        public void givenIndianCensusData_WhenSortedOnDensity_ShouldReturnMostPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS, "density", "DESC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].stateName);
        }

        [Test]
        public void givenIndianCensusData_WhenSortedOnDensity_ShouldReturnLeastPopulationDensityState()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_CENSUS_HEADERS, "density", "ASC").ToString();
            StateCensusCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCensusCSV[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[0].stateName);
        }


        //Sorted Indian State Code Data

        [Test]
        public void givenIndiaStateCodeData_WhenSortedOnStateCode_ShouldReturnSortedResult()
        {
            string sortedData = censusAnalyzer.GetSortedData(INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS, "stateCode", "ASC").ToString();
            StateCodeCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCodeCSV[]>(sortedData);
            Assert.AreEqual("AD", sortedIndianCensusData[0].stateCode);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS, "stateCode","ASC").ToString();
            StateCodeCSV[] sortedIndianCensusData = JsonConvert.DeserializeObject<StateCodeCSV[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length - 1;
            Assert.AreEqual("WB", sortedIndianCensusData[lengthOfSoretedData].stateCode);
        }

    }
}