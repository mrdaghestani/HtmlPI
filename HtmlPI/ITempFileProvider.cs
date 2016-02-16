using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlPI
{
    public interface ITempFileProvider
    {
        string GetNewPath(string extension = null);
    }
}
