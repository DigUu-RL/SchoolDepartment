using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public class AlunoDTO
{
	public string? Nome { get; set; }
	public string? Sobrenome { get; set; }
	public string? CPF { get; set; }
	public string? RA { get; set; }
	public Gender Genero { get; set; }
	public string? Logradouro { get; set; }
	public string? Bairro { get; set; }
	public int Numero { get; set; }
	public string? Cidade { get; set; }
	public string? UF { get; set; }
	public Guid CursoGuid { get; set; }
	public CursoDTO? Curso { get; set; }
	public Guid TurmaGuid { get; set; }
	public TurmaDTO? Turma { get; set; }
	public ICollection<TelefoneDTO>? Telefones { get; set; }
}
