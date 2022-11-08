﻿using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
{
	public AlunoRepository(Context context) : base(context) { }

	public override async Task<PaginatedList<Aluno>> GetAllAsync(int page, int quantity)
	{
		IQueryable<Aluno> query = Queryable
			.Include(a => a.Telefones)
			.Include(a => a.Curso)
			.Include(a => a.Turma);

		PaginatedList<Aluno> data = await PaginatedList<Aluno>.CreateInstanceAsync(query, page, quantity);
		return data;
	}
}
