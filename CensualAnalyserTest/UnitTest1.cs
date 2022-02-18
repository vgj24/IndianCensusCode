using System.Collections.Generic;
using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using NUnit.Framework;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensualAnalyserTest
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\IndiaStateCensusData.csv";

        static string wrongHeaderIndianCensusFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\WrongIndiaStateCensusData.csv";

        static string delimiterIndianCensusFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\DelimiterIndiaStateCensusData.csv";

        static string wrongIndianStateCensusFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\WrongIndiaStateCensusData.csv";

        static string wrongIndianStateCensusFileType = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\IndiaStateCensusData.txt";

        static string indianStateCodeFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\IndiaStateCode.csv";

        static string wrongIndianStateCodeFileType = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\IndiaStateCode.txt";

        static string delimiterIndianStateCodeFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\DelimiterIndiaStateCensusData.csv";

        static string wrongHeaderStateCodeFilePath = @"C:\Users\vgj24\source\repos\CensualAnalyserTest\Csvfiles\WrongIndiaStateCensusData.csv";
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

    }


}