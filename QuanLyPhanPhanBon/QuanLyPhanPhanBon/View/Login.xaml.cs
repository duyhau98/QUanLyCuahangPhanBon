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
using System.Windows.Shapes;
using QuanLyPhanPhanBon.ViewModel;
namespace QuanLyPhanPhanBon.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window, IHavePassword
    {
        public Login()
        {
            InitializeComponent();
          
        }
        public System.Security.SecureString Password
        {
            get
            {
                return PasswordBox.SecurePassword;
            }
        }

      
    }
   
}
