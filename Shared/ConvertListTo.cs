using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using FluentBlazorMac.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.FluentUI.AspNetCore.Components;

namespace FluentBlazorMac.Shared
{
    public class ConvertListTo
    {
        public List<Option<string>> ConvertToOption(List<SelectListItem> lista)
        {

            List<Option<string>> option = [];

            lista.ForEach(item => option.Add(new Option<string> { Value = item.Value, Text = item.Text }));

            return option;
        }

        public void SavelocalFile(XLWorkbook workbook, string nomeArquivo)
        {

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = $"{nomeArquivo}.xlsx";
                Microsoft.AspNetCore.Mvc.FileContentResult file = new(content, contentType)
                {
                    FileDownloadName = fileName
                };
                string fileDestiny = $"ArquivosExcel/{fileName}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), fileDestiny);
                System.IO.File.WriteAllBytes(path, content);
            }
        }
    }
}