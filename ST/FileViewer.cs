using System;
using System.IO;
using System.Diagnostics;

public class FileViewer
{
    // Constructor
    public FileViewer(string fileUrl)
    {
        // Өгөгдсөн URL-ийн өргөтгөл шалгах
        string fileExtension = Path.GetExtension(fileUrl).ToLower();

        // Төрөл нь PDF эсвэл зураг бол дэлгэцэнд харуулах
        if (fileExtension == ".pdf")
        {
            ShowPdf(fileUrl);
        }
        else if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".bmp")
        {
            ShowImage(fileUrl);
        }
        else
        {
            // Бусад төрлийн файлыг татаж авах
            DownloadFile(fileUrl);
        }
    }

    // PDF файлыг үзүүлэх
    private void ShowPdf(string fileUrl)
    {
        string htmlContent = string.Format(@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>PDF Viewer</title>
    <style>
        body {{
            margin: 0;
            padding: 0;
        }}
        iframe {{
            width: 100%;
            height: 100vh;
            border: none;
        }}
    </style>
</head>
<body>
    <!-- PDF файлыг iframe ашиглан харуулах -->
    <iframe src=""{0}""></iframe>
</body>
</html>", fileUrl);

        // Түр HTML файл үүсгэх
        string tempFilePath = Path.Combine(Path.GetTempPath(), "tempPdfViewer.html");
        File.WriteAllText(tempFilePath, htmlContent);

        // Chrome хөтчийг app горимоор ажиллуулах
        Process.Start("chrome.exe", "--app=\"" + tempFilePath + "\"");
    }

    // Зургийн файлыг үзүүлэх
    private void ShowImage(string fileUrl)
    {
        string htmlContent = string.Format(@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Image Viewer</title>
    <style>
        body {{
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }}
        img {{
            max-width: 100%;
            max-height: 100%;
        }}
    </style>
</head>
<body>
    <!-- Зургийг img ашиглан харуулах -->
    <img src=""{0}"" alt=""Image"">
</body>
</html>", fileUrl);

        // Түр HTML файл үүсгэх
        string tempFilePath = Path.Combine(Path.GetTempPath(), "tempImageViewer.html");
        File.WriteAllText(tempFilePath, htmlContent);

        // Chrome хөтчийг app горимоор ажиллуулах
        Process.Start("chrome.exe", "--app=\"" + tempFilePath + "\"");
    }

    // Бусад төрлийн файлуудыг татаж авах
    private void DownloadFile(string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
        {
            throw new ArgumentException("File URL cannot be null or empty.");
        }

        // HTML агуулгыг татаж авах холбоостойгоор үүсгэх
        string htmlContent = string.Format(@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>File Download</title>
    <style>
        body {{
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            font-family: Arial, sans-serif;
        }}
        a {{
            font-size: 20px;
            color: #007BFF;
            text-decoration: none;
            border: 2px solid #007BFF;
            padding: 10px 20px;
            border-radius: 5px;
        }}
        a:hover {{
            background-color: #007BFF;
            color: #fff;
        }}
    </style>
</head>
<body>
    <a href=""{0}"" download>Шууд нээж харуулах боломжгүй файл тул энд дарж татаж авна уу.</a>
</body>
</html>", fileUrl);

        // Түр HTML файл үүсгэх
        string tempFilePath = Path.Combine(Path.GetTempPath(), "tempFileDownloader.html");
        File.WriteAllText(tempFilePath, htmlContent);

        // Chrome-ийг app горимоор ажиллуулж Address Bar-ийг нуух
        Process.Start("chrome.exe", "--app=\"" + tempFilePath + "\"");
    }

}
