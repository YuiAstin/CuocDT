using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Helper;

namespace TestWindowsFormsApp
{
    class Randommizer
    {   
        internal static void Ranlog(int startID,int endID,int line)
        {            
            Random gener = new Random();
            Random rando = new Random();
            DateTime sta = new DateTime(2018,1,1);
            DateTime end = new DateTime(2018, 1, 2);
            FileLine fl = new FileLine();
            while (line > 0)
            {                
                int a=gener.Next(startID, endID);                
                fl.SIMId = a;                
                fl.StartingTime = Randate(sta, end);
                sta = sta.AddDays(double.Parse(rando.Next(1,2).ToString()));
                fl.EndingTime = end;
                end = end.AddDays(double.Parse(rando.Next(3,30).ToString()));
                FileHelper.WriteToFile(fl);
                line -= 1;
            }
            
        }
        private static DateTime Randate(DateTime start, DateTime end)
        {
            Random gen = new Random();
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }        

    }
}
