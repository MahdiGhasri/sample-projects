using CsvParser.Tests.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CsvParser.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {

        public static IEnumerable<object[]> GetCsvFileReaderTestData()
        {
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string csvfile1 = Path.Combine(directory, "TestFiles", "sample-input.csv");
            string csvfile2 = Path.Combine(directory, "TestFiles", "sample-input1.csv");

            // Expected result for parameters: 
            // ShowRowNumberAsId = true, ShouldCorrectBrokenLines = true
            List<Person> resultExpected1 = new List<Person>
            {
                new Person {Id = "1", FirstName = "Hans", LastName = "Müller", Address = "67742 Lauterecken", Color = "1"},
                new Person {Id = "2", FirstName = "Peter", LastName = "Petersen", Address = "18439 Stralsund", Color = "2"},
                new Person {Id = "3", FirstName = "Johnny", LastName = "Johnson", Address = "88888 made up", Color = "3"},
                new Person {Id = "4", FirstName = "Milly", LastName = "Millenium", Address = "77777 made up too", Color = "4"},
                new Person {Id = "5", FirstName = "Jonas", LastName = "Müller", Address = "32323 Hansstadt", Color = "5"},
                new Person {Id = "6", FirstName = "Tastatur", LastName = "Fujitsu", Address = "42342 Japan", Color = "6"},
                new Person {Id = "7", FirstName = "Anders", LastName = "Andersson", Address = "32132 Schweden - ☀", Color = "2"},
                new Person {Id = "8", FirstName = "Bertram", LastName = "Bart", Address = "12313 Wasweißich", Color = "1"},
                new Person {Id = "9", FirstName = "Gerda", LastName = "Gerber", Address = "76535 Woanders", Color = "3"},
                new Person {Id = "10", FirstName = "Klaus", LastName = "Klaussen", Address = "43246 Hierach", Color = "2"}
            };

            // Expected result for parameters: 
            // ShowRowNumberAsId = false, ShouldCorrectBrokenLines = true
            List<Person> resultExpected2 = new List<Person>
            {
                new Person {FirstName = "Hans", LastName = "Müller", Address = "67742 Lauterecken", Color = "1"},
                new Person {FirstName = "Peter", LastName = "Petersen", Address = "18439 Stralsund", Color = "2"},
                new Person {FirstName = "Johnny", LastName = "Johnson", Address = "88888 made up", Color = "3"},
                new Person {FirstName = "Milly", LastName = "Millenium", Address = "77777 made up too", Color = "4"},
                new Person {FirstName = "Jonas", LastName = "Müller", Address = "32323 Hansstadt", Color = "5"},
                new Person {FirstName = "Tastatur", LastName = "Fujitsu", Address = "42342 Japan", Color = "6"},
                new Person {FirstName = "Anders", LastName = "Andersson", Address = "32132 Schweden - ☀", Color = "2"},
                new Person {FirstName = "Bertram", LastName = "Bart", Address = "12313 Wasweißich", Color = "1"},
                new Person {FirstName = "Gerda", LastName = "Gerber", Address = "76535 Woanders", Color = "3"},
                new Person {FirstName = "Klaus", LastName = "Klaussen", Address = "43246 Hierach", Color = "2"}
            };

            // Expected result for parameters: 
            // ShowRowNumberAsId = true, ShouldCorrectBrokenLines = false
            List<Person> resultExpected3 = new List<Person>
            {
                new Person {Id = "1", FirstName = "Hans", LastName = "Müller", Address = "67742 Lauterecken", Color = "1"},
                new Person {Id = "2", FirstName = "Peter", LastName = "Petersen", Address = "18439 Stralsund", Color = "2"},
                new Person {Id = "3", FirstName = "Johnny", LastName = "Johnson", Address = "88888 made up", Color = "3"},
                new Person {Id = "4", FirstName = "Milly", LastName = "Millenium", Address = "77777 made up too", Color = "4"},
                new Person {Id = "5", FirstName = "Jonas", LastName = "Müller", Address = "32323 Hansstadt", Color = "5"},
                new Person {Id = "6", FirstName = "Tastatur", LastName = "Fujitsu", Address = "42342 Japan", Color = "6"},
                new Person {Id = "7", FirstName = "Anders", LastName = "Andersson", Address = "32132 Schweden - ☀", Color = "2"},
                new Person {Id = "8", FirstName = "Gerda", LastName = "Gerber", Address = "76535 Woanders", Color = "3"},
                new Person {Id = "9", FirstName = "Klaus", LastName = "Klaussen", Address = "43246 Hierach", Color = "2"}
            };

            // Expected result for parameters: 
            // ShowRowNumberAsId = false, ShouldCorrectBrokenLines = false
            List<Person> resultExpected4 = new List<Person>
            {
                new Person {FirstName = "Hans", LastName = "Müller", Address = "67742 Lauterecken", Color = "1"},
                new Person {FirstName = "Peter", LastName = "Petersen", Address = "18439 Stralsund", Color = "2"},
                new Person {FirstName = "Johnny", LastName = "Johnson", Address = "88888 made up", Color = "3"},
                new Person {FirstName = "Milly", LastName = "Millenium", Address = "77777 made up too", Color = "4"},
                new Person {FirstName = "Jonas", LastName = "Müller", Address = "32323 Hansstadt", Color = "5"},
                new Person {FirstName = "Tastatur", LastName = "Fujitsu", Address = "42342 Japan", Color = "6"},
                new Person {FirstName = "Anders", LastName = "Andersson", Address = "32132 Schweden - ☀", Color = "2"},
                new Person {FirstName = "Gerda", LastName = "Gerber", Address = "76535 Woanders", Color = "3"},
                new Person {FirstName = "Klaus", LastName = "Klaussen", Address = "43246 Hierach", Color = "2"}
            };

            // Expected result for parameters: 
            // ShowRowNumberAsId = false, ShouldCorrectBrokenLines = false
            List<Person> resultExpected5 = new List<Person>
            {
                new Person {FirstName = "Hans", LastName = "Müller", Address = "67742 Lauterecken", Color = "1"},
                new Person {FirstName = "Peter", LastName = "Petersen", Address = "18439 Stralsund", Color = "2"},
                new Person {FirstName = "Johnny", LastName = "Johnson", Address = "88888 made up", Color = "3"},
                new Person {FirstName = "Milly", LastName = "Millenium", Address = "77777 made up too", Color = "4"},
                new Person {FirstName = "Jonas", LastName = "Müller", Address = "32323 Hansstadt", Color = "5"},
                new Person {FirstName = "Tastatur", LastName = "Fujitsu", Address = "42342 Japan", Color = "6"},
                new Person {FirstName = "Anders", LastName = "Andersson", Address = "32132 Schweden - ☀", Color = "2"},
                new Person {FirstName = "Klaus", LastName = "Klaussen", Address = "43246 Hierach", Color = "2"}
            };

            yield return new object[] { csvfile1, true, true, resultExpected1 };
            yield return new object[] { csvfile1, false, true, resultExpected2 };
            yield return new object[] { csvfile1, true, false, resultExpected3 };
            yield return new object[] { csvfile1, false, false, resultExpected4 };
           
            yield return new object[] { csvfile2, true, true, resultExpected1 };
            yield return new object[] { csvfile2, false, false, resultExpected5 };
        }

        public static IEnumerable<object[]> GetTestDataForCsvColumns()
        {
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string csvfile1 = Path.Combine(directory, "TestFiles", "sample-input.csv");

            string[] csvColumns = new string[0];

            yield return new object[] { csvfile1, csvColumns };
            yield return new object[] { csvfile1, null };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return GetCsvFileReaderTestData().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
