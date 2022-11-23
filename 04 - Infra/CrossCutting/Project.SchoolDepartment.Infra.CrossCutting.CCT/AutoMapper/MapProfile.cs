using AutoMapper;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT.AutoMapper;

public sealed class MapProfile : Profile
{
	public new IMappingExpression CreateMap(Type sourceType, Type destinationType)
	{
		return base.CreateMap(sourceType, destinationType);
	}

	public new IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
	{
		return base.CreateMap<TSource, TDestination>();
	}
}
