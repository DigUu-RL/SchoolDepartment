using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Aluno : Base
{
	public string? Nome { get; set; }
	public string? Sobrenome { get; set; }
	public string? CPF { get; set; }
	public string? RA { get; set; }
	public Genero Genero { get; set; }
	public string? Logradouro { get; set; }
	public string? Bairro { get; set; }
	public int Numero { get; set; }
	public string? Cidade { get; set; }
	public string? UF { get; set; }

	// relationships
	public Guid CursoGuid { get; set; }
	public Curso? Curso { get; set; }
	public Guid TurmaGuid { get; set; }
	public Turma? Turma { get; set; }
	public ICollection<Telefone>? Telefones { get; set; }
}
