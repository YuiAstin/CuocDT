using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class PhoneNumber
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Phone]
		[MinLength(8)]
		[MaxLength(12)]
		[Index(IsUnique = true)]
		public string Number { get; set; }

		public virtual IList<SIM> SIMs { get; set; }

		/// <summary>
		/// Gets the current customer who is owning this phone number,
		/// throw ArgumentNullException if there are more than one customer owning it
		/// </summary>
		/// <returns>
		/// the owning customer
		/// null if no one owning it
		/// </returns>
		public Customer Owner()
		{
			SIM sim = SIMs.SingleOrDefault(s => s.CloseTime == null);
			return sim != null ? sim.Customer : null;
		}
	}
}
