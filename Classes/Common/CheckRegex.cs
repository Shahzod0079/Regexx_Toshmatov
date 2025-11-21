using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexx_Toshmatov.Classes.Common
{
    public class CheckRegex
    {
        /// <summary>
        /// Метод поиска совпадений
        /// </summary>
        /// <param name="Pattern">Регулярное выражение</param>
        /// <param name="Input">Строка ввода</param>
        /// <returns></returns>
        public static bool Match(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }
    }
}