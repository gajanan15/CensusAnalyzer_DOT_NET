using CensusProblem;
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
        Dictionary<int,string> numOfRecordsCensusData = new Dictionary<int, string>();
        Dictionary<int, string> numOfRecordsStateData = new Dictionary<int, string>();

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
            numOfRecordsCensusData = (Dictionary<int,string>)csvData(CSVFilePath,INDIAN_CENSUS_HEADERS);
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
            numOfRecordsStateData = (Dictionary<int, string>)csvData(INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS);
            numOfRecordsCensusData = (Dictionary<int, string>)csvData(CSVFilePath, INDIAN_CENSUS_HEADERS);
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
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_SORTED_FILE_PATH).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", sortedIndianCensusData[0]);
        }

        [Test]
         public void givenIndiaCensusData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(CSVFilePath, INDIAN_SORTED_FILE_PATH).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length-1;
            Assert.AreEqual("West Bengal,91347736,88752,1029", sortedIndianCensusData[lengthOfSoretedData]);
        }

        //Sorted Indian State Code Data

        [Test]
        public void givenIndiaStateCodeData_WhenSortedOnStateCode_ShouldReturnSortedResult()
        {
            string sortedData = censusAnalyzer.GetSortedData(INDIA_STATE_CODE_CSV_FILE_PATH, SORTED_INDIAN_STATE_CODE_DATA).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", sortedIndianCensusData[0]);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenSortedOnState_ShouldReturnLastRecord()
        {
            string sortedData = censusAnalyzer.GetSortedData(INDIA_STATE_CODE_CSV_FILE_PATH, SORTED_INDIAN_STATE_CODE_DATA).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            int lengthOfSoretedData = sortedIndianCensusData.Length - 1;
            Assert.AreEqual("37,West Bengal,19,WB", sortedIndianCensusData[lengthOfSoretedData]);
        }
    }
}