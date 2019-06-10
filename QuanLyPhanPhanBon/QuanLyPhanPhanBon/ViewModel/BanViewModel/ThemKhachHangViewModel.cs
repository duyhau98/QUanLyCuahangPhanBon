using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.BanViewModel
{
    public class ThemKhachHangViewModel : BaseViewModel
    {
        public ThemKhachHangViewModel()
        {
            _GioiTinh.Add(new KeyValuePair<string, int>("Nam", 1));
            _GioiTinh.Add(new KeyValuePair<string, int>("Nữ", 1));
            SaveKH = new DelegateCommand(_SaveKH);
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
        private string _TenKH;
        public string TenKH
        {
            get { return _TenKH; }
            set
            {
                _TenKH = value;
                OnPropertyChanged("TenKH");
            }
        }
        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set
            {
                _SDT = value;
                OnPropertyChanged("SDT");
            }
        }
       
        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set
            {
                _DiaChi = value;
                OnPropertyChanged("DiaChi");
            }
        }
        public ICommand SaveKH
        {
            get;
            set;
        }
        public void _SaveKH(object parameter)
        {
            
            try
            {
                var ThemKHWinDow = parameter as Window;
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                KhachHang khachHang = new KhachHang();
                khachHang.TenKhachHang = _TenKH;
                khachHang.GioiTinh = _SelectedGioiTinh.Key;
                khachHang.SDT = _SDT;
                khachHang.DiaChi = _DiaChi;
                quanLyPhanBonEntities.KhachHangs.Add(khachHang);
                quanLyPhanBonEntities.SaveChanges();
                ThemKHWinDow.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
