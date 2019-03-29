using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Views
{
	public class PhoneNumberView
	{
		public string Id { get; set; }
		public string Number { get; set; }
		public IList<SIMView> SIMs { get; set; }
	}
}
