using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class CuocDTContext : DbContext
	{
		private static CuocDTContext uniqueInstance;

		public DbSet<Bill> Bills { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<PhoneNumber> PhoneNumbers { get; set; }
		public DbSet<SIM> SIMs { get; set; }
		public DbSet<PhoneCall> PhoneCalls { get; set; }

		public static CuocDTContext Instance
		{
			get
			{
				if(uniqueInstance==null)
				{
					uniqueInstance = new CuocDTContext();
				}
				return uniqueInstance;
			}
		}       
		public CuocDTContext():base("name=conn")
		{
			Database.SetInitializer(new CuocDTInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			//modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
		}
	}
}
