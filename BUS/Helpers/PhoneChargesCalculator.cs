using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helpers
{
	public class PhoneChargesCalculator
	{
		private const short hoursPerDay = 24;
		private const short minutesPerHour = 60;

		public TimeSpan TimeFlag1 { get; set; }
		public TimeSpan TimeFlag2 { get; set; }
		public short ChargesPerMinute1 { get; set; }
		public short ChargesPerMinute2 { get; set; }

		public PhoneChargesCalculator()
		{
			TimeFlag1 = new TimeSpan(07, 00, 00);
			TimeFlag2 = new TimeSpan(23, 00, 00);
			ChargesPerMinute1 = 200;
			ChargesPerMinute2 = 150;
		}

		public double Calculate(DateTime startTime, DateTime endTime)
		{
			double value = 0d;

			//TG bắt đầu >= TG kết thúc
			if (startTime >= endTime)
				return value;

			TimeSpan callTime = endTime - startTime;
			double t1 = Math.Floor((callTime.TotalHours / hoursPerDay));

			double flagSpan = (TimeFlag1 - TimeFlag2).Duration().TotalHours;
			double t2 = t1 * flagSpan;

			double startTimeTimeOfDay = startTime.TimeOfDay.TotalHours;

			double t3 = 0d;
			if (inFlagRange(startTime.TimeOfDay))
			{
				double newEndTime = (startTimeTimeOfDay + (callTime.TotalHours % hoursPerDay)) % hoursPerDay;
				TimeSpan tsStartTime = TimeSpan.FromHours(startTimeTimeOfDay);
				TimeSpan tsEndTime = TimeSpan.FromHours(newEndTime);
				if (inFlagRange(tsEndTime))
				{
					t3 = (tsEndTime - tsStartTime).Duration().TotalHours;
				}
				else
				{
					t3 = (TimeFlag2 - tsStartTime).Duration().TotalHours;
				}
			}
			else
			{
				double newEndTime = (startTimeTimeOfDay + (callTime.TotalHours % hoursPerDay)) % hoursPerDay;
				TimeSpan tsEndTime = TimeSpan.FromHours(newEndTime);
				if (inFlagRange(tsEndTime))
				{
					t3 = (tsEndTime - TimeFlag1).Duration().TotalHours;
					return newEndTime;
				}
				else if (inTimeRange(TimeFlag2, startTime.TimeOfDay, tsEndTime))
				{
					t3 = flagSpan;
				}
				else t3 = 0d;
			}

			double chargeMinutes1 = (t2 + t3) * minutesPerHour;
			value = chargeMinutes1 * ChargesPerMinute1;

			double chargeMinutes2 = callTime.TotalMinutes - chargeMinutes1;
			value += chargeMinutes2 * ChargesPerMinute2;

			return value;
		}

		private bool inFlagRange(TimeSpan timeOfDay)
		{
			if (TimeFlag1 < TimeFlag2)
			{
				if (TimeFlag1 <= timeOfDay && timeOfDay <= TimeFlag2)
					return true;
				return false;
			}
			else if (TimeFlag1 > TimeFlag2)
			{
				if (TimeFlag2 < timeOfDay && timeOfDay < TimeFlag1)
					return false;
				return true;
			}
			//TimeFlag1 == TimeFlag2
			else if (timeOfDay == TimeFlag1)
				return true;
			return false;
		}

		private bool inTimeRange(TimeSpan timeOfDay, TimeSpan timeFlag1, TimeSpan timeFlag2)
		{
			if (timeFlag1 < timeFlag2)
			{
				if (timeFlag1 <= timeOfDay && timeOfDay <= timeFlag2)
					return true;
				return false;
			}
			else if (timeFlag1 > timeFlag2)
			{
				if (timeFlag2 < timeOfDay && timeOfDay < timeFlag1)
					return false;
				return true;
			}
			//timeFlag1 == timeFlag2
			else if (timeOfDay == timeFlag1)
				return true;
			return false;
		}
	}
}
