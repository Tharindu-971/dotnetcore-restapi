using System.ComponentModel.DataAnnotations;

namespace DXDY.REST.API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Mobile { get; set; }

        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
