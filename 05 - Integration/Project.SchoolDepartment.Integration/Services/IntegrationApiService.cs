using Project.SchoolDepartment.Integration.Interfaces;

namespace Project.SchoolDepartment.Integration.Services;

public class IntegrationApiService : IIntegrationApiService
{
	private readonly HttpClient _http;

	public IntegrationApiService()
	{
		_http = new HttpClient();
	}
}
