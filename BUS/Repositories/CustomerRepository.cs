using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
	public class CustomerRepository
	{
		private CuocDTContext context;

		public CustomerRepository()
		{
			context = CuocDTContext.Instance;
		}

		public IList<Customer> Customers
		{
			get
			{
				return context.Customers.ToList();
			}
		}

		public Customer GetCustomer(int id)
		{
			return context.Customers.Find(id);
		}

		public Customer GetCustomer(string cmnd)
		{
			return context.Customers.FirstOrDefault(c => c.CMND == cmnd);
		}

		public void AddCustomer(Customer customer)
		{
			context.Customers.Add(customer);
			context.SaveChanges();
		}

		public void RemoveCustomer(int id)
		{
			Customer customer = GetCustomer(id);
			context.Customers.Remove(customer);
			context.SaveChanges();
		}

		public void RemoveCustomer(string cmnd)
		{
			Customer customer = GetCustomer(cmnd);
			context.Customers.Remove(customer);
			context.SaveChanges();
		}

		public void EditCustomer(int id, Customer newCustomer)
		{
			Customer oldCustomer = GetCustomer(id);
			if (oldCustomer != null)
			{
				oldCustomer.Address = newCustomer.Address;
				oldCustomer.CMND = newCustomer.CMND;
				oldCustomer.Job = newCustomer.Job;
				oldCustomer.Name = newCustomer.Name;
				oldCustomer.Position = newCustomer.Position;
				context.SaveChanges();
			}
		}

		public void EditCustomer(string cmnd, Customer newCustomer)
		{
			Customer oldCustomer = GetCustomer(cmnd);
			if (oldCustomer != null)
			{
				oldCustomer.Address = newCustomer.Address;
				oldCustomer.CMND = newCustomer.CMND;
				oldCustomer.Job = newCustomer.Job;
				oldCustomer.Name = newCustomer.Name;
				oldCustomer.Position = newCustomer.Position;
				context.SaveChanges();
			}
		}
	}
}
