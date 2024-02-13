using ClosedXML.Excel;
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

        public async void SavelocalFile(XLWorkbook workbook, string nomeArquivo)
        {

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = $"{nomeArquivo}_{DateTime.Now.Ticks}.xlsx";
            Microsoft.AspNetCore.Mvc.FileContentResult file = new(content, contentType)
            {
                FileDownloadName = fileName
            };
            // string fileDestiny = $"ArquivosExcel/{fileName}";
            string downloadsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads";
            string path = Path.Combine(downloadsDirectory, fileName);
            await System.IO.File.WriteAllBytesAsync(path, content);
        }
    }
}