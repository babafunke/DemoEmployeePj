namespace DemoEmployeeMvcClient.Models
{
    public class EmployeeGetDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
