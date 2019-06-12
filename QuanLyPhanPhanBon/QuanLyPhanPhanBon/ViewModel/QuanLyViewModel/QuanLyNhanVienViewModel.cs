using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
using QuanLyPhanPhanBon.View.QuanLy;
namespace QuanLyPhanPhanBon.ViewModel.QuanLyViewModel
{
    public class QuanLyNhanVienViewModel :BaseViewModel
    {
        public QuanLyNhanVienViewModel()
        {
            AddNhanVien = new DelegateCommand(_AddNhanVien);
        }
        public ICommand AddNhanVien
        {
            get;
            set;
        }
        public void _AddNhanVien(object parameter)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.ShowDialog();
        }
    }
}
