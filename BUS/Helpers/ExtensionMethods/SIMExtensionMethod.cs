using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class SIMExtensionMethod
	{
		public static SIMView ConvertToView(this SIM sim)
		{
			return new SIMView
			{
				Id = sim.Id.ToString(),
				CustomerName = sim.Customer.Name,
				CustomerCMND = sim.Customer.CMND,
				OpenTime = sim.OpenTime.ToString(),
				CloseTime = sim.CloseTime.ToString(),
				PhoneNumber = sim.PhoneNumber.Number,
				Bills = sim.Bills.ConvertToViews().ToList(),
				PhoneCalls = sim.PhoneCalls.ConvertToViews().ToList()
			};
		}

		public static IEnumerable<SIMView> ConvertToViews(this IEnumerable<SIM> sims)
		{
			foreach(SIM sim in sims)
			{
				yield return sim.ConvertToView();
			}
		}
	}
}
