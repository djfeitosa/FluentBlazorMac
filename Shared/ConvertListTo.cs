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

        public void ConvertToExcel(List<Aluno> alunos)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Alunos");

                worksheet.Cell(1, 1).Value = "Nome";
                worksheet.Cell(1, 2).Value = "Idade";

                for (int i = 0; i < alunos.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = alunos[i].Nome;
                    worksheet.Cell(i + 2, 2).Value = alunos[i].Idade;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    var fileName = "alunos.xlsx";
                    Microsoft.AspNetCore.Mvc.FileContentResult file = new Microsoft.AspNetCore.Mvc.FileContentResult(content, contentType);
                    file.FileDownloadName = fileName;
                }
            }
        }
    }
}