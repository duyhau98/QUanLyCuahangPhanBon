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
    public class ChinhSuaViewModel :BaseViewModel
    {
        public static int IdNhanVien { get; set; }
        public ChinhSuaViewModel()
        {   
            
                _isEdit = false;
                OnPropertyChanged("isEdit");
                _GioiTinh.Add(new KeyValuePair<string, int>("Nam", 1));
                _GioiTinh.Add(new KeyValuePair<string, int>("Nữ", 2));
                EditNhanVien = new DelegateCommand(_EditNhanVien);
                SaveNhanVien = new DelegateCommand(_SaveNhanVien);
            RemoveNhanVien = new DelegateCommand(_RemoveNhanVien);
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                NhanVien nhanVien = quanLyPhanBonEntities.NhanViens.Find(IdNhanVien);
                _TenNhanVien = nhanVien.TenNhanVien;
                _SelectedGioiTinh = new KeyValuePair<string, int>(nhanVien.GioiTinh, 3);
                _Luong = nhanVien.Luong.ToString();
                _SDT = nhanVien.SDT;
            TaiKhoan taiKhoan = quanLyPhanBonEntities.TaiKhoans.Where(b => b.IDNhanVien == IdNhanVien).FirstOrDefault();
                if (taiKhoan!=null)
                {
                    _TenTaiKhoan = taiKhoan.TenTaiKhoan;
                    _PassWord = taiKhoan.MatKhau;
                }
               
           
        }
        private bool _isEdit;
        public bool isEdit
        {
            get { return _isEdit; }
            set
            {
                _isEdit = value;
                OnPropertyChanged("isEdit");
            }
        }
        public ICommand EditNhanVien
        {
            get;
            private set;
        }
        public void _EditNhanVien(object paramter)
        {
            _isEdit = true;
            OnPropertyChanged("isEdit");
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
        public ICommand RemoveNhanVien
        {
            get;
            set;
        }
        public void _RemoveNhanVien(object parameter)
        {
            var ChinhSUaWD = parameter as Window;
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên chứ?", "Quản lý phân bón", MessageBoxButton.YesNo, MessageBoxImage.Hand);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities())
                    {
                        NhanVien nhanVien = quanLyPhanBonEntities.NhanViens.Find(IdNhanVien);
                        TaiKhoan taiKhoan = quanLyPhanBonEntities.TaiKhoans.Find(_TenTaiKhoan);
                        if(nhanVien!=null)
                            quanLyPhanBonEntities.NhanViens.Remove(nhanVien);
                        if(taiKhoan!=null)
                            quanLyPhanBonEntities.TaiKhoans.Remove(taiKhoan);
                        quanLyPhanBonEntities.SaveChanges();
                        ChinhSUaWD.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
              
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


                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                NhanVien nhanVien = quanLyPhanBonEntities.NhanViens.Find(IdNhanVien);
                nhanVien.TenNhanVien = _TenNhanVien;
                nhanVien.GioiTinh = _SelectedGioiTinh.Key;
                nhanVien.SDT = _SDT;
                nhanVien.DiaChi = _DiaChi;
                nhanVien.Luong = Int32.Parse(_Luong);

                TaiKhoan taiKhoan = quanLyPhanBonEntities.TaiKhoans.Find(_TenTaiKhoan);
                if (taiKhoan != null)
                {
                    taiKhoan.MatKhau = _PassWord;
                }
               
                quanLyPhanBonEntities.SaveChanges();
                ThemNhanVienWD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
