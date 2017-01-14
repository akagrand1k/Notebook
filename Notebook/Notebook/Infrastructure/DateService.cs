using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Notebook.Infrastructure
{
    /// <summary>
    /// Replace date for view with "."
    /// </summary>
    public class DateService
    {
        public static string ReplaceDate(int dateBirthday)
        {
            int dd = dateBirthday / 1000000;
            int mm = (dateBirthday / 10000) % 100;
            int yyyy = dateBirthday % 10000;

            DateTime dt = new DateTime(yyyy, mm, dd);
            return String.Format("{0:d/M/yyyy}", dt.ToShortDateString());
        }
    }

    /// <summary>
    /// Custom class for validate date range/correct date.
    /// </summary>
    public sealed class DateValidateAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string t_str = value.ToString();
            if (t_str.Length == 7)
            {
                t_str = "0" + t_str;
            }
            DateTime dt;
            bool IsDateValid = DateTime.TryParseExact(t_str,"ddMMyyyy",null, DateTimeStyles.None,out dt);

            if (dt < DateTime.Parse("01.01.1920"))
            return false;
            
            if (!IsDateValid)
            return false;
            return true;
        }
    }
}