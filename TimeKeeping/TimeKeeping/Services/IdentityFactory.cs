using System;

namespace TimeKeeping.Services
{
    public class IdentityFactory
    {
        // format: PREFIX (2 characters) + MONTH (2 characters) + YEAR (2 characters) + NUMBER(4 characters) 
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

        // format PREFIX (3 characters) + MONTH (2 characters) + YEAR (2 characters) + NUMBER(3 characters) 
        public string GenerateId2(string currentId, string prefix)
        {
            string pos = "001";
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string year = DateTime.Now.Year.ToString().Substring(2, 2);
            string dateCode = month + year;
            if (currentId != null)
            {
                int posNum;
                var res = int.TryParse(currentId.Substring(7, 3), out posNum);
                if (res)
                {
                    posNum++;
                    pos = posNum.ToString().PadLeft(3, '0');
                }

            }
            return prefix + dateCode + pos;
        }
    }
}