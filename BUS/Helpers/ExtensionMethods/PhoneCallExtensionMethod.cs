using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class PhoneCallExtensionMethod
	{
		public static PhoneCallView ConvertToView(this PhoneCall phoneCall)
		{
			return new PhoneCallView
			{
				Id = phoneCall.Id.ToString(),
				CallerSIMId = phoneCall.CallerSIMId.ToString(),
				CalleeSIMId = phoneCall.CalleeSIMId.ToString(),
				StartingTime = phoneCall.StartingTime.ToString(),
				EndingTime = phoneCall.EndingTime.ToString()
			};
		}

		public static IEnumerable<PhoneCallView> ConvertToViews(this IEnumerable<PhoneCall> phoneCalls)
		{
			foreach(PhoneCall phoneCall in phoneCalls)
			{
				yield return phoneCall.ConvertToView();
			}
		}
	}
}
