using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
	public class EmployeeRepository
	{
		private CuocDTContext context;

		public EmployeeRepository()
		{
			context = CuocDTContext.Instance;
		}

		public IList<Employee> Employees
		{
			get
			{
				return context.Employees.ToList();
			}
		}

		public Employee GetEmployee(int id)
		{
			return context.Employees.Find(id);
		}

		public Employee GetEmployee(string username)
		{
			return context.Employees.FirstOrDefault(e => e.Username == username);
		}

		public void AddEmployee(Employee employee)
		{
			context.Employees.Add(employee);
			context.SaveChanges();
		}

		public void RemoveEmployee(int id)
		{
			Employee employee = context.Employees.Find(id);
			context.Employees.Remove(employee);
			context.SaveChanges();
		}

		public void RemoveEmployee(string username)
		{
			Employee employee = GetEmployee(username);
			context.Employees.Remove(employee);
			context.SaveChanges();
		}

		public void EditEmployee(int id, Employee newEmployee)
		{
			Employee oldEmployee = context.Employees.Find(id);
			if (oldEmployee != null)
			{
				oldEmployee.Name = newEmployee.Name;
				oldEmployee.Password = newEmployee.Password;
				oldEmployee.Username = newEmployee.Username;
				context.SaveChanges();
			}
		}

		public void EditEmployee(string username, Employee newEmployee)
		{
			Employee oldEmployee = GetEmployee(username);
			if (oldEmployee != null)
			{
				oldEmployee.Name = newEmployee.Name;
				oldEmployee.Password = newEmployee.Password;
				oldEmployee.Username = newEmployee.Username;
				context.SaveChanges();
			}
		}
	}
}
