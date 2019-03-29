using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(20)]
		public string Name { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MinLength(9)]
		[MaxLength(12)]
		[RegularExpression(@"^\d{9}(\d{3})?$", ErrorMessage = "Số CMND phải là 9 hoặc 12 số")]
		public string CMND { get; set; }
		
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(20)]
		public string Job { get; set; }
		
		[MaxLength(20)]
		public string Position { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(80)]
		public string Address { get; set; }

		public virtual IList<SIM> SIMs { get; set; }

		/// <summary>
		/// Get a list of phone numbers which the customer is owning
		/// </summary>
		/// <returns>List of phone number</returns>
		public IList<PhoneNumber> OwningPhoneNumbers()
		{
			IList<PhoneNumber> owningPhoneNumbers = new List<PhoneNumber>();
			foreach(SIM sim in SIMs)
			{
				if (sim.CloseTime != null)
				{
					owningPhoneNumbers.Add(sim.PhoneNumber);
				}
			}
			return owningPhoneNumbers;
		}
	}
}
