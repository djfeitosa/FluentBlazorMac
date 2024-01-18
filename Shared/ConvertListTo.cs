using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}