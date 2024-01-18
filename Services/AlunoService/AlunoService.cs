using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentBlazorMac.Context;
using FluentBlazorMac.Entitys;
using Microsoft.EntityFrameworkCore;

namespace FluentBlazorMac.Services.AlunoService
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            ArgumentNullException.ThrowIfNull(aluno);

            _context.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            ArgumentNullException.ThrowIfNull(aluno);
            _context.Remove(aluno);
            return aluno;
        }

        public async Task<Aluno> GetAluno(int? id)
        {
            var aluno = await _context.Alunos.Include(x => x.Turma).FirstOrDefaultAsync(x => x.Id == id);
            return aluno ?? new Aluno();
        }

        public async Task<IQueryable<Aluno>> GetAlunos()
        {
            var result = await _context.Alunos.Include(x => x.Turma).ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            ArgumentNullException.ThrowIfNull(aluno);

            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return aluno;
        }
    }
}