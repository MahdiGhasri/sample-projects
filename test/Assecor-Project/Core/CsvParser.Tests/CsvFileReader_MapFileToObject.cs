using CsvParser.Tests.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Utility.Extensions;
using Xunit;

namespace CsvParser.Tests
{
    public class CsvFileReader_MapFileToObject
    {
        private readonly string[] _csvColumns = new string[]
                                                    {
                                                        nameof(Person.LastName),
                                                        nameof(Person.FirstName),
                                                        nameof(Person.Address),
                                                        nameof(Person.Color),
                                                    };

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetCsvFileReaderTestData), MemberType = typeof(TestDataGenerator))]
        public void When_ExistCsvFiles_Expect_PersonList(string filePath, 
                                                         bool showRowNumberAsId,
                                                         bool shouldCorrectBrokenLines,
                                                         List<Person> expectResult)
        {
            //Action arrange = () => new CsvFileReader("");
            //Assert.Throws<ArgumentException>(arrange);

            CsvFileReader csvFileReader = new CsvFileReader(filePath)
            {
                ShowRowNumberAsId = showRowNumberAsId,
                ShouldCorrectBrokenLines = shouldCorrectBrokenLines
            };

            List<Person> actualResult = csvFileReader.MapFileToObject<Person>(_csvColumns);
         
            string jsonStringActualResult = actualResult.ToJson();
            string jsonStringExpectResult = expectResult.ToJson();
       
            Assert.Equal(jsonStringExpectResult, jsonStringActualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void When_FilePathIsNullOrEmpty_Expect_ArgumentException(string filePath)
        {
            Assert.Throws<ArgumentException>(() => new CsvFileReader(filePath));
        }

        [Theory]
        [InlineData(@"C:\Test.csv")]
        public void When_FilePathIsNotFound_Expect_FileNotFoundException(string filePath)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath);

            Assert.Throws<FileNotFoundException>(() => csvFileReader.MapFileToObject<Person>(_csvColumns));
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetTestDataForCsvColumns), MemberType = typeof(TestDataGenerator))]
        public void When_CsvColumnsIsNullOrEmpty_Expect_ArgumentException(string filePath,
                                                                          string[] csvColumns)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath);

            Assert.Throws<ArgumentException>(() => csvFileReader.MapFileToObject<Person>(csvColumns));
        }
    }
}
