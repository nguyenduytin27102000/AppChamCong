using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeKeeping.Services
{
    public class IdentityFactory
    {
        public string GenerateId(string currentId, string prefix)
        {
            string pos = "0001";
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string year = DateTime.Now.Year.ToString().Substring(2, 2);
            string dateCode = month + year;
            if (currentId != null)
            {
                int posNum;
                var res = int.TryParse(currentId.Substring(6, 4), out posNum);
                if (res)
                {
                    posNum++;
                    pos = posNum.ToString().PadLeft(4, '0');
                }

            }
            return prefix + dateCode + pos;
        }
    }
}
