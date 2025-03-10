using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }  // Globally Unique ID type
        public required string Name { get; set; }  // Name will be validated at Compile Time

        [Required]  // Email will be validated at runtime
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
