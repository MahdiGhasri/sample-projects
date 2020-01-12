using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace CsvParser
{
    /// <summary>
    /// Reading delimited-format data file.
    /// Passing file path and delimiters in constructor.
    /// Using TextFieldParser class to parse csv files.
    /// </summary>
    public class CsvFileReader : TextFieldParser, ICsvFileReader
    {
        public CsvFileReader(string path, string[] delimiter) : base(path)
        {
            SetDelimiters(delimiter);
            TrimWhiteSpace = true;
        }

        /// <summary>
        /// Reading a delimited-format file and map its data to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object which csv-data mapped to</typeparam>
        /// <param name="columnNames">Column names of csv file, mapped to object fields</param>
        /// <returns>List of object wich made from csv file</returns>
        public List<T> MapFileToObject<T>(string[] columnNames) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
