using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public class TurmaDTO
{
	public Guid Guid { get; set; }
	public int QuantidadeAlunos { get; set; }
	public Periodo Periodo { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
	public Guid CursoGuid { get; set; }
	public CursoDTO? Curso { get; set; }
	public ICollection<AlunoDTO>? Alunos { get; set; }
}
