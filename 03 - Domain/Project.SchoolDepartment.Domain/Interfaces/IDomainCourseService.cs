using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainCourseService
{
	Task<PaginatedList<CourseModel>> GetAsync(Search<CourseRequest> search);
	Task<CourseModel> GetByIdAsync(Guid id);
	Task CreateAsync(CourseRequest request);
	Task UpdateAsync(CourseRequest request);
	Task DeleteAsync(Guid id);
}
