using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentBlazorMac.Entitys;

namespace FluentBlazorMac.Services.AlunoService
{
    public interface IAlunoService
    {
        Task<Aluno> AddAluno(Aluno aluno);
        Task<Aluno> DeleteAluno(int id);
        Task<Aluno> GetAluno(int? id);
        Task<IQueryable<Aluno>> GetAlunos();
        Task<Aluno> UpdateAluno(Aluno aluno);
    }
}