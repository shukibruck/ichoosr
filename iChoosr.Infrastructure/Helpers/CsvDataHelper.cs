using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace iChoosr.Infrastructure.Helpers
{
    internal static class CsvDataHelper
    {
        internal static IEnumerable<T> Read<T>(string path, CsvConfiguration? csvConfiguration = null)
            where T : class
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            List<T> records;

            try
            {
                var csvConfig = csvConfiguration ?? new CsvConfiguration(new CultureInfo("en-US", false))
                {
                    Delimiter = ";",
                    MissingFieldFound = null,
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, csvConfig);
                records = csv.GetRecords<T>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return records;
        }
    }
}
