﻿using Project.SchoolDepartment.Domain.Models.Contracts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public class SchoolModel : IModel
{
	public Guid? Id { get; set; }
	public Period? Period { get; set; }
	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }

	// relationships
	public Guid? CourseId { get; set; }
	public CourseModel? Course { get; set; }
	public ICollection<StudentModel>? Students { get; set; }
}
