using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
	public StudentRepository(AppDbContext dbContext) : base(dbContext) { }

	public override async Task<PaginatedList<Student>> GetAllAsync(int page, int quantity)
	{
		IQueryable<Student> query = Query
			.Include(a => a.Cellphones)
			.Include(a => a.Course)
			.Include(a => a.School);

		PaginatedList<Student> data = await PaginatedList<Student>.CreateInstanceAsync(query, page, quantity);
		return data;
	}
}
