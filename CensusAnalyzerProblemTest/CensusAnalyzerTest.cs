using CensusProblem;
using NUnit.Framework;

namespace CensusAnalyzerProblemTest
{
    public class Tests
    {

        //Indian Census Data CSV FILE
        static string CSVFilePath = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCensusData.csv";
        static string WRONG_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\IndiaState.csv";
        static string WRONG_CSV_FILE_TYPE = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCensusData.txt";
        static string INCORRECT_DELIMITER_INDIAN_CENSUS_DATA = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IncorrectDelimiterIndiaCensusData.csv";
        static string INCORRECT_HEADER_INDIAN_CENSUS_DATA = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IncorrectHeaderIndianCensus.csv";
        
        //Indian State Code CSV File
        static string INDIA_STATE_CODE_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCode.csv";
        static string WRONG_STATE_CODE_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_STATE_CODE_FILE_TYPE = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCode.txt";
        static string INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IncorrectDelimiterIndiaStateCode.csv";
        static string INCORRECT_HEADER_INDIAN_STATE_CODE_DATA = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IncorrectHeaderIndianStateCode.csv";

        //HEADER
        static string INDIAN_CENSUS_HEADERS = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string INDIAN_STATE_CODE_HEADERS = "SrNo,State Name,TIN,StateCode";

        CensusAnalyzer censusAnalyzer;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
        }

        [Test]
        public void givenIndianCensusCSVFileReturnsCorrectRecords()
        {

            string[] numOfRecords = censusAnalyzer.loadCensusData(CSVFilePath, INDIAN_CENSUS_HEADERS);
            Assert.AreEqual(29, numOfRecords.Length);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ShouldThrowException()
        {
      
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(WRONG_CSV_FILE_PATH, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);

        }

        [Test]
        public void givenIndiaCensusData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(WRONG_CSV_FILE_TYPE, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void givenindiacensusdata_WhenIncorrectDelimiter_ShouldThrowException()
        {
           
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(INCORRECT_DELIMITER_INDIAN_CENSUS_DATA, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIndiaCensusData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
           
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(INCORRECT_HEADER_INDIAN_CENSUS_DATA, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

        ////============= Indian State Code ======================


        [Test]
        public void givenIndianStateCodeCSVFileReturnsCorrectRecords()
        {
            string[] numOfRecords = censusAnalyzer.loadCensusData(INDIA_STATE_CODE_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADERS);
            Assert.AreEqual(37, numOfRecords.Length);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenWrongFile_ShouldThrowException()
        {
            
            var wrongFile = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(WRONG_STATE_CODE_FILE_PATH, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, wrongFile.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
           
            var incorrectType = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(WRONG_STATE_CODE_FILE_TYPE, INDIAN_CENSUS_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, incorrectType.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenIncorrectDelimiter_ShouldThrowException()
        {
           
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(INCORRECT_DELIMITER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, incorrectDelimiter.type);

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
            
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.loadCensusData(INCORRECT_HEADER_INDIAN_STATE_CODE_DATA, INDIAN_STATE_CODE_HEADERS));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, incorrectHeader.type);

        }

    }
}