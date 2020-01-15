using System.Collections.Generic;

namespace CsvParser
{
    public interface ICsvFileReader
    {
        public bool ShowRowNumberAsId { set; }
        public bool ShouldCorrectBrokenLines { set; }
        List<T> MapFileToObject<T>(string[] columnNames) where T : class;
    }
}
