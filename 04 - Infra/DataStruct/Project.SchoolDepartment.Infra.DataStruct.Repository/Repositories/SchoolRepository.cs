using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class SchoolRepository : BaseRepository<School>, ISchoolRepository
{
	public SchoolRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
