using Elera.Core.AppDbContext;
using Elera.Core.ViewModels;
using Elera.Services;
using Microsoft.AspNetCore.Mvc;


namespace Elera.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class EleraEmployeeController : ControllerBase
	{
		private readonly IEmployeeHelper _employeeHelper;
		private readonly AppDbContext db;
		public EleraEmployeeController(IEmployeeHelper employeeHelper, AppDbContext appDbContext)
		{
			_employeeHelper = employeeHelper;
			db = appDbContext;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var employees = _employeeHelper.FetchAllEmployees();
			return Ok(employees);
		}
		[HttpGet]
		public IActionResult Sort(string position, decimal Salary)
		{
			var employees = _employeeHelper.FetchAllEmployees();
			if (employees.Count == 0)
			{
				//Come back
				return BadRequest();
			}
			if (!string.IsNullOrEmpty(position))
			{
				employees = employees.Where(x => x.Position == position).ToList();
			}
			if (Salary != 0)
			{
				employees = employees.Where(x => x.Salary == Salary).ToList();
			}
			return Ok(employees);
		}
		[HttpGet("{id}")]
		public IActionResult GetEmployeeById(int id)
		{
			var employees = _employeeHelper.FetchAllEmployees();
			if (employees.Count != 0)
			{
				var employeeById = employees.FirstOrDefault(x => x.Id == id);
				return Ok(employeeById);
			}
			return BadRequest();
		}

		[HttpPost]
		public IActionResult Post([FromBody] EmployeeViewModel employeeViewModel)
		{
			var isAdded = _employeeHelper.Add(employeeViewModel);
			return isAdded ? Ok() : BadRequest();
		}
		[HttpPut]
		public IActionResult Put([FromBody] EmployeeViewModel employeeViewModel)
		{
			var isUpdated = _employeeHelper.UpdateEmployeeData(employeeViewModel);
			return isUpdated ? Ok() : BadRequest();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var isUpdated = _employeeHelper.DeleteEmployee(id);
			return isUpdated ? Ok() : BadRequest();
		}
	}
}
