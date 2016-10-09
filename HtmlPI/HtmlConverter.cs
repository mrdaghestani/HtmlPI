using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HtmlPI
{
    /// <summary>
    /// Convert Html to PDF or Image
    /// </summary>
    public class HtmlConverter
    {
        /// <summary>
        /// Don't check Console file existance everytime
        /// </summary>
        private static bool _consoleExist = false;

        private IConvertorSetting convertorSetting;
        private ITempFileProvider tempFile;
        public HtmlConverter(IConvertorSetting convertorSetting, ITempFileProvider tempFile)
        {
            this.convertorSetting = convertorSetting;
            this.tempFile = tempFile;
        }

        public HtmlConverter()
            : this(DefaultConvertorSetting.GetInstance(), DefaultTempFileProvider.GetInstance())
        {

        }

        public string Convert(GenerateSettings settings)
        {
            try
            {
                var content = (string)null;
                if (string.IsNullOrEmpty(settings.Url) && string.IsNullOrEmpty(settings.HtmlFileContent))
                {
                    throw new ArgumentException("There is nothing to convert...!");
                }
                else
                {
                    if (!string.IsNullOrEmpty(settings.Url))
                    {
                        content = settings.Url;
                    }
                    else
                    {
                        var inputFile = tempFile.GetNewPath(".html");
                        File.WriteAllText(inputFile, settings.HtmlFileContent, System.Text.Encoding.UTF8);
                        content = inputFile;
                    }
                }

                var isPdf = settings.OutputType == OutputType.PDF;
                var console = isPdf ? convertorSetting.ConsolePathPdf : convertorSetting.ConsolePathImage;

                #region Check Console Existance
                if (!_consoleExist)
                {
                    if (!File.Exists(console))
                    {
                        throw new Exception(string.Format("There is no wkhtmltopdf console on path:{0}{1}{0}{0}You have to install wkhtmltopdf before using this method.", Environment.NewLine, console));
                    }
                    _consoleExist = true;
                }
                #endregion


                var outputFile = isPdf ? tempFile.GetNewPath(".pdf") : tempFile.GetNewPath(".jpg");

                var p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = console;
                p.StartInfo.WorkingDirectory = convertorSetting.ConsoleWorkingDirectory;
                p.StartInfo.Arguments = GetArguments(settings) + " " + content + " " + outputFile;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                var checkCount = 0;
                var maxCheckCount = 100;
                while (!File.Exists(outputFile) && checkCount < maxCheckCount)
                {
                    checkCount++;
                    System.Threading.Thread.Sleep(50);
                }

                return outputFile;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetArguments(GenerateSettings settings)
        {
            var tmp = "";
            if (settings.UsePrintMediaType)
            {
                tmp += "--print-media-type";
            }
            switch (settings.OutputType)
            {
                case OutputType.PDF:
                    if (!settings.GlobalOptions.Collate)
                    {
                        tmp += " --no-collate";
                    }
                    if (settings.GlobalOptions.Grayscale)
                    {
                        tmp += " --grayscale";
                    }

                    if (!string.IsNullOrEmpty(settings.GlobalOptions.MarginBottom))
                    {
                        tmp += string.Format(" -B {0}", settings.GlobalOptions.MarginBottom);
                    }
                    if (!string.IsNullOrEmpty(settings.GlobalOptions.MarginLeft))
                    {
                        tmp += string.Format(" -L {0}", settings.GlobalOptions.MarginLeft);
                    }
                    if (!string.IsNullOrEmpty(settings.GlobalOptions.MarginRight))
                    {
                        tmp += string.Format(" -R {0}", settings.GlobalOptions.MarginRight);
                    }
                    if (!string.IsNullOrEmpty(settings.GlobalOptions.MarginTop))
                    {
                        tmp += string.Format(" -T {0}", settings.GlobalOptions.MarginTop);
                    }


                    if (!string.IsNullOrEmpty(settings.GlobalOptions.HeaderHtmlUrl))
                    {
                        tmp += string.Format(" --header-html {0}", settings.GlobalOptions.HeaderHtmlUrl);
                    }
                    if (!string.IsNullOrEmpty(settings.GlobalOptions.FooterHtmlUrl))
                    {
                        tmp += string.Format(" --footer-html {0}", settings.GlobalOptions.FooterHtmlUrl);
                    }

                    if (settings.GlobalOptions.ShowFooterLine)
                    {
                        tmp += " --footer-line";
                    }
                    if (settings.GlobalOptions.ShowHeaderLine)
                    {
                        tmp += " --header-line";
                    }

                    tmp += string.Format(" --copies {0}", settings.GlobalOptions.Copies);
                    break;
                case OutputType.Image:
                    break;
            }
            return tmp;
        }
    }
}
