using CensusProblem;
using NUnit.Framework;

namespace CensusAnalyzerProblemTest
{
    public class Tests
    {
        static string CSVFilePath = @"C:\Users\user\source\repos\CensusProblem\IndiaStateCensusData.csv";
        static string WRONG_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\IndiaState.csv";
        static string WRONG_CSV_FILE_TYPE = @"C:\Users\user\source\repos\CensusProblem\IndiaStateCensusData.txt";
        
        
        static string INDIA_STATE_CODE_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\IndiaStateCode.csv";
        static string WRONG_STATE_CODE_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_STATE_CODE_FILE_TYPE = @"C:\Users\user\source\CensusAnalyzer\IndiaStateCode.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensusCSVFileReturnsCorrectRecords()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            int numOfRecords = censusAnalyzer.loadCensusData(CSVFilePath);
            Assert.AreEqual(29, numOfRecords);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadCensusData(WRONG_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }

        }

        [Test]
        public void givenIndiaCensusData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadCensusData(WRONG_CSV_FILE_TYPE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, e.type);
            }

        }

        [Test]
        public void givenindiacensusdata_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadCensusData(CSVFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, e.type);
            }

        }

        [Test]
        public void givenIndiaCensusData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                int totalItems = censusAnalyzer.loadCensusData(CSVFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, e.type);
            }

        }

        //============= Indian State Code ======================


        [Test]
        public void givenIndianStateCodeCSVFileReturnsCorrectRecords()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            int numOfRecords = censusAnalyzer.loadStateCodeData(INDIA_STATE_CODE_CSV_FILE_PATH);
            Assert.AreEqual(37, numOfRecords);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenWrongFile_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadStateCodeData(WRONG_STATE_CODE_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButTypeIncorrect_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadStateCodeData(WRONG_STATE_CODE_FILE_TYPE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_TYPE, e.type);
            }

        }

        [Test]
        public void givenIndiaStateCodeData_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                censusAnalyzer.loadStateCodeData(INDIA_STATE_CODE_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, e.type);
            }

        }

        [Test]
        public void givenIndiaStateCodeData_WhenCorrectFileButHeaderIncorrect_ShouldThrowException()
        {
            try
            {
                CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
                int totalItems = censusAnalyzer.loadStateCodeData(INDIA_STATE_CODE_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, e.type);
            }

        }

    }
}