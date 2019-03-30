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
        private void Ranlog(int startID,int endID,int line)
        {            
            Random gener = new Random();
            Random rando = new Random();
            DateTime sta = new DateTime(1990, 1, 1);
            DateTime end = DateTime.Now;
            FileLine fl = new FileLine();
            while (line > 0)
            {                
                int a=gener.Next(startID, endID);                
                fl.SIMId = a;                
                fl.StartingTime = Randate(sta, end);
                sta.AddMinutes(double.Parse(rando.Next(10).ToString()));
                fl.EndingTime = sta;
                sta.AddMinutes(double.Parse(rando.Next(30).ToString()));
                line -= 1;
            }
            FileHelper.WriteToFile(fl);
        }
        private DateTime Randate(DateTime start, DateTime end)
        {
            Random gen = new Random();
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }        

    }
}
