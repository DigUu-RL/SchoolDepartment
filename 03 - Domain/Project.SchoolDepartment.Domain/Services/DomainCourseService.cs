﻿using AutoMapper;
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

public class DomainCourseService : IDomainCourseService
{
	private readonly ICourseRepository _courseRepository;
	private readonly IMapper _mapper;

	public DomainCourseService(ICourseRepository courseRepository, IMapper mapper)
	{
		_courseRepository = courseRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<CourseModel>> GetAllAsync(Search<CourseRequest> search)
	{
		Specification<Course> specification = new TrueSpecification<Course>();

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

		PaginatedList<Course> data = await _courseRepository.GetAllAsync(search.Page, search.Quantity, specification);

		var model = new PaginatedModel<CourseModel>
		{
			Page = data.Page,
			Pages = data.Pages,
			Total = data.Total,
			Data = _mapper.Map<List<CourseModel>>(data)
		};

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
}