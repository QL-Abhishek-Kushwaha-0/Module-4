using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTO
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
