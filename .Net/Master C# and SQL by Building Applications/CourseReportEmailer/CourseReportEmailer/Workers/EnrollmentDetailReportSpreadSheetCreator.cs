using CourseReportEmailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;

namespace CourseReportEmailer.Workers
{
    internal class EnrollmentDetailReportSpreadSheetCreator
    {
        public void Create(string fileName, IList<EnrollmentDetailReportModel> enrollmentsModels)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                var json = JsonConvert.SerializeObject(enrollmentsModels);
                System.Data.DataTable enrollmentsTable = (System.Data.DataTable) JsonConvert.DeserializeObject(json, typeof(System.Data.DataTable));

                //Create Workbook
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                //Create Worksheet                
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                //Create Sheetdata
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                //Create Sheet List
                Sheets sheetList = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

                //Creat a Sheet
                Sheet singleSheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Report Sheet"
                };
                //This "Sheet" is the "Worksheet" whitch gets added to the "Sheet List" whitch is a part of the "Workbook"
                sheetList.Append(singleSheet);

                Row excelTitleRow = new Row();

                foreach (DataColumn tableColumn in enrollmentsTable.Columns)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(tableColumn.ColumnName);
                    excelTitleRow.Append(cell);
                }

                sheetData.AppendChild(excelTitleRow);

                foreach (DataRow tableRow in enrollmentsTable.Rows)
                {
                    Row excelNewRow = new Row();
                    foreach (DataColumn tableColumn in enrollmentsTable.Columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(tableRow[tableColumn.ColumnName].ToString());
                        excelNewRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(excelNewRow);
                }
                workbookPart.Workbook.Save();
            }
        }
    }
}
