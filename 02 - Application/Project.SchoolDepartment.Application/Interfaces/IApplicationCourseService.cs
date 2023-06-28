using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationCourseService
{
	Task<PaginatedDTO<CourseDTO>> GetAllAsync(Search<CourseRequest> search);
	Task<CourseDTO> GetByIdAsync(Guid id);
	Task CreateAsync(CourseRequest request);
	Task UpdateAsync(CourseRequest request);
	Task DeleteAsync(Guid id);
}
