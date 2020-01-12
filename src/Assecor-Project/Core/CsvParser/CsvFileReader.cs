using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CsvParser
{
    /// <summary>
    /// Reading delimited-format data file.
    /// Passing file path and delimiters in constructor.
    /// Using TextFieldParser class to parse csv files.
    /// </summary>
    public class CsvFileReader : TextFieldParser, ICsvFileReader
    {
        private readonly DataTable _CsvData;
        private readonly Dictionary<string, string[]> _CsvFileErrors;

        private const string COLUMN_ID_NAME = "Id";
        
        public CsvFileReader(string path, string[] delimiter) : base(path)
        {
            SetDelimiters(delimiter);
            TrimWhiteSpace = true;

            _CsvData = new DataTable();
            _CsvFileErrors = new Dictionary<string, string[]>();
        }

        public bool ShowRowNumberAsId { private get; set; } = true;
        public bool IsCorrectBrokenLines { private get; set; } = true;

        /// <summary>
        /// Reading a delimited-format file and map its data to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object which csv-data mapped to</typeparam>
        /// <param name="columnNames">Column names of csv file, mapped to object fields</param>
        /// <returns>List of object wich made from csv file</returns>
        public List<T> MapFileToObject<T>(string[] columnNames) where T : class
        {
            MakeDataTableColumn(columnNames);

            ReadCsvFile();

            CorrectBrokenLines();

            VerifyExistanceOfColumnId();

            return MapToObject<T>();
        }

        private void MakeDataTableColumn(string[] columnNames)
        {

            _CsvData.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                ColumnName = COLUMN_ID_NAME
            });
            
            foreach (string columnName in columnNames)
            {
                _CsvData.Columns.Add(new DataColumn()
                {
                    AllowDBNull = true,
                    ColumnName = columnName
                });
            }
        }

        private void ReadCsvFile()
        {
            int dataTableColumnCount = _CsvData.Columns.Count;
            int csvFileColumnCount = dataTableColumnCount - 1;
            int Id = 0;

            while (!EndOfData)
            {
                string[] dataTableRowValues = new string[dataTableColumnCount];
                string[] csvFileValues = RemoveNullFields(ReadFields());

                csvFileValues.CopyTo(dataTableRowValues, 1);

                if (csvFileValues.Length == csvFileColumnCount)
                {
                    dataTableRowValues[0] = (++Id).ToString();
                    _CsvData.Rows.Add(dataTableRowValues);
                }
                else
                {
                    _CsvFileErrors.Add(LineNumber.ToString(), csvFileValues);
                }
            }
        }
        private void CorrectBrokenLines()
        {
            if (!IsCorrectBrokenLines)
                return;

            if (_CsvFileErrors.Count == 0)
                return;

            int dataTableColumnCount = _CsvData.Columns.Count;

            string[] rowValues = new string[dataTableColumnCount];
            int index = 1;

            foreach (string[] lineValues in _CsvFileErrors.Values)
            {
                lineValues.CopyTo(rowValues, index);
                index += lineValues.Length;

                if(index >= dataTableColumnCount)
                {
                    long Id = _CsvData.Rows.Count + 1;
                    rowValues[0] = Id.ToString();
                    _CsvData.Rows.Add(rowValues);

                    index = 0;
                }
            }
        }
        private string[] RemoveNullFields(string[] values)
        {
            return values.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
        }
        private void VerifyExistanceOfColumnId()
        {
            if (!ShowRowNumberAsId)
                _CsvData.Columns.Remove(COLUMN_ID_NAME);
        }

        private List<T> MapToObject<T>() where T : class
        {
            string jsonString = JsonConvert.SerializeObject(_CsvData);

            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
    }
}
