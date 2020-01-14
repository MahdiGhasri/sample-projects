using CsvParser.Tests.Models;
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
        [InlineData(@"d:\sample-input.csv")]
        [InlineData(@"d:\sample-input1.csv")]
        public void When_ShowRowNumberAsIdIsTrue_And_IsCorrectBrokenLinesIsTrue_Expect_PersonListWithId_And_AllCsvData(string filePath)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath)
            {
                ShowRowNumberAsId = true,
                IsCorrectBrokenLines = true
            };

            List<Person> result = csvFileReader.MapFileToObject<Person>(_csvColumns);
            Assert.Collection(result,
                                person => {
                                    Assert.Equal("1", person.Id);
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Hans", person.FirstName);
                                    Assert.Equal("67742 Lauterecken", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("2", person.Id);
                                    Assert.Equal("Petersen", person.LastName);
                                    Assert.Equal("Peter", person.FirstName);
                                    Assert.Equal("18439 Stralsund", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("3", person.Id);
                                    Assert.Equal("Johnson", person.LastName);
                                    Assert.Equal("Johnny", person.FirstName);
                                    Assert.Equal("88888 made up", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("4", person.Id);
                                    Assert.Equal("Millenium", person.LastName);
                                    Assert.Equal("Milly", person.FirstName);
                                    Assert.Equal("77777 made up too", person.Address);
                                    Assert.Equal("4", person.Color);
                                },
                                person => {
                                    Assert.Equal("5", person.Id);
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Jonas", person.FirstName);
                                    Assert.Equal("32323 Hansstadt", person.Address);
                                    Assert.Equal("5", person.Color);
                                },
                                person => {
                                    Assert.Equal("6", person.Id);
                                    Assert.Equal("Fujitsu", person.LastName);
                                    Assert.Equal("Tastatur", person.FirstName);
                                    Assert.Equal("42342 Japan", person.Address);
                                    Assert.Equal("6", person.Color);
                                },
                                person => {
                                    Assert.Equal("7", person.Id);
                                    Assert.Equal("Andersson", person.LastName);
                                    Assert.Equal("Anders", person.FirstName);
                                    Assert.Equal("32132 Schweden - ☀", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("8", person.Id);
                                    Assert.Equal("Bart", person.LastName);
                                    Assert.Equal("Bertram", person.FirstName);
                                    Assert.Equal("12313 Wasweißich", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("9", person.Id);
                                    Assert.Equal("Gerber", person.LastName);
                                    Assert.Equal("Gerda", person.FirstName);
                                    Assert.Equal("76535 Woanders", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("10", person.Id);
                                    Assert.Equal("Klaussen", person.LastName);
                                    Assert.Equal("Klaus", person.FirstName);
                                    Assert.Equal("43246 Hierach", person.Address);
                                    Assert.Equal("2", person.Color);
                                }
                             );
        }

        [Theory]
        [InlineData(@"d:\sample-input.csv")]
        [InlineData(@"d:\sample-input1.csv")]
        public void When_ShowRowNumberAsIdIsFalse_And_IsCorrectBrokenLinesIsTrue_Expect_PersonListWithoutId_And_AllCsvData(string filePath)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath)
            {
                ShowRowNumberAsId = false,
                IsCorrectBrokenLines = true
            };

            List<Person> result = csvFileReader.MapFileToObject<Person>(_csvColumns);
            Assert.Collection(result,
                                person => {
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Hans", person.FirstName);
                                    Assert.Equal("67742 Lauterecken", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("Petersen", person.LastName);
                                    Assert.Equal("Peter", person.FirstName);
                                    Assert.Equal("18439 Stralsund", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("Johnson", person.LastName);
                                    Assert.Equal("Johnny", person.FirstName);
                                    Assert.Equal("88888 made up", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("Millenium", person.LastName);
                                    Assert.Equal("Milly", person.FirstName);
                                    Assert.Equal("77777 made up too", person.Address);
                                    Assert.Equal("4", person.Color);
                                },
                                person => {
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Jonas", person.FirstName);
                                    Assert.Equal("32323 Hansstadt", person.Address);
                                    Assert.Equal("5", person.Color);
                                },
                                person => {
                                    Assert.Equal("Fujitsu", person.LastName);
                                    Assert.Equal("Tastatur", person.FirstName);
                                    Assert.Equal("42342 Japan", person.Address);
                                    Assert.Equal("6", person.Color);
                                },
                                person => {
                                    Assert.Equal("Andersson", person.LastName);
                                    Assert.Equal("Anders", person.FirstName);
                                    Assert.Equal("32132 Schweden - ☀", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("Bart", person.LastName);
                                    Assert.Equal("Bertram", person.FirstName);
                                    Assert.Equal("12313 Wasweißich", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("Gerber", person.LastName);
                                    Assert.Equal("Gerda", person.FirstName);
                                    Assert.Equal("76535 Woanders", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("Klaussen", person.LastName);
                                    Assert.Equal("Klaus", person.FirstName);
                                    Assert.Equal("43246 Hierach", person.Address);
                                    Assert.Equal("2", person.Color);
                                }
                             );
        }


        [Theory]
        [InlineData(@"d:\sample-input.csv")]
        public void When_ShowRowNumberAsIdIsTrue_And_IsCorrectBrokenLinesIsFalse_Expect_PersonListWithId_And_CsvDataFromCorrectLines(string filePath)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath)
            {
                ShowRowNumberAsId = true,
                IsCorrectBrokenLines = false
            };

            List<Person> result = csvFileReader.MapFileToObject<Person>(_csvColumns);
            Assert.Collection(result,
                                person => {
                                    Assert.Equal("1", person.Id);
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Hans", person.FirstName);
                                    Assert.Equal("67742 Lauterecken", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("2", person.Id);
                                    Assert.Equal("Petersen", person.LastName);
                                    Assert.Equal("Peter", person.FirstName);
                                    Assert.Equal("18439 Stralsund", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("3", person.Id);
                                    Assert.Equal("Johnson", person.LastName);
                                    Assert.Equal("Johnny", person.FirstName);
                                    Assert.Equal("88888 made up", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("4", person.Id);
                                    Assert.Equal("Millenium", person.LastName);
                                    Assert.Equal("Milly", person.FirstName);
                                    Assert.Equal("77777 made up too", person.Address);
                                    Assert.Equal("4", person.Color);
                                },
                                person => {
                                    Assert.Equal("5", person.Id);
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Jonas", person.FirstName);
                                    Assert.Equal("32323 Hansstadt", person.Address);
                                    Assert.Equal("5", person.Color);
                                },
                                person => {
                                    Assert.Equal("6", person.Id);
                                    Assert.Equal("Fujitsu", person.LastName);
                                    Assert.Equal("Tastatur", person.FirstName);
                                    Assert.Equal("42342 Japan", person.Address);
                                    Assert.Equal("6", person.Color);
                                },
                                person => {
                                    Assert.Equal("7", person.Id);
                                    Assert.Equal("Andersson", person.LastName);
                                    Assert.Equal("Anders", person.FirstName);
                                    Assert.Equal("32132 Schweden - ☀", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("8", person.Id);
                                    Assert.Equal("Gerber", person.LastName);
                                    Assert.Equal("Gerda", person.FirstName);
                                    Assert.Equal("76535 Woanders", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("9", person.Id);
                                    Assert.Equal("Klaussen", person.LastName);
                                    Assert.Equal("Klaus", person.FirstName);
                                    Assert.Equal("43246 Hierach", person.Address);
                                    Assert.Equal("2", person.Color);
                                }
                             );
        }

        [Theory]
        [InlineData(@"d:\sample-input1.csv")]
        public void When_ShowRowNumberAsIdIsFalse_And_IsCorrectBrokenLinesIsFalse_Expect_PersonListWithoutId_And_CsvDataFromCorrectLines(string filePath)
        {
            CsvFileReader csvFileReader = new CsvFileReader(filePath)
            {
                ShowRowNumberAsId = false,
                IsCorrectBrokenLines = false
            };

            List<Person> result = csvFileReader.MapFileToObject<Person>(_csvColumns);
            Assert.Collection(result,
                                person => {
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Hans", person.FirstName);
                                    Assert.Equal("67742 Lauterecken", person.Address);
                                    Assert.Equal("1", person.Color);
                                },
                                person => {
                                    Assert.Equal("Petersen", person.LastName);
                                    Assert.Equal("Peter", person.FirstName);
                                    Assert.Equal("18439 Stralsund", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("Johnson", person.LastName);
                                    Assert.Equal("Johnny", person.FirstName);
                                    Assert.Equal("88888 made up", person.Address);
                                    Assert.Equal("3", person.Color);
                                },
                                person => {
                                    Assert.Equal("Millenium", person.LastName);
                                    Assert.Equal("Milly", person.FirstName);
                                    Assert.Equal("77777 made up too", person.Address);
                                    Assert.Equal("4", person.Color);
                                },
                                person => {
                                    Assert.Equal("Müller", person.LastName);
                                    Assert.Equal("Jonas", person.FirstName);
                                    Assert.Equal("32323 Hansstadt", person.Address);
                                    Assert.Equal("5", person.Color);
                                },
                                person => {
                                    Assert.Equal("Fujitsu", person.LastName);
                                    Assert.Equal("Tastatur", person.FirstName);
                                    Assert.Equal("42342 Japan", person.Address);
                                    Assert.Equal("6", person.Color);
                                },
                                person => {
                                    Assert.Equal("Andersson", person.LastName);
                                    Assert.Equal("Anders", person.FirstName);
                                    Assert.Equal("32132 Schweden - ☀", person.Address);
                                    Assert.Equal("2", person.Color);
                                },
                                person => {
                                    Assert.Equal("Klaussen", person.LastName);
                                    Assert.Equal("Klaus", person.FirstName);
                                    Assert.Equal("43246 Hierach", person.Address);
                                    Assert.Equal("2", person.Color);
                                }
                             );
        }
    }
}
