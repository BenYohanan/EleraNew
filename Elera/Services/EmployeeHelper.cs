using Elera.Core;
using Elera.Core.AppDbContext;
using Elera.Core.ViewModels;

namespace Elera.Services
{
	public class EmployeeHelper: IEmployeeHelper
	{
		private readonly AppDbContext db;
		public EmployeeHelper(AppDbContext db)
		{
			this.db = db;
		}

		public List<EmployeeViewModel> Fetch()
		{
			return db.Employees
				.Where(x=>x.Email != null)
				.Select(x=> new EmployeeViewModel
				{
					Id = x.Id,
					Name = x.Name,
					Email = x.Email,
					Salary = x.Salary,
					DateOfBirth = x.DateOfBirth,
					Position = x.Position,
				}).ToList();
		}
		public	bool Update(EmployeeViewModel employeeViewModel)
		{
			var employee = db.Employees.FirstOrDefault(x=>x.Id == employeeViewModel.Id);
			if (employee == null)
			{
				return false;
			}
			employee.Name = employeeViewModel.Name;
			employee.Salary = employeeViewModel.Salary;
			employee.Email = employeeViewModel.Email;
			employee.Position = employeeViewModel.Position;
			employee.DateOfBirth = employeeViewModel.DateOfBirth;
			db.Update(employee);
			db.SaveChanges();
			return true;
		}
		public bool Add(EmployeeViewModel employeeViewModel)
		{
			var employee = new Employee
			{
				Email = employeeViewModel.Email,
				Position = employeeViewModel.Position,
				Salary = employeeViewModel.Salary,
				Name = employeeViewModel.Name,
				DateOfBirth = employeeViewModel.DateOfBirth,
			};
			db.Add(employee);
			db.SaveChanges();
			return true;
		}
		public bool DeleteEmployee(int id)
		{
			var employee = db.Employees.FirstOrDefault(x => x.Id == id);
			if (employee == null)
			{
				return false;
			}
			db.Remove(employee); 
			db.SaveChanges();
			return true;
		}
	}

	public interface IEmployeeHelper
	{
		List<EmployeeViewModel> FetchAllEmployees();
		bool UpdateEmployeeData(EmployeeViewModel employeeViewModel);
		bool DeleteEmployee(int id);
		bool Add(EmployeeViewModel employeeViewModel);
	}
}
