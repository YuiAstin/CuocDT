using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
	public class PhoneNumberRepository
	{
		private CuocDTContext context;

		public PhoneNumberRepository()
		{
			context = CuocDTContext.Instance;
		}

		public IList<PhoneNumber> PhoneNumbers
		{
			get
			{
				return context.PhoneNumbers.ToList();
			}
		}

		public PhoneNumber GetPhoneNumber(int id)
		{
			return context.PhoneNumbers.Find(id);
		}

		public PhoneNumber GetPhoneNumber(string number)
		{
			return context.PhoneNumbers.FirstOrDefault(p => p.Number == number);
		}

		public void AddPhoneNumber(PhoneNumber phoneNumber)
		{
			context.PhoneNumbers.Add(phoneNumber);
			context.SaveChanges();
		}

		public void RemovePhoneNumber(int id)
		{
			PhoneNumber phoneNumber = GetPhoneNumber(id);
			context.PhoneNumbers.Remove(phoneNumber);
			context.SaveChanges();
		}

		public void RemovePhoneNumber(string number)
		{
			PhoneNumber phoneNumber = GetPhoneNumber(number);
			context.PhoneNumbers.Remove(phoneNumber);
			context.SaveChanges();
		}
	}
}
