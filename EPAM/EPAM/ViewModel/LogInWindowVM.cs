using EPAM.Model;
using EPAM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.ViewModel
{
    public class LogInWindowVM : BaseVM
    {
        private LogInWindow _logInWindow;

        private String _login;
        public String Login 
        {
            get { return _login; }
            set 
            {
                if(value != _login)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public LogInWindowVM(LogInWindow logInWindow)
        {
            _logInWindow = logInWindow;

            AppVM.Instace.ToString();
        }

        public void DoLogin(String password)
        {
            AppVM.Instace.Login(Login, password);

            if (AppVM.Instace.Person == null)
                return;

            if (AppVM.Instace.Person as Client != null)
                new ClientWindow(AppVM.Instace.Person as Client).Show();
            else
                new AuthorWindow(AppVM.Instace.Person as Author).Show();
            _logInWindow.Close();
        }

        public void GoToRegister()
        {
            new RegistrationWindow().Show();
            _logInWindow.Close();
        }
    }
}
