using AurigaPetProject2023.UIviaWPF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Helpers
{
    public class LabelInfoHelper
    {
        public void ChangeStatusColorAndVisibility(LabelInfo labelInfo,Brush color)
        {
            if (labelInfo.Color != color)
            {
                labelInfo.Color = color;
            }
            labelInfo.Visibility = Visibility.Visible;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; //millisec
            timer.Elapsed += (sender, e) =>
            {
                //MessageBox.Show("Elapsed");
                labelInfo.Visibility = Visibility.Hidden;
                timerEnabled = false;
                if (timer != null) timer.Dispose();
            };

            if (!timerEnabled)
            {
                timerEnabled = true;
                timer.Start();
            }

        }
        private bool timerEnabled;
    }
}
