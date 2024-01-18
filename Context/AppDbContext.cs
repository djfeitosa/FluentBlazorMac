using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentBlazorMac.Entitys;
using Microsoft.EntityFrameworkCore;

namespace FluentBlazorMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}