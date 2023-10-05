using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainStudentService : IDomainServiceBase<StudentModel, StudentRequest>
{
	
}
