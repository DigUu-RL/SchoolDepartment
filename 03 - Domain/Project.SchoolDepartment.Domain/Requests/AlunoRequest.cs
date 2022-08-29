﻿using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Requests;

public class AlunoRequest
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
	public List<TelefoneRequest>? Telefones { get; set; }
}
