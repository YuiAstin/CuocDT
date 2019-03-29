using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class EmployeeExtensionMethod
	{
		public static EmployeeView ConvertToView(this Employee employee)
		{
			return new EmployeeView
			{
				Id = employee.ToString(),
				Name = employee.Name,
				Password = employee.Password,
				Username = employee.Username
			};
		}

		public static IEnumerable<EmployeeView> ConvertToViews(this IEnumerable<Employee> employees)
		{
			foreach(Employee employee in employees)
			{
				yield return employee.ConvertToView();
			}
		}
	}
}
