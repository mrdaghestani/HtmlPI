using System.IO;
namespace HtmlPI
{
    public class DefaultTempFileProvider : ITempFileProvider
    {
        private static DefaultTempFileProvider _instance;
        public static DefaultTempFileProvider GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DefaultTempFileProvider();
            }
            return _instance;
        }
        private DefaultTempFileProvider() { }
        string _tempFolderPath;
        public string TempFolderPath
        {
            get
            {
                return SettingProvider.GetFromAppSettingOrUseDefault(ref _tempFolderPath, "HtmlPI-TempFolderPath",
                    System.AppDomain.CurrentDomain.BaseDirectory + @"\Temp", x =>
                {
                    if (!Directory.Exists(x))
                    {
                        Directory.CreateDirectory(x);
                    }
                });
            }
        }
        public string GetNewPath(string extension = null)
        {
            var newFileName = string.Concat(System.Guid.NewGuid(), (string.IsNullOrEmpty(extension) ? ".tmp" : extension));
            var newFilePath = System.IO.Path.Combine(TempFolderPath, newFileName);
            return newFilePath;
        }
    }
}
