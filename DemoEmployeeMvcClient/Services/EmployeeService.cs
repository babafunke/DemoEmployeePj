using DemoEmployeeMvcClient.Models;
using Newtonsoft.Json;


namespace DemoEmployeeMvcClient.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7272/api/employee");

            string jsonBody = JsonConvert.SerializeObject(employeeCreateDto);

            StringContent body = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

            request.Content = body;

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            string content = await response.Content.ReadAsStringAsync();

            if(content is not "Successful")
            {
                return false;
            }
            return true;
        }

        public async Task<List<EmployeeGetDto>> GetAll()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7272/api/employee");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();

            List<EmployeeGetDto> employees = JsonConvert.DeserializeObject<List<EmployeeGetDto>>(content);

            return employees;
        }
    }
}
