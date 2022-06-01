namespace DXDY.REST.API.Models.Dtos
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Mobile { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
