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

        public void ConvertToExcel(List<Aluno> lista, string[] columnHeader)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Alunos");

                for (int i = 0; i < columnHeader.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = columnHeader[i];
                }

                for (int i = 0; i < lista.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = lista[i].Nome;
                    worksheet.Cell(i + 2, 2).Value = lista[i].Email;
                    worksheet.Cell(i + 2, 3).Value = lista[i].Idade;
                    worksheet.Cell(i + 2, 4).Value = lista[i].Turma.Descricao;
                }
                SavelocalFile(workbook);
            }
        }

        public void SavelocalFile(XLWorkbook workbook)
        {

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "planilha.xlsx";
                Microsoft.AspNetCore.Mvc.FileContentResult file = new Microsoft.AspNetCore.Mvc.FileContentResult(content, contentType);
                file.FileDownloadName = fileName;
                var path = @"/Users/djalmaf/Desenvolvimento/VS22/FluentBlazorMac/ArquivosExcel/" + fileName;
                System.IO.File.WriteAllBytes(path, content);
            }
        }
    }
}