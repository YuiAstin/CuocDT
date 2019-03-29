using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class SIM
	{
		[Key]
		public int Id { get; set; }

		public int PhoneNumberId { get; set; }
		[ForeignKey("PhoneNumberId")]
		public virtual PhoneNumber PhoneNumber { get; set; }

		public int CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		public virtual Customer Customer { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime OpenTime { get; set; } = DateTime.Now;

		[DataType(DataType.DateTime)]
		public DateTime? CloseTime { get; set; }

		public virtual IList<PhoneCall> PhoneCalls { get; set; }

		public virtual IList<Bill> Bills { get; set; }

		public void Close()
		{
			if(CloseTime==null)
			{
				CloseTime = DateTime.Now;
			}
		}
	}

	public class PhoneCall
	{
		[Key]
		public int Id { get; set; }

		public int CallerSIMId { get; set; }
		[ForeignKey("CallerSIMId")]
		public virtual SIM CallerSIM { get; set; }

		public int CalleeSIMId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime StartingTime { get; set; } = DateTime.Now;

		[DataType(DataType.DateTime)]
		public DateTime EndingTime { get; set; }
	}
}
