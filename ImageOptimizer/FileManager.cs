using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageOptimizer
{
    public class FileManager
    {
        public static IWorksheet GetSheet(string file, int sheetNumber)
        {
            var excelEngine = new ExcelEngine();
            if (string.IsNullOrWhiteSpace(file))
                return null;
            IWorksheet sheet;
            using (var stream = System.IO.File.Open(file, FileMode.Open, FileAccess.Read))
            {
                var workbook = excelEngine.Excel.Workbooks.Open(stream);
                sheet = workbook.Worksheets[sheetNumber];
            }
            return sheet;
        }
        public static string GetFileName(string path)
        {
            var values = path.Replace("\\", "/").Split("/");
            return values[values.Length - 1];
        }
    }
}
