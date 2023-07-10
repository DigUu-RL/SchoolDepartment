using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly IBaseRepository<Student> _studentRepository;
    private readonly IBaseRepository<Course> _courseRepository;

	public RepositoryWrapper(IStudentRepository studentRepository, ICourseRepository courseRepository)
	{
		_studentRepository = studentRepository;
		_courseRepository = courseRepository;
	}

    public IBaseRepository<Student> Student { get => _studentRepository; }
    public IBaseRepository<Course> Course { get => _courseRepository; }
	public IBaseRepository<School> School => throw new NotImplementedException();
}
