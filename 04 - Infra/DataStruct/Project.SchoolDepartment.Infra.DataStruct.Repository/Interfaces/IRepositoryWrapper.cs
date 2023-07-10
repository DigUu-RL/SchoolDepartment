using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IRepositoryWrapper
{
    public IBaseRepository<Student> Student { get; }
    public IBaseRepository<Course> Course { get; }
    public IBaseRepository<School> School { get; }
}
