using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
{
	public AlunoRepository(Context context) : base(context) { }

	public async Task<Paginated<Aluno>> GetAllAsync(int page, int quantity)
	{
		IQueryable<Aluno> query = Entity
			.Include(aluno => aluno.Curso)
			.Include(aluno => aluno.Telefones)
			.Include(aluno => aluno.Turma);

		Paginated<Aluno> data = await Paginated<Aluno>.CreateAsync(query, page, quantity);
		return data;
	}
}
