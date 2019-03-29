using BUS.Helper;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
	public class SIMRepository
	{
		private CuocDTContext context;

		public SIMRepository()
		{
			context = CuocDTContext.Instance;
		}

		public IList<SIM> SIMs
		{
			get
			{
				return context.SIMs.ToList();
			}
		}

		public SIM GetSIM(int id)
		{
			return context.SIMs.Find(id);
		}

		public void AddSIM(SIM sim)
		{
			context.SIMs.Add(sim);
			context.SaveChanges();
		}

		public void RemoveSIM(int id)
		{
			SIM sim = GetSIM(id);
			context.SIMs.Remove(sim);
			context.SaveChanges();
		}

		public void MakeACall(PhoneCall phoneCall)
		{
			if (GetSIM(phoneCall.CallerSIMId) != null && GetSIM(phoneCall.CalleeSIMId) != null)
			{
				context.PhoneCalls.Add(phoneCall);
				context.SaveChanges();

				//ghi file
				FileLine line = new FileLine
				{
					SIMId = phoneCall.CallerSIMId,
					StartingTime = phoneCall.StartingTime,
					EndingTime = phoneCall.EndingTime
				};
				FileHelper.WriteToFile(line);
			}
		}

		public void CloseSIM(int id)
		{
			SIM sim = GetSIM(id);
			if (sim != null)
			{
				sim.Close();
				context.SaveChanges();
			}
		}
	}
}
