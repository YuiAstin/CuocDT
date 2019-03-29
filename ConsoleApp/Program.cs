using BUS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			CustomerRepository customerRepository = new CustomerRepository();
			var x = customerRepository.Customers;
			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
