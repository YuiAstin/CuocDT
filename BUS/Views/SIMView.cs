using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Views
{
	public class SIMView
	{
		public string Id { get; set; }
		public string PhoneNumber { get; set; }
		public string CustomerName { get; set; }
		public string CustomerCMND { get; set; }
		public string OpenTime { get; set; }
		public string CloseTime { get; set; }
		public IList<PhoneCallView> PhoneCalls { get; set; }
		public IList<BillView> Bills { get; set; }
	}
}
