using System;

namespace SolidRefactoringLab
{
    public interface IReportFormatter
    {
        string FormatReport();
    }

    // PDF Formatter
    public class PdfFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Formatting report as a PDF...";
        }
    }

    // Word Formatter
    public class WordFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Formatting report as a Word Document...";
        }
    }

    // Plain Text Formatter
    public class PlainTextFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Formatting report as plain text...";
        }
    }

    public class ReportManager
    {
        private readonly IReportFormatter _formatter;

        public string ReportData { get; set; } = string.Empty;

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            Console.WriteLine(_formatter.FormatReport());
        }
    }

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Choose the formatter (OCP)
            IReportFormatter formatter = new PdfFormatter();

            // 2. Pass it to the manager    
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}