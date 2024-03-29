﻿using AutoMapper;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Helpers.Extensions;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Domain.Specs.Custom;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Abstractions;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainStudentService : IDomainStudentService
{
	private readonly IStudentRepository _studentRepository;
	private readonly IMapper _mapper;

	public DomainStudentService(IStudentRepository studentRepository, IMapper mapper)
	{
		_studentRepository = studentRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<StudentModel>> GetAsync(Search<StudentRequest> search)
	{
		Specification<Student> specification = GetSpecification(search);

		PaginatedList<Student> data = await _studentRepository.GetAsync(search.Page, search.Quantity, specification);

		return new PaginatedModel<StudentModel>
		{
			Page = data.Page,
			Pages = data.Pages,
			Total = data.Total,
			Data = _mapper.Map<List<StudentModel>>(data)
		};
	}

	public async Task<StudentModel> GetByIdAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByIdAsync(guid) ?? throw new NotFoundException("Aluno não encontrado!");

		StudentModel model = _mapper.Map<StudentModel>(data);
		return model;
	}

	public async Task CreateAsync(StudentRequest request)
	{
		var student = new Student
		{
			Name = request.Name!,
			LastName = request!.LastName!,
			CPF = request.CPF!,
			RA = Util.RandomString(80),
			Gender = request.Gender!.Value,
			Street = request.Street!,
			District = request.District!,
			Number = request.Number!.Value,
			City = request.City!,
			State = request.State!,
			CourseId = null,
			SchoolId = null
		};

		await _studentRepository.CreateAsync(student);
		await _studentRepository.CommitAsync();
	}

	public async Task UpdateAsync(StudentRequest request)
	{
		Student? student = await _studentRepository.GetByIdAsync(request.Id ?? Guid.Empty) 
			?? throw new NotFoundException("Aluno não encontrado!");

		student.Name = request.Name!;
		student.LastName = request.LastName!;
		student.Gender = request.Gender!.Value;
		student.Street = request.Street!;
		student.District = request.District!;
		student.Number = request.Number!.Value;
		student.City = request.City!;
		student.State = request.State!;

		await _studentRepository.UpdateAsync(student);
		await _studentRepository.CommitAsync();
	}

	public async Task DeleteAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByIdAsync(guid)
			?? throw new NotFoundException("Aluno não encontrado!");

		await _studentRepository.DeleteAsync(data);
		await _studentRepository.CommitAsync();
	}

	public Specification<Student> GetSpecification(Search<StudentRequest> search)
	{
		Specification<Student> specification = new TrueSpecification<Student>();

		if (search.Filter is not null)
		{
			if (search.Filter.Id is not null && search.Filter.Id != Guid.Empty)
				specification &= StudentSpecfication.ById(search.Filter.Id.Value);

			if (!string.IsNullOrEmpty(search.Filter.Name))
				specification &= StudentSpecfication.ByName(search.Filter.Name);

			if (!string.IsNullOrEmpty(search.Filter.LastName))
				specification &= StudentSpecfication.ByLastName(search.Filter.LastName);

			if (!string.IsNullOrEmpty(search.Filter.CPF))
				specification &= StudentSpecfication.ByCPF(search.Filter.CPF);

			if (!string.IsNullOrEmpty(search.Filter.RA))
				specification &= StudentSpecfication.ByRA(search.Filter.RA);

			if (search.Filter.Gender is not null && search.Filter.Gender.IsValid<Gender>())
				specification &= StudentSpecfication.ByGender(search.Filter.Gender.Value);

			if (!string.IsNullOrEmpty(search.Filter.Street))
				specification &= StudentSpecfication.ByStreet(search.Filter.Street);

			if (!string.IsNullOrEmpty(search.Filter.District))
				specification &= StudentSpecfication.ByDistrict(search.Filter.District);

			if (search.Filter.Number is not null && search.Filter.Number > 0)
				specification &= StudentSpecfication.ByNumber(search.Filter.Number.Value);

			if (!string.IsNullOrEmpty(search.Filter.City))
				specification &= StudentSpecfication.ByCity(search.Filter.City);

			if (!string.IsNullOrEmpty(search.Filter.State))
				specification &= StudentSpecfication.ByState(search.Filter.State);
		}

		return specification;
	}
}
