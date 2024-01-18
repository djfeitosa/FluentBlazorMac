using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentBlazorMac.Entitys
{
    [Table("aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Foto { get; set; }
        public int Idade { get; set; }

        //-------Dados da tabela Turma -------------
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}