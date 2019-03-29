using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class PhoneNumberExtensionMethod
	{
		public static PhoneNumberView ConvertToView(this PhoneNumber phoneNumber)
		{
			return new PhoneNumberView
			{
				Id = phoneNumber.Id.ToString(),
				Number = phoneNumber.Number,
				SIMs = phoneNumber.SIMs.ConvertToViews().ToList()
			};
		}

		public static IEnumerable<PhoneNumberView> ConvertToViews(this IEnumerable<PhoneNumber> phoneNumbers)
		{
			foreach(PhoneNumber phoneNumber in phoneNumbers)
			{
				yield return phoneNumber.ConvertToView();
			}
		}
	}
}
