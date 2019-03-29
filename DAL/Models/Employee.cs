using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(20)]
		public string Name { get; set; }

		[Required]
		[MinLength(4)]
		[MaxLength(20)]
		[Index(IsUnique = true)]
		public string Username { get; set; }

		[Required]
		[MinLength(6)]
		[MaxLength(20)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		/// <summary>
		/// check if password is matched
		/// </summary>
		/// <param name="password">the string which need to compare to Password</param>
		/// <returns>true if password is matched, otherwise false</returns>
		public bool ChecksPassword(string password)
		{
			return Password == password ? true : false;
		}
	}
}
