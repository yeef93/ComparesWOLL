﻿using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;

namespace CompareWOLL
{
    public class ExcelConvert
    {
            // Create an excel application object, workbook oject and worksheet object
            _Application excel = new _excel.Application();
            Workbook workbook;
            Worksheet worksheet;

            // Method creates a new Excel file by creating a new Excel workbook with a single worksheet
            public void NewFile()
            {
                this.workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                this.worksheet = this.workbook.Worksheets[1];
            }

            // Method adds a new worksheet to the existing workbook 
            public void NewSheet()
            {
                Worksheet newSheet = excel.Worksheets.Add(After: this.worksheet);
            }

            // Method saves workbook at a specified path
            public void SaveAs(string path)
            {
                workbook.SaveAs(path);
            }

            // Method closes Excel file
            public void Close()
            {
                workbook.Close();
            }
    }
}
