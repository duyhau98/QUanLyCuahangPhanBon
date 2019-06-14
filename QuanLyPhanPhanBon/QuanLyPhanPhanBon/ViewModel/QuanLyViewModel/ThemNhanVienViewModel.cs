using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.QuanLyViewModel
{
    public class ThemNhanVienViewModel :BaseViewModel
    {
        public ThemNhanVienViewModel()
        {
            _GioiTinh.Add(new KeyValuePair<string, int>("Nam", 1));
            _GioiTinh.Add(new KeyValuePair<string, int>("Nữ", 2));
            SaveNhanVien = new DelegateCommand(_SaveNhanVien);
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
        private KeyValuePair<string, int> _SelectedGioiTinh = new KeyValuePair<string, int>();
        public KeyValuePair<string, int> SelectedGioiTinh
        {
            get { return _SelectedGioiTinh; }
            set
            {
                _SelectedGioiTinh = value;
                OnPropertyChanged("SelectedGioiTinh");

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
        public ICommand SaveNhanVien
        {
            get;
            private set;
        } 
        public void _SaveNhanVien(object parameter)
        {
            var ThemNhanVienWD = parameter as Window;
            try
            {
                NhanVien nhanVien = new NhanVien();
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                nhanVien.TenNhanVien = _TenNhanVien;
                nhanVien.GioiTinh = _SelectedGioiTinh.Key;
                nhanVien.SDT = _SDT;
                nhanVien.DiaChi = _DiaChi;
                nhanVien.Luong = Int32.Parse(_Luong);
                quanLyPhanBonEntities.NhanViens.Add(nhanVien);
                quanLyPhanBonEntities.SaveChanges();
                ThemNhanVienWD.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
    
}
