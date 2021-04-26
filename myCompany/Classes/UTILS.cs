using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
