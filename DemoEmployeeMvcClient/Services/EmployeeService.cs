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
            //Create the httpclient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            //instantiate the HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7272/api/employee");

            //Convert the EmployeeCreateDto object into a Json string
            string jsonBody = JsonConvert.SerializeObject(employeeCreateDto);

            //Instantiate the StringContent using the json string and encoding. This provides Http Content based on a string
            StringContent body = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

            //Assign the body as the value to the property content of the HttpRequestMessage instance
            request.Content = body;

            //Send the request which returns back an HttpResponseMessage
            HttpResponseMessage response = await httpClient.SendAsync(request);

            //Check the status code of the response
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            //Read the response returned from the API as a string
            string content = await response.Content.ReadAsStringAsync();

            if(content is not "Successful")
            {
                return false;
            }
            return true;
        }

        public async Task<List<EmployeeGetDto>> GetAll()
        {
            //Create the httpclient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            //instantiate the HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7272/api/employee");

            //Send the request which returns back an HttpResponseMessage
            HttpResponseMessage response = await httpClient.SendAsync(request);

            //Check the status code of the response
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            //Read the response returned from the API as a string
            string content = await response.Content.ReadAsStringAsync();

            //Convert the json string into a List<EmployeeGetDto> object
            List<EmployeeGetDto> employees = JsonConvert.DeserializeObject<List<EmployeeGetDto>>(content);

            return employees;
        }
    }
}
