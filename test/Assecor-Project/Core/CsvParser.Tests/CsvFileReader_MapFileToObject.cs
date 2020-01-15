using CsvParser.Tests.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public void When_ExistCsvFiles_Expect_PersonList(string filePath, List<Person> expectResult)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath);

            List<Person> result = csvFileReader.MapFileToObject<Person>(_csvColumns);
         
            string jsonStringResult = JsonConvert.SerializeObject(result);
            string jsonStringExpect = JsonConvert.SerializeObject(expectResult);
       
            Assert.Equal(jsonStringExpect, jsonStringResult);
        }
    }
}
