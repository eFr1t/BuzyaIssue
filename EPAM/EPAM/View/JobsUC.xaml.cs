using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPAM.View
{
    /// <summary>
    /// Логика взаимодействия для FindJobUC.xaml
    /// </summary>
    public partial class JobsUC : UserControl
    {
        private Author Author;

        private Label SelectedTarget;
        private Label ClickTarget;

        public JobsUC(Author author)
        {
            InitializeComponent();

            Author = author;

            MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            args.RoutedEvent = Label.MouseLeftButtonDownEvent;
            tbFind.RaiseEvent(args);
            args.RoutedEvent = Label.MouseLeftButtonUpEvent;
            tbFind.RaiseEvent(args);
        }

        private void tb_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            ClickTarget = (Label)sender;
        }

        private void tb_LeftMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ClickTarget == sender)
            {
                if (SelectedTarget != null)
                    SelectedTarget.Style = (Style)FindResource("tbUnselected");

                SelectedTarget = (Label)sender;
                SelectedTarget.Style = (Style)FindResource("tbSelected");

                Object uc = null;
                switch ((String)SelectedTarget.Content)
                {
                    case "Find Jobs":
                        uc = new FindJobUC();
                        break;
                    case "Saved Jobs":
                        //uc = new MyJobsUC();
                        break;
                    case "Applications":
                        //uc = new TalksUC();
                        break;
                }

                ContentViewer.Content = uc;
            }
        }
    }
}
