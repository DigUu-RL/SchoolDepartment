using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class AlunoRepository : IAlunoRepository
{
	private readonly Context _context;

	public AlunoRepository(Context context)
	{
		_context = context;
	}

	public async Task<Paginated<Aluno>> GetAllAsync(int page, int quantity)
	{
		IQueryable<Aluno> query = _context.Aluno.Include(x => x.Telefones);

		Paginated<Aluno> data = await Paginated<Aluno>.CreateAsync(query, page, quantity);
		return data;
	}

	public async Task<Aluno?> GetByGuidAsync(Guid guid)
	{
		Aluno? data = await _context.Aluno.FindAsync(guid);
		return data;
	}

	public async Task CreateAsync(Aluno aluno)
	{
		_context.Entry(aluno).State = EntityState.Added;
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Aluno aluno)
	{
		_context.Update(aluno);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Aluno aluno)
	{
		_context.Remove(aluno);
		await _context.SaveChangesAsync();
	}
}
