using iChoosr.Application.Helpers;
using iChoosr.Infrastructure.Helpers;

namespace iChoosr.Infrastructure.ApplicationContext
{
    public abstract class CsvContext<T>
        where T : class
    {
        protected IEnumerable<T> DataSet;

        private readonly string _filePath;

        protected CsvContext(string filePath)
        {
            _filePath = filePath;
            LoadData();
        }

        protected void LoadData()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                PrintHelper.PrintError("File path can't be empty");
                throw new ArgumentException();
            }

            var data = CsvDataHelper.Read<T>(_filePath).ToList();

            if (data.Any())
            {
                DataSet = data;
                return;
            }

            PrintHelper.PrintError($"Can not load data from file: {_filePath}");

            DataSet = data;
        }
    }
}
