using System;
using ClosedXML.Excel;

class ExcelPractice
{
    public static void WorkWithExcel()
    {
        string filePath = @"C:\Users\Praveen.S3\Downloads\contacts.xlsx";

        XLWorkbook workbook = new XLWorkbook(filePath);
        var workSheet = workbook.Worksheet(1);
        Console.WriteLine(workSheet);
        if (workSheet == null)
        {
            Console.WriteLine("worksheet is null");
        }
        else
        {
            foreach (var row in workSheet.RowsUsed())
            {
                foreach (var cell in row.CellsUsed())
                {
                    Console.Write(cell.GetString() + "\t");
                }
                Console.WriteLine();
            }
        }


        //if (System.IO.File.Exists(filePath))
        //{
        //    workbook = new XLWorkbook(filePath);
        //    var ws = workbook.Worksheets.Add("Contacts");
        //    ws.Cell(1, 1).Value = "Name";
        //    ws.Cell(1, 2).Value = "Phone";
        //    ws.Cell(1, 3).Value = "Email";
        //}
        //else
        //{
        //    workbook = new XLWorkbook();
        //    var ws = workbook.Worksheets.Add("Contacts");
        //    ws.Cell(1, 1).Value = "Name";
        //    ws.Cell(1, 2).Value = "Phone";
        //    ws.Cell(1, 3).Value = "Email";
        //}
        //var worksheet = workbook.Worksheet("Contacts");
        //int lastRow = worksheet.LastRowUsed().RowNumber();
        //int newRow = lastRow + 1;

        //worksheet.Cell(newRow, 1).Value = "Pandu";
        //worksheet.Cell(newRow, 2).Value = "9876543210";
        //worksheet.Cell(newRow, 3).Value = "Pandu@gmail.com";

        //workbook.SaveAs(filePath);
        //Console.WriteLine("Contact added successfully");
    }
}
