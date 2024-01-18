using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentBlazorMac.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBlazorMac.Services.TurmaService
{
    public interface ITurmaService
    {
        Task<Turma> AddTurma(Turma turma);
        Task<Turma> DeleteTurma(int id);
        Task<List<SelectListItem>> GetListaTurmas();
        Task<Turma> GetTurma(int id);
        Task<IQueryable<Turma>> GetTurmas();
        Task<Turma> UpdateTurma(Turma turma);
        Task<IEnumerable<Turma>> Teste();
    }
}