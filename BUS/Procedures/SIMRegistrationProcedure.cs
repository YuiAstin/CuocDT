using BUS.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Procedures
{
	public class SIMRegistrationProcedure
	{
		private CustomerRepository customerRepository;
		private PhoneNumberRepository phoneNumberRepository;
		private SIMRepository simRepository;

		public SIMRegistrationProcedure()
		{
			customerRepository = new CustomerRepository();
			phoneNumberRepository = new PhoneNumberRepository();
			simRepository = new SIMRepository();
		}

		public void RegisterSIM(int customerId,int phoneNumberId)
		{
			Customer customer = customerRepository.GetCustomer(customerId);
			if (customer == null)//customer không tồn tại
				return;

			PhoneNumber phoneNumber = phoneNumberRepository.GetPhoneNumber(phoneNumberId);
			if (phoneNumber == null)//phone number không tồn tại
				return;
			if (phoneNumber.Owner() != null)//phone number đã có chủ
				return;

			//thêm SIM vào database
			SIM sim = new SIM
			{
				CustomerId = customer.Id,
				PhoneNumberId = phoneNumber.Id,
				OpenTime = DateTime.Now
			};
			simRepository.AddSIM(sim);
		}
	}
}
