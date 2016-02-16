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
            var filePath = converter.Convert(new GenerateSettings
                                             {
                                                 HtmlFileContent = "<b>Bold Text</b><br /><br /><i>Italic Text</i>",
                                                 OutputType = OutputType.PDF
                                             });
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
