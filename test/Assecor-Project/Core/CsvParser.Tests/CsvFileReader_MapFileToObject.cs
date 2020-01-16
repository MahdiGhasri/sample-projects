using CsvParser.Tests.Models;
using System.Collections.Generic;
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
    }
}
