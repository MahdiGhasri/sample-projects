using CsvParser.Tests.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CsvParser.Tests
{
    public class CsvFileReader_MapFileToObject
    {
        private readonly CsvFileReader _csvFileReader;
        public CsvFileReader_MapFileToObject()
        {
            string filePath = @"d:\sample-input.csv";
            string[] delimiters = new string[] { "," };

            _csvFileReader = new CsvFileReader(filePath, delimiters);
        }

        [Fact]
        public void CsvFileReader_InputIsCsvFile_ReturnListPersonWithIdAndCorrectBrokenLines()
        {
            List<Person> result = _csvFileReader.MapFileToObject<Person>(new string[]
                                                                            {
                                                                                nameof(Person.LastName),
                                                                                nameof(Person.FirstName),
                                                                                nameof(Person.Address),
                                                                                nameof(Person.Color),
                                                                            });

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
                                },
                                person => {
                                    Assert.Equal("10", person.Id);
                                    Assert.Equal("Bart", person.LastName);
                                    Assert.Equal("Bertram", person.FirstName);
                                    Assert.Equal("12313 Wasweißich", person.Address);
                                    Assert.Equal("1", person.Color);
                                }
                             );

        }

        [Fact]
        public void CsvFileReader_InputIsCsvFile_ReturnListPersonWithCorrectBrokenLines()
        {
            _csvFileReader.ShowRowNumberAsId = false;
            List<Person> result = _csvFileReader.MapFileToObject<Person>(new string[]
                                                                            {
                                                                                nameof(Person.LastName),
                                                                                nameof(Person.FirstName),
                                                                                nameof(Person.Address),
                                                                                nameof(Person.Color),
                                                                            });

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
                                },
                                person => {
                                    Assert.Equal("Bart", person.LastName);
                                    Assert.Equal("Bertram", person.FirstName);
                                    Assert.Equal("12313 Wasweißich", person.Address);
                                    Assert.Equal("1", person.Color);
                                }
                             );

        }

        [Fact]
        public void CsvFileReader_InputIsCsvFile_ReturnListPerson()
        {
            _csvFileReader.ShowRowNumberAsId = false;
            _csvFileReader.IsCorrectBrokenLines = false;

            List<Person> result = _csvFileReader.MapFileToObject<Person>(new string[]
                                                                            {
                                                                                nameof(Person.LastName),
                                                                                nameof(Person.FirstName),
                                                                                nameof(Person.Address),
                                                                                nameof(Person.Color),
                                                                            });

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
    }
}
