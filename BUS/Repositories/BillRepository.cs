using BUS.Helper;
using BUS.Helpers;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
	public class BillRepository
	{
		private CuocDTContext context;

		public BillRepository()
		{
			context = CuocDTContext.Instance;
		}

		public IList<Bill> Bills
		{
			get
			{
				return context.Bills.ToList();
			}
		}

		public Bill GetBill(int id)
		{
			return context.Bills.Find(id);
		}

		public void AddBill(Bill bill)
		{
			context.Bills.Add(bill);
			context.SaveChanges();
		}

		public void RemoveBill(int id)
		{
			Bill bill = GetBill(id);
			context.Bills.Remove(bill);
			context.SaveChanges();
		}

		public void PayBill(int id)
		{
			Bill bill = GetBill(id);
			if (bill != null)
			{
				bill.Pay();
				context.SaveChanges();
			}
		}

		public void CalculateBillsFromFile()
		{
			//sử dụng FileHelper để
			//tính các bill từ file
			//ghi các bill vào database
			//gửi email nhắc nhở đóng tiền
			//làm mới file

			PhoneChargesCalculator calculator = new PhoneChargesCalculator();

			//tính các bill từ file
			IList<FileLine> lineList = FileHelper.ReadFromFile();
			var billDict = new Dictionary<int, Bill>();
			foreach (FileLine line in lineList)
			{
				if (billDict.ContainsKey(line.SIMId))
				{
					billDict[line.SIMId].Value +=
						decimal.Parse(calculator.Calculate(line.StartingTime, line.EndingTime).ToString());
				}
				else
				{
					Bill bill = new Bill
					{
						SIMId = line.SIMId,
						BillDate = DateTime.Now,
						Value = decimal.Parse(calculator.Calculate(line.StartingTime, line.EndingTime).ToString())
					};
					billDict[line.SIMId] = bill;
				}
			}

			//làm mới file
			FileHelper.EraseFile();

			//ghi các bill vào database
			//gửi email nhắc nhở đóng tiền
			foreach (var dictItem in billDict)
			{
				AddBill(dictItem.Value);
				string message = "Hãy thanh toán cước điện thoại hàng tháng trị giá " +
					dictItem.Value.Value +
					" trước 30 ngày kể từ ngày " +
					dictItem.Value.BillDate;
				EmailSender.SendMessage(context.SIMs.Find(dictItem.Key).Customer.Email, message);
			}
		}
	}
}
