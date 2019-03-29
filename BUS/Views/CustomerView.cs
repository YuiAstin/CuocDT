using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Views
{
	public class CustomerView
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string CMND { get; set; }
		public string Email { get; set; }
		public string Job { get; set; }
		public string Position { get; set; }
		public string Address { get; set; }
		public IList<SIMView> SIMs { get; set; }
	}
}
