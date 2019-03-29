using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class CustomerExtensionMethod
	{
		public static CustomerView ConvertToView(this Customer customer)
		{
			return new CustomerView
			{
				Id = customer.Id.ToString(),
				Name = customer.Name,
				CMND = customer.CMND,
				Email = customer.Email,
				Address = customer.Address,
				Job = customer.Job,
				Position = customer.Position,
				SIMs = customer.SIMs.ConvertToViews().ToList()
			};
		}

		public static IEnumerable<CustomerView> ConvertToViews(this IEnumerable<Customer> customers)
		{
			foreach(Customer customer in customers)
			{
				yield return customer.ConvertToView();
			}
		}
	}
}
