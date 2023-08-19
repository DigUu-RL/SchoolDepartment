using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainSchoolService : IDomainServiceBase<SchoolModel, SchoolRequest>
{
}
