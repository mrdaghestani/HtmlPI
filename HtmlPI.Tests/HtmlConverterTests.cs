using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HtmlPI.Tests
{
    [TestClass]
    public class HtmlConverterTests
    {
        [TestMethod]
        public void ConvertHtmlContentToPdf()
        {
            var converter = new HtmlConverter();
            var setting = new GenerateSettings
            {
                HtmlFileContent = "<b>Bold Text</b><br /><br /><i>Italic Text</i>",
                OutputType = OutputType.PDF,
            };
            setting.GlobalOptions.FooterHtmlUrl = "http://www.oracle.com/splash/rpls/embargoed.html";
            setting.GlobalOptions.HeaderHtmlUrl = "http://wkhtmltopdf.org/libwkhtmltox/";

            setting.GlobalOptions.MarginTop = "30mm";
            setting.GlobalOptions.MarginBottom = "30mm";

            setting.GlobalOptions.ShowFooterLine = true;
            setting.GlobalOptions.ShowHeaderLine = true;

            var filePath = converter.Convert(setting);
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
