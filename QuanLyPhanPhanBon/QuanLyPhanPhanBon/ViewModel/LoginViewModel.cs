using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanLyPhanPhanBon.View;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel
{
    public interface IHavePassword
    {
        System.Security.SecureString Password { get; }
    }
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            _isQuanLy = true;
            LoginCommand = new DelegateCommand(LoginClick);
            _txtUser = "duyhau";
             

        }
        private string _txtUser;
        private bool _isQuanLy;
        
        public bool isQuanLyChecked
        {
            get { return this._isQuanLy; }
            set
            {
                if(this._isQuanLy!=value)
                {
                    this._isQuanLy = value;
                    OnPropertyChanged("isQuanLyChecked");
                }
               
            }
        }
        public string txtUser
        {
            get { return _txtUser; }
            set { _txtUser = value;
                OnPropertyChanged();
            }
        }
        public  ICommand LoginCommand
        {
            get;
            private set;
                     
        }
       
        private void LoginClick(object parameter)
        {
            var loginWindow = parameter as Window;
            
            var passwordBox = parameter as IHavePassword;
            
            if (_txtUser != null)
            {
                var db = new QuanLyPhanBonEntities();
                TaiKhoan taiKhoan = null;
                taiKhoan = db.TaiKhoans.Find(_txtUser.Trim());
                if (taiKhoan != null)
                {
                    var secureString = passwordBox.Password;
                    string PasswordBox = ConvertToUnsecureString(secureString);
                  
                    if (PasswordBox == taiKhoan.MatKhau.Trim() && taiKhoan.IDNhanVien == 1 && _isQuanLy == true)
                    {
                        //Open New window with Manager
                        App.isQuanLy = true;
                       
                        Home home = new Home();
                       // loginWindow.Hide();
                        loginWindow.Close();
                        home.ShowDialog();


                    }
                    else if (PasswordBox == taiKhoan.MatKhau.Trim() && _isQuanLy == false && taiKhoan.IDNhanVien != 1)
                    {
                        //Open new Window
                        App.isQuanLy = false;
                        
                        Home home = new Home();
                       
                        loginWindow.Close();
                        home.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu sai hoặc đăng nhập sai quyền!!Xin vui lòng kiểm tra lại!!");
                    }
                }
                else
                {
                    MessageBox.Show("K tồn tại tài khoản, xin vui lòng kiểm tra lại!!");
                }




            }
        }
        private string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

    }
    
    
}
