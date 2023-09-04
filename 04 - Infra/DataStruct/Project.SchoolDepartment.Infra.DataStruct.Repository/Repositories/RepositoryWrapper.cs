using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
	public IBaseRepository<Student> Student { get; }
	public IBaseRepository<Course> Course { get; }
	public IBaseRepository<School> School { get; }

	public RepositoryWrapper(IStudentRepository studentRepository, ICourseRepository courseRepository, ISchoolRepository schoolrepository)
	{
		Student = studentRepository;
		Course = courseRepository;
		School = schoolrepository;
	}
}
