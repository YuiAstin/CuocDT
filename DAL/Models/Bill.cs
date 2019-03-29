using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Bill
	{
		[Key]
		public int Id { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime BillDate { get; set; } = DateTime.Now;

		[DataType(DataType.DateTime)]
		public DateTime? PayDate { get; set; }

		[Required]
		public decimal Value { get; set; }

		public int SIMId { get; set; }
		[ForeignKey("SIMId")]
		public virtual SIM SIM { get; set; }

		public void Pay()
		{
			PayDate = DateTime.Now;
		}
	}
}
