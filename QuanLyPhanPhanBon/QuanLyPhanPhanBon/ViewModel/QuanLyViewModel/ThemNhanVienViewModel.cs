using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhanPhanBon.ViewModel.QuanLyViewModel
{
    public class ThemNhanVienViewModel :BaseViewModel
    {
        public ThemNhanVienViewModel()
        {

        }
        private string _TenNhanVien;
        public string TenNhanVien
        {
            get
            {
                return _TenNhanVien;
            }
            set
            {
                _TenNhanVien = value;
                OnPropertyChanged("TenNhanVien");
            }
        }
        private ObservableCollection<KeyValuePair<string, int>> _GioiTinh = new ObservableCollection<KeyValuePair<string, int>>();
        public ObservableCollection<KeyValuePair<string, int>> GioiTinh
        {
            get { return _GioiTinh; }
            set
            {
                _GioiTinh = value;
                OnPropertyChanged("GioiTinh");
            }
        }
        private string _DiaChi;
        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
                OnPropertyChanged("DiaChi");
            }
        }
        private string _SDT;
        public string SDT
        {
            get
            {
                return _SDT;
            }
            set
            {
                _SDT = value;
                OnPropertyChanged("SDT");
            }
        }
        private string _Luong;
        public string Luong
        {
            get
            {
                return _Luong;
            }
            set
            {
                _Luong = value;
                OnPropertyChanged("Luong");
            }
        }
        private string _TenTaiKhoan;
        public string TenTaiKhoan
        {
            get
            {
                return _TenTaiKhoan;
            }
            set
            {
                _TenTaiKhoan = value;
                OnPropertyChanged("TenTaiKhoan");
            }
        }
        private string _PassWord;
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                _PassWord = value;
                OnPropertyChanged("PassWord");
            }
        }

    }
    
}
