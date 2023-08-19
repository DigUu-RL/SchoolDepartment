using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
	public CourseRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
