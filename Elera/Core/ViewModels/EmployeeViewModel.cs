namespace Elera.Core.ViewModels
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Position { get; set; }
		public decimal? Salary { get; set; }
	}
}
