using System;
using System.Collections.Generic;
using System.Linq;

namespace SARCEM_TCC.web.Helper
{
    public static class Conversor
    {
        public static decimal StringToDecimal(string valor)
        {
            try
            {
                HashSet<char> validChars = new HashSet<char>(
             new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' });
                var washedString = new string((from c in valor
                                               where validChars.Contains(c)
                                               select c).ToArray());
            
                return Convert.ToDecimal(washedString.Substring(0, washedString.Length - 3) + washedString.Substring(washedString.Length - 3).Replace(".", ","));
            }
            catch
            {

                return 0;
            }

        }
    }
}