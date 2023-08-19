using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainCourseService
{
	Task<PaginatedModel<CourseModel>> GetAsync(Search<CourseRequest> search);
	Task<CourseModel> GetByIdAsync(Guid id);
	Task CreateAsync(CourseRequest request);
	Task UpdateAsync(CourseRequest request);
	Task DeleteAsync(Guid id);
}
