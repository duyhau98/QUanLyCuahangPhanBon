using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
using QuanLyPhanPhanBon.View;
namespace QuanLyPhanPhanBon.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Logout = new DelegateCommand(_Logout);
        }
        public ICommand Logout
        {
            get;
            private set;
        }
        public void _Logout(object parameter)
        {
            Login login = new Login();
            login.Show();
            var window = parameter as Window;
            window.Close();
            
        }
    }
}
