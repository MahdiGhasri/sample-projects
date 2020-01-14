using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
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
        private readonly string[] _Delimiters = new string[] { "," };

        private const string COLUMN_ID_NAME = "Id";
        
        public CsvFileReader(string path) : base(path)
        {
            SetDelimiters(_Delimiters);
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

            while (!EndOfData)
            {
                string[] csvFileValues = ReadFields();

                if (csvFileValues.Length == dataTableColumnCount)
                {
                    _CsvData.Rows.Add(csvFileValues);
                }
                else
                {
                    string key = LineNumber.ToString();
                    _CsvFileErrors.Add(key, RemoveNullFields(csvFileValues));
                }
            }
        }
        private void CorrectBrokenLines()
        {
            if (!IsCorrectBrokenLines)
                return;

            if (_CsvFileErrors.Count == 0)
                return;

            const int copyArrayStartIndex = 0;
            int dataTableColumnCount = _CsvData.Columns.Count;

            string[] rowValues = new string[dataTableColumnCount];
            int index = copyArrayStartIndex;
            int insertPosition = int.Parse(_CsvFileErrors.Keys.FirstOrDefault()) - 2;

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
        private void VerifyExistanceOfColumnId()
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
            string jsonString = JsonConvert.SerializeObject(_CsvData);

            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
    }
}
