using System.ComponentModel.DataAnnotations;

namespace Elera.Core
{
	public class Employee
	{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
    }
}
