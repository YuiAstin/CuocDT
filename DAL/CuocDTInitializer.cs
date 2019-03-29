using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class CuocDTInitializer : CreateDatabaseIfNotExists<CuocDTContext>
	{
		protected override void Seed(CuocDTContext context)
		{
			base.Seed(context);

			var bills = new List<Bill>
			{ };

			var customers = new List<Customer>
			{
				new Customer
				{
					Address="Customer 1's address",
					CMND="111111111",
					Email="handoiditu1508@yahoo.com",
					Job="Unemployed",
					Name="Customer one"
				},
				new Customer
				{
					Address="Customer 2's address",
					CMND="222222222222",
					Email="handoiditu1508@yahoo.com",
					Job="Student",
					Name="Customer two",
					Position="Dun no"
				},
				new Customer
				{
					Address="Customer 3's address",
					CMND="333333333",
					Email="handoiditu1508@yahoo.com",
					Job="CEO of xXx",
					Name="Customer three",
					Position="CEO"
				}
			};

			var employees = new List<Employee>
			{
				new Employee
				{
					Name="admin guy",
					Username="root",
					Password="123456"
				}
			};

			var phoneNumbers = new List<PhoneNumber>
			{
				new PhoneNumber
				{
					Number="01111111111"
				},
				new PhoneNumber
				{
					Number="02222222222"
				},
				new PhoneNumber
				{
					Number="03333333333"
				},
				new PhoneNumber
				{
					Number="04444444444"
				},
				new PhoneNumber
				{
					Number="05555555555"
				},
				new PhoneNumber
				{
					Number="06666666666"
				}
			};

			var SIMs = new List<SIM>
			{ };

			//bills.ForEach(b => context.Bills.Add(b));

			customers.ForEach(c => context.Customers.Add(c));

			employees.ForEach(e => context.Employees.Add(e));

			phoneNumbers.ForEach(p => context.PhoneNumbers.Add(p));

			//SIMs.ForEach(s => context.SIMs.Add(s));

			context.SaveChanges();
		}
	}
}
