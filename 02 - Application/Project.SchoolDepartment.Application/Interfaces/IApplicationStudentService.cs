using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationStudentService : IApplicationServiceBase<StudentDTO, StudentRequest>
{
}
