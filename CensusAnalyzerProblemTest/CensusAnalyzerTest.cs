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
        
        //Indian State Code CSV File
        static string INDIA_STATE_CODE_CSV_FILE_PATH = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCode.csv";
        static string WRONG_STATE_CODE_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_STATE_CODE_FILE_TYPE = @"C:\Users\user\source\repos\CensusProblem\CSV Files\IndiaStateCode.txt";

        //HEADER
        static string indianCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        CensusAnalyzer censusAnalyzer;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
        }

        [Test]
        public void givenIndianCensusCSVFileReturnsCorrectRecords()
        {

            string[] numOfRecords = censusAnalyzer.loadCensusData(CSVFilePath, indianCensusHeaders);
            Assert.AreEqual(29, numOfRecords.Length);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ShouldThrowException()
        {
            try
            {
                censusAnalyzer.loadCensusData(WRONG_CSV_FILE_PATH,indianCensusHeaders);
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
                censusAnalyzer.loadCensusData(WRONG_CSV_FILE_TYPE,indianCensusHeaders);
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
                censusAnalyzer.loadCensusData(CSVFilePath,indianCensusHeaders);
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
                censusAnalyzer.loadCensusData(CSVFilePath,indianCensusHeaders);
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
            string[] numOfRecords = censusAnalyzer.loadCensusData(INDIA_STATE_CODE_CSV_FILE_PATH,indianStateCodeHeaders);
            Assert.AreEqual(37, numOfRecords.Length);
        }

        [Test]
        public void givenIndiaStateCodeData_WhenWrongFile_ShouldThrowException()
        {
            try
            {
                censusAnalyzer.loadCensusData(WRONG_STATE_CODE_FILE_PATH,indianStateCodeHeaders);
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
                censusAnalyzer.loadCensusData(WRONG_STATE_CODE_FILE_TYPE,indianStateCodeHeaders);
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
                censusAnalyzer.loadCensusData(INDIA_STATE_CODE_CSV_FILE_PATH,indianStateCodeHeaders);
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
                censusAnalyzer.loadCensusData(INDIA_STATE_CODE_CSV_FILE_PATH,indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, e.type);
            }

        }

    }
}