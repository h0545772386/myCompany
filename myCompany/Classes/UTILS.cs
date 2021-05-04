using System;
using System.Linq;

namespace myCompany
{
    public static class UTILS
    {
        // כדי להקיש רק מספרים שלמים 
        public static void Integer_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }

        // כדי להקיש מספרים עם נקודה עשרונית 
        public static void Decimal_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c) && c != '.'))
            {
                e.Handled = true;
            }
        }

        // בדיקת תקינות מספר תעודת זהות
        // מחזיר TRUE אם מספר תעודת הזהות תקין
        public static bool Is_Valid_IDN(string IDN)
        {
            var arr = IDN.ToCharArray();
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int res = int.Parse(arr[i].ToString()) * (i % 2 == 0 ? 1 : 2);
                res = res > 9 ? res / 10 + res % 10 : res;
                sum += res;
            }
            return sum % 10 == 0;
        }

        public static string ConvertTime(string Hour)  // "HH:MM
        {
            string ConvertedHour = "";
            string[] arr = Hour.Split(':');
            int hh = Convert.ToInt32(arr[0]);
            int mm = Convert.ToInt32(arr[1]);
            if (hh == 0)
            {
                ConvertedHour = "00:";
            }
            else
            {
                if (hh < 10)
                {
                    ConvertedHour = "0" + hh.ToString() + ":";
                }
                else
                {
                    ConvertedHour = hh.ToString() + ":";
                }
            }
            if (mm == 0)
            {
                ConvertedHour += "00";
            }

            else
            {
                if (mm < 10)
                {
                    ConvertedHour += "0" + mm.ToString();
                }
                else
                {
                    ConvertedHour += mm.ToString();
                }
            }
            return ConvertedHour;
        }

        public static string ConvertOver24(string Hour)  // "HH:MM
        {
            string[] arr = Hour.Split(':');
            int hh = Convert.ToInt32(arr[0]);
            hh += 24;
            return hh.ToString() + ":" + arr[1];
        }

        public static string DateToString_YYYYMMDD(this DateTime d)
        {
            int Year = d.Year;
            int Month = d.Month;
            int Day = d.Day;

            return Year.ToString() +
                   (Month < 10 ? "0" + Month.ToString() : Month.ToString()) +
                   (Day < 10 ? "0" + Day.ToString() : Day.ToString());
        }

        public static int DateToINT_YYYYMMDD(this DateTime d)
        {
            int i = 0;
            int.TryParse(DateToString_YYYYMMDD(d), out i);
            return i;
        }

        public static DateTime INT2Date(this int YYYYMMDD)
        {
            int Year = YYYYMMDD / 10000;
            int Month = (YYYYMMDD / 100) % 100;
            int Day = YYYYMMDD % 100;
            return new DateTime(Year, Month, Day);
        }

    }
}
