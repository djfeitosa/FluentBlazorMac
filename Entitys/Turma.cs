using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentBlazorMac.Entitys
{
    [Table("turma")]
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string? Identificacao { get; set; }
        public string? Descricao { get; set; } = string.Empty;
        public int NumMaximoAlunos { get; set; } = 10;
    }
}