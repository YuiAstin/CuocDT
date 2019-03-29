using BUS.Views;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers.ExtensionMethods
{
	public static class BillExtensionMethod
	{
		public static BillView ConvertToView(this Bill bill)
		{
			return new BillView
			{
				Id = bill.Id.ToString(),
				SIMId = bill.SIMId.ToString(),
				BillDate = bill.BillDate.ToString(),
				PayDate = bill.PayDate.ToString(),
				Value = bill.Value.ToString()
			};
		}
        public static Bill ConvertToBill(this BillView billview)
        {
            return new Bill
            {
                Id = int.Parse(billview.Id),
                SIMId = int.Parse(billview.SIMId),
                BillDate = DateTime.Parse(billview.BillDate),
                PayDate = DateTime.Parse(billview.PayDate),
                Value = int.Parse(billview.Value)
            };
        }

        public static IEnumerable<BillView> ConvertToViews(this IEnumerable<Bill> bills)
		{
			foreach(Bill bill in bills)
			{
				yield return bill.ConvertToView();
			}
		}
	}
}
