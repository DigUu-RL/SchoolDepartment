using AutoMapper;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Specs.Custom;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainCourseService : DomainServiceBase<Course, CourseRequest>, IDomainCourseService
{
	private readonly ICourseRepository _courseRepository;
	private readonly IMapper _mapper;

	public DomainCourseService(ICourseRepository courseRepository, IMapper mapper)
	{
		_courseRepository = courseRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<CourseModel>> GetAsync(Search<CourseRequest> search)
	{
		Specification<Course> specification = GetSpecification(search);

		PaginatedList<Course> data = await _courseRepository.GetAsync(search.Page, search.Quantity, specification);

		PaginatedModel<CourseModel> model = new(data.Page, data.Pages, data.Total, _mapper.Map<List<CourseModel>>(data));
		return model;
	}

	public Task<CourseModel> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task CreateAsync(CourseRequest request)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(CourseRequest request)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public override Specification<Course> GetSpecification(Search<CourseRequest> search)
	{
		Specification<Course> specification = base.GetSpecification(search);

		if (search.Filter is not null)
		{
			if (!search.Filter.Id.Equals(Guid.Empty))
				specification &= CourseSpecification.ById(search.Filter.Id);

			if (!string.IsNullOrEmpty(search.Filter.Name))
				specification &= CourseSpecification.ByName(search.Filter.Name);

			if (!search.Filter.StudentId.Equals(Guid.Empty))
				specification &= CourseSpecification.ByStudentId(search.Filter.StudentId);

			if (!search.Filter.SchoolId.Equals(Guid.Empty))
				specification &= CourseSpecification.BySchoolId(search.Filter.SchoolId);
		}

		return specification;
	}
}
