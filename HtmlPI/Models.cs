using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlPI
{
    public enum OutputType
    {
        PDF,
        Image
    }
    public class GenerateSettings
    {
        public GenerateSettings()
        {
            GlobalOptions = new GlobalOptions();
            UsePrintMediaType = false;
        }
        /// <summary>
        /// Html Url, it must accessible from internet without any athentication
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Html content, like: <span>PDF Me</span>
        /// </summary>
        public string HtmlFileContent { get; set; }

        private OutputType _outputType = OutputType.PDF;

        /// <summary>
        /// OutputType
        /// Default: PDF
        /// </summary>
        public OutputType OutputType
        {
            get { return _outputType; }
            set { _outputType = value; }
        }
        public GlobalOptions GlobalOptions { get; set; }

        public bool UsePrintMediaType { get; set; }
    }
    public class GlobalOptions
    {
        private bool _collate = true;
        /// <summary>
        /// Collate when printing multiple copies.
        /// Default: true
        /// </summary>
        public bool Collate
        {
            get { return _collate; }
            set { _collate = value; }
        }
        private int _copies = 1;
        /// <summary>
        /// Number of copies to print into the pdf file.
        /// Default: 1
        /// </summary>
        public int Copies
        {
            get { return _copies; }
            set { _copies = value; }
        }
        private bool _grayscale = false;
        /// <summary>
        /// PDF will be generated in grayscale.
        /// Default: false
        /// </summary>
        public bool Grayscale
        {
            get { return _grayscale; }
            set { _grayscale = value; }
        }

        private string _marginBottom;
        public string MarginBottom
        {
            get { return _marginBottom; }
            set { _marginBottom = value; }
        }

        private string _marginLeft;
        public string MarginLeft
        {
            get { return _marginLeft; }
            set { _marginLeft = value; }
        }

        private string _marginRight;
        public string MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }
        private string _marginTop;
        public string MarginTop
        {
            get { return _marginTop; }
            set { _marginTop = value; }
        }

        private string _footerHtmlUrl;
        public string FooterHtmlUrl
        {
            get { return _footerHtmlUrl; }
            set { _footerHtmlUrl = value; }
        }

        private string _headerHtmlUrl;
        public string HeaderHtmlUrl
        {
            get { return _headerHtmlUrl; }
            set { _headerHtmlUrl = value; }
        }

        private bool _showHeaderLine;
        public bool ShowHeaderLine
        {
            get { return _showHeaderLine; }
            set { _showHeaderLine = value; }
        }
        private bool _showFooterLine;
        public bool ShowFooterLine
        {
            get { return _showFooterLine; }
            set { _showFooterLine = value; }
        }

    }
}
