using System.Collections.Generic;

namespace CsvParser
{
    public interface ICsvFileReader
    {
        List<T> MapFileToObject<T>(string[] columnNames) where T : class;
    }
}
