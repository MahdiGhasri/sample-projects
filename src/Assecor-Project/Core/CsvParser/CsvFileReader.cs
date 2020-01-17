using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Utility.Extensions;

namespace CsvParser
{
    /// <summary>
    /// Reading delimited-format data file.
    /// Passing file path and delimiters in constructor.
    /// Using TextFieldParser class to parse csv files.
    /// </summary>
    public class CsvFileReader : ICsvFileReader
    {
        private readonly DataTable _CsvData;
        private readonly Dictionary<string, string[]> _CsvFileErrors;
        private readonly string _FilePath;
        private readonly string _Delimiter =  ",";

        private const string COLUMN_ID_NAME = "Id";
        
        public CsvFileReader(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("file path cannot be null.");

            _FilePath = filePath;
            _CsvData = new DataTable();
            _CsvFileErrors = new Dictionary<string, string[]>();
        }
        public bool ShowRowNumberAsId { private get; set; } = true;
        public bool ShouldCorrectBrokenLines { private get; set; } = true;

        /// <summary>
        /// Reading a delimited-format file and map its data to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object which csv-data mapped to</typeparam>
        /// <param name="columnNames">Column names of csv file, mapped to object fields</param>
        /// <returns>List of object wich made from csv file</returns>
        public List<T> MapFileToObject<T>(string[] columnNames) where T : class
        {
            if (columnNames == null || columnNames.Length == 0)
                throw new ArgumentException("Columns cannot be null.");
            
            MakeDataTableColumn(columnNames);

            ReadCsvFile();

            CorrectBrokenLines();

            AddColumnId();

            return MapToObject<T>();
        }

        private void MakeDataTableColumn(string[] columnNames)
        {
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
            if (!File.Exists(_FilePath))
                throw new FileNotFoundException($"file not found: {_FilePath}");

            int lineNumber = 0;
            int dataTableColumnCount = _CsvData.Columns.Count;

            using var fileStream = File.OpenRead(_FilePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                lineNumber++;
                string[] csvFileValues = TrimFields(line.Split(_Delimiter));

                if (csvFileValues.Length == dataTableColumnCount)
                {
                    _CsvData.Rows.Add(csvFileValues);
                }
                else
                {
                    _CsvFileErrors.Add(lineNumber.ToString(), RemoveNullFields(csvFileValues));
                }
            }
        }
        private void CorrectBrokenLines()
        {
            if (!ShouldCorrectBrokenLines)
                return;

            if (_CsvFileErrors.Count == 0)
                return;

            const int copyArrayStartIndex = 0;
            int dataTableColumnCount = _CsvData.Columns.Count;

            string[] rowValues = new string[dataTableColumnCount];
            int index = copyArrayStartIndex;
            int insertPosition = int.Parse(_CsvFileErrors.Keys.FirstOrDefault()) - 1;

            foreach (string[] lineValues in _CsvFileErrors.Values)
            {
                lineValues.CopyTo(rowValues, index);
                index += lineValues.Length;

                if (index >= dataTableColumnCount)
                {
                    DataRow dataRow = _CsvData.NewRow();
                    dataRow.ItemArray = rowValues;

                    _CsvData.Rows.InsertAt(dataRow, insertPosition);

                    index = copyArrayStartIndex;
                    insertPosition++;
                }
            }
        }
        private string[] RemoveNullFields(string[] values)
        {
            return values.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
        }
        private string[] TrimFields(string[] values)
        {
            return values.Select(w => w.Trim()).ToArray();
        }
        private void AddColumnId()
        {
            if (!ShowRowNumberAsId)
                return;

            _CsvData.Columns.Add(new DataColumn(COLUMN_ID_NAME));

            for (int i = 0; i < _CsvData.Rows.Count; i++)
            {
                var row = _CsvData.Rows[i];
                row.SetField(COLUMN_ID_NAME, i + 1);
            }
        }

        private List<T> MapToObject<T>() where T : class
        {
            return _CsvData.ToJson().MapToObject<List<T>>();
        }
    }
}
