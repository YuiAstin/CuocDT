using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Views
{
	public class PhoneCallView
	{
		public string Id { get; set; }
		public string CallerSIMId { get; set; }
		public string CalleeSIMId { get; set; }
		public string StartingTime { get; set; }
		public string EndingTime { get; set; }
	}
}
