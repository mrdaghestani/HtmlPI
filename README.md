# HtmlPI

[wkhtmltopdf](http://wkhtmltopdf.org) wrapper to convert Html to PDF/Image

## Installation

First you have to install [wkhtmltopdf](http://wkhtmltopdf.org/downloads.html) on application server (your developing system or client's systems)

Then simply install HtmlPi package from [NuGet](https://www.nuget.org/packages/HtmlPi.dll):

```
PM> Install-Package HtmlPi.dll
```

Or just add a reference to `HtmlPI.dll`

> If you don't want to install [wkhtmltopdf](http://wkhtmltopdf.org) on application server or client's systems, you can use [HtmlToPdfOrImage](https://github.com/mrdaghestani/HtmlToPdfOrImage) to convert html.

## Usage

```
var converter = new HtmlConverter();
var filePath = converter.Convert(new GenerateSettings
                                  {
                                     HtmlFileContent = "<b>Bold Text</b><br /><br /><i>Italic Text</i>",
                                     OutputType = OutputType.PDF
                                  });
```

## Options

Customizing PDF is available, just Under Construction

## Demo

[Demo Website](http://htmltopdforimage.com)

## License

Released under the MIT license.

Created by MohammadReza Daghestani, [ADAK SYS Co.](http://adaksys.com/)
