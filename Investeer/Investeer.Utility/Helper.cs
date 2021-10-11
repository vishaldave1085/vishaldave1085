using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Investeer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Investeer.Utility
{
    public static class Helper
    {
        public static IEnumerable<T> ExcelToList<T>(this string filePath, string _userId, int SkipRow = 0)
        {
            List<T> list = new List<T>();
            var properties = typeof(T).GetProperties();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart wbpart = doc.WorkbookPart;
                int worksheetcount = doc.WorkbookPart.Workbook.Sheets.Count();

                for (int j = 0; j < worksheetcount; j++)
                {
                    Sheet sheet = (Sheet)doc.WorkbookPart.Workbook.Sheets.ChildElements.GetItem(j);
                    string sname = sheet.Name;
                    sname = sname.Split(" ").FirstOrDefault();

                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    foreach (Row row in rows)
                    {
                        if (row.RowIndex.Value < SkipRow)
                        {
                            continue;
                        }

                        else
                        {
                            if (j != 0 && row.RowIndex.Value == SkipRow)
                            {
                                continue;
                            }

                            var obj = (T)Activator.CreateInstance(typeof(T));
                            PropertyInfo props = obj.GetType().GetProperty("SheetName");
                            if (props != null) props.SetValue(obj, j == 0 && row.RowIndex.Value == SkipRow ? "County" : sname);

                            PropertyInfo statusId = obj.GetType().GetProperty("StatusId");
                            if (statusId != null) statusId.SetValue(obj, 1);

                            PropertyInfo AddedBy = obj.GetType().GetProperty("AddedBy");
                            if (AddedBy != null) AddedBy.SetValue(obj, _userId);


                            var cellValues = from cell in row.Descendants<Cell>()
                                             select cell;
                            int i = 0;
                            foreach (var cell in cellValues)
                            {
                                PropertyInfo prop = obj.GetType().GetProperty(Regex.Replace(Convert.ToString(cell.CellReference), @"[\d-]", string.Empty));
                                if (prop != null)
                                {
                                    prop.SetValue(obj, GetValue(doc, cell));
                                }
                                i++;
                            }
                            list.Add(obj);
                        }
                    }
                }

            }
            return list;
        }

        private static string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = string.Empty;
            if (cell.CellValue != null)
            {
                value = cell.CellValue.InnerText;
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                }
            }
            else
            {
                value = "0";
            }
            return value;
        }

        public static Func<T, T> DynamicSelectGenerator<T>(string Fields)
        {
            string[] EntityFields;
            if (Fields == "")
                EntityFields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
            else
                EntityFields = Fields.Split(',');

            var xParameter = Expression.Parameter(typeof(T), "o");

            var xNew = Expression.New(typeof(T));

            var bindings = EntityFields.Select(o => o.Trim())
                .Select(o =>
                {

                    var mi = typeof(T).GetProperty(o);

                    var xOriginal = Expression.Property(xParameter, mi);

                    return Expression.Bind(mi, xOriginal);
                }
            );

            var xInit = Expression.MemberInit(xNew, bindings);

            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            return lambda.Compile();
        }


        public static string ReadFile(this string _path)
        {
            if (File.Exists(_path))
            {
                StreamReader str = new StreamReader(_path);
                string MailText = str.ReadToEnd();
                str.Close();
                return MailText;
            }
            else
            {
                return null;
            }
        }

        public static string PrepareTemplate<T, S, U>(this string TemplateString, T obj, S obj2, U obj3)
        {
            if (obj != null)
            {
                var properties = typeof(T).GetProperties();
                if (properties != null)
                {
                    foreach (var prop in properties)
                    {
                        TemplateString = TemplateString.Replace("{" + prop.Name + "}", Convert.ToString(prop.GetValue(obj)));
                    }
                }
            }
            if (obj2 != null)
            {
                var properties = typeof(S).GetProperties();
                if (properties != null)
                {
                    foreach (var prop in properties)
                    {
                        TemplateString = TemplateString.Replace("{" + prop.Name + "}", Convert.ToString(prop.GetValue(obj2)));
                    }
                }
            }
            if (obj3 != null)
            {
                var properties = typeof(U).GetProperties();
                if (properties != null)
                {
                    foreach (var prop in properties)
                    {
                        TemplateString = TemplateString.Replace("{" + prop.Name + "}", Convert.ToString(prop.GetValue(obj3)));
                    }
                }
            }
            return TemplateString;
        }

    }
}
