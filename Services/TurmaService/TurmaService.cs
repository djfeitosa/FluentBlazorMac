using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentBlazorMac.Context;
using FluentBlazorMac.Entitys;
using FluentBlazorMac.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace FluentBlazorMac.Services.TurmaService
{
    public class TurmaService : ITurmaService
    {
        ConvertListTo convertListTo = new();
        private readonly AppDbContext _context;
        public TurmaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Turma> AddTurma(Turma turma)
        {
            ArgumentNullException.ThrowIfNull(turma);

            _context.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> DeleteTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            ArgumentNullException.ThrowIfNull(turma);
            _context.Remove(turma);
            return turma;
        }

        public async Task<Turma> GetTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            return turma ?? new Turma();
        }

        public async Task<List<SelectListItem>> GetListaTurmas()
        {
            var turmas = await _context.Turmas.Select(x => new SelectListItem
            {
                Text = x.Identificacao,
                Value = x.Id.ToString()
            }).ToListAsync();

            return turmas;
        }

        public async Task<IQueryable<Turma>> GetTurmas()
        {
            var turmas = await _context.Turmas.ToListAsync();
            return turmas.AsQueryable();
        }


        public async Task<Turma> UpdateTurma(Turma turma)
        {
            ArgumentNullException.ThrowIfNull(turma);

            _context.Entry(turma).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return turma;
        }
    }
}