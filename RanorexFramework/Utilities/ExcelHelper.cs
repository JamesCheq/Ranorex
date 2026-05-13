using System;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace MyTest1.Helpers
{
    public class ExcelHelper
    {
        private static string filePath = @"C:\Users\JamesFornis\Documents\Ranorex\RanorexStudio Projects\RanorexFramework\RanorexFramework\TestData\TestData.xlsx";

        // 🔹 Get value by column name and row index
        public static string GetValue(string sheetName, string columnName, int rowIndex)
        {
            DataTable dt = LoadSheet(sheetName);

            if (dt.Rows.Count == 0)
                throw new Exception("No data found in Excel sheet.");

            if (!dt.Columns.Contains(columnName))
                throw new Exception($"Column '{columnName}' not found.");

            if (rowIndex >= dt.Rows.Count)
                throw new Exception($"Row index '{rowIndex}' is out of range.");

            return dt.Rows[rowIndex][columnName].ToString();
        }

        // 🔹 Get single test value (first row)
        public static string GetSingleValue(string sheetName, string columnName)
        {
            return GetValue(sheetName, columnName, 0);
        }

        // 🔹 Load Excel sheet into DataTable
        private static DataTable LoadSheet(string sheetName)
        {
            if (!File.Exists(filePath))
                throw new Exception($"Excel file not found: {filePath}");

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var conf = new ExcelDataSetConfiguration
			{
			    ConfigureDataTable = _ => new ExcelDataTableConfiguration
			    {
			        UseHeaderRow = true
			    }
			};
			
			var result = reader.AsDataSet(conf);

                DataTable dt = result.Tables[sheetName];

                if (dt == null)
                    throw new Exception($"Sheet '{sheetName}' not found.");

                return dt;
            }
        }
    }
}