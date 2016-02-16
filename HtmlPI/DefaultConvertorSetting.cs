
namespace HtmlPI
{
    public class DefaultConvertorSetting : IConvertorSetting
    {
        private static DefaultConvertorSetting _instance;
        public static DefaultConvertorSetting GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DefaultConvertorSetting();
            }
            return _instance;
        }

        private DefaultConvertorSetting() { }

        string _consolePathPdf;
        string _consolePathImage;
        string _consoleWorkingDirectory;
        public string ConsolePathPdf
        {
            get
            {
                return SettingProvider.GetFromAppSettingOrUseDefault(ref _consolePathPdf, "HtmlPI-ConsolePathPdf", @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe");
            }
        }

        public string ConsolePathImage
        {
            get
            {
                return SettingProvider.GetFromAppSettingOrUseDefault(ref _consolePathImage, "HtmlPI-ConsolePathImage", @"C:\Program Files\wkhtmltopdf\bin\wkhtmltoimage.exe");
            }
        }

        public string ConsoleWorkingDirectory
        {
            get
            {
                return SettingProvider.GetFromAppSettingOrUseDefault(ref _consoleWorkingDirectory, "HtmlPI-ConsoleWorkingDirectory", @"C:\Program Files\wkhtmltopdf\bin");
            }
        }

    }
}
