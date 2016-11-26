using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EPAM
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Thread daemon = new Thread(threadFunc);
            daemon.IsBackground = true;
            daemon.Start();
        }

        public void threadFunc()
        {
            byte min = 80;
            byte max = 150;

            Color color = Color.FromRgb(max, min, min);
            System.Windows.Application.Current.Resources.Add("MainColor", color);
            System.Windows.Application.Current.Resources.Add("MainBrush", new SolidColorBrush(color));

            while (true)
            {
                if (color.R == max && color.G < max && color.B == min)
                    color.G++;
                else if (color.R > min && color.G == max && color.B == min)
                    color.R--;
                else if (color.R == min && color.G == max && color.B < max)
                    color.B++;
                else if (color.R == min && color.G > min && color.B == max)
                    color.G--;
                else if (color.R < max && color.G == min && color.B == max)
                    color.R++;
                else
                    color.B--;
                if (System.Windows.Application.Current != null)
                {
                    System.Windows.Application.Current.Resources["MainColor"] = color;
                    System.Windows.Application.Current.Resources["MainBrush"] = new SolidColorBrush(color);
                }
                Thread.Sleep(50);
            }
        }
    }
}
