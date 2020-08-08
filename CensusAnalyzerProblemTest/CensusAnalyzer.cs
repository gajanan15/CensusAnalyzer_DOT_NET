using CensusProblem;
using NUnit.Framework;

namespace CensusAnalyzerProblemTest
{
    public class Tests
    {
        static string CSVFilePath = @"C:\Users\user\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        static string WRONG_CSV_FILE_PATH = @"C:\Users\user\source\CensusAnalyzer\IndiaState.csv";
        static string WRONG_CSV_FILE_TYPE = @"C:\Users\user\source\CensusAnalyzer\IndiaStateCensusData.txt";

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
        public void givenIndiaCensusData_WithWrongFile_ShouldThrowException()
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
        public void givenIndiaCensusData_WithCorrectFileButTypeIncorrect_ShouldThrowException()
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
        public void givenindiacensusdata_withIncorrectDelimiter_ShouldThrowException()
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
        public void givenIndiaCensusData_WithCorrectFileButHeaderIncorrect_ShouldThrowException()
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
    }
}