using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace myCompany
{
    /// <summary>
    /// Interaction logic for TimePickerUC.xaml
    /// </summary>
    public partial class TimePickerUC : UserControl
    {
        public TimePickerUC()
        {
            InitializeComponent();            
        }

        public void SetTime(string Hour)
        {
            tbHH.Text = Hour.Substring(0, 2);
            tbMM.Text = Hour.Substring(3, 2);
        }

        private void TbHH_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int hh = Convert.ToInt32(tbHH.Text);
            if (e.Delta > 0)
            {
                hh++;
            }
            else
            {
                hh--;
            }

            if (hh > 23)
            {
                hh = 0;
            }
            if (hh < 0)
            {
                hh = 23;
            }
            tbHH.Text = hh.ToString("00");
        }

        private void TbHH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
            int hh = Convert.ToInt32(tbHH.Text);
            if (hh > 23)
            {
                hh = 0;
            }
        }

        private void TbMM_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int mm = Convert.ToInt32(tbMM.Text);
            if (e.Delta > 0)
            {
                mm++;
            }
            else
            {
                mm--;
            }

            if (mm > 59)
            {
                mm = 0;
            }
            if (mm < 0)
            {
                mm = 59;
            }
            tbMM.Text = mm.ToString("00");
        }

        private void TbMM_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Integer_PreviewTextInput(sender, e);
            int mm = Convert.ToInt32(tbMM.Text);
            if (mm > 59)
            {
                mm = 0;
            }
        }

        public override string ToString()
        {
            int hh = Convert.ToInt32(tbHH.Text);
            int mm = Convert.ToInt32(tbMM.Text);
            return hh.ToString("00") + ":" + mm.ToString("00");
        }
    }
}
