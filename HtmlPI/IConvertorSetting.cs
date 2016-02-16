using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlPI
{
    public interface IConvertorSetting
    {
        string ConsolePathPdf { get; }
        string ConsolePathImage { get; }
        string ConsoleWorkingDirectory { get; }
    }
}
