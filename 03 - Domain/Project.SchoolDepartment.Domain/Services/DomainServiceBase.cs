using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests.Contracts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Domain.Services;

public abstract class DomainServiceBase<TEntity, TRequest> where TRequest : class, IRequest where TEntity : EntityBase
{
	/// <summary>
	/// Valida todos os campos obrigatórios de um <see cref="TRequest"/> especificado.
	/// </summary>
	/// <param name="request"></param>
	/// <exception cref="NotImplementedException"></exception>
	public virtual void Validate(TRequest request)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Realiza a validação de todos os campos de uma determinada entidade e cria um <see cref="Specification{TEntity}"/> 
	/// com base nos campos a serem filtrados.
	/// </summary>
	/// <param name="search"></param>
	/// <returns>
	/// Uma <see cref="Specification{TEntity}"/> com base nos campos a serem filtrados. Caso o método não seja sobreescrito, 
	/// o valor padrão de retorno é <see cref="TrueSpecification{TEntity}"/>
	/// </returns>
	public virtual Specification<TEntity> GetSpecification(Search<TRequest> search)
	{
		return new TrueSpecification<TEntity>();
	}
}
