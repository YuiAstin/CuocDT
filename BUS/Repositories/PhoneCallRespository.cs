using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Repositories
{
    public class PhoneCallsRepository
    {
        private CuocDTContext context;

        public PhoneCallsRepository()
        {
            context = CuocDTContext.Instance;
        }

        public IList<PhoneCall> PhoneCalls
        {
            get
            {
                return context.PhoneCalls.ToList();
            }
        }

        public PhoneCall GetPhoneCall(int id)
        {
            return context.PhoneCalls.Find(id);
        }

        public void AddPhoneCall(PhoneCall PhoneCall)
        {
            context.PhoneCalls.Add(PhoneCall);
            context.SaveChanges();
        }
        public List<PhoneCall> FindSimID(int SIMid)
        {
            var query = from wut in context.PhoneCalls
                        where wut.CallerSIMId == SIMid
                        select wut;
            List<PhoneCall> result = query.ToList<PhoneCall>();
            return result;
        }

        public void RemovePhoneCall(int id)
        {
            PhoneCall PhoneCall = GetPhoneCall(id);
            context.PhoneCalls.Remove(PhoneCall);
            context.SaveChanges();
        }
    }
}
