using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            QLLuong = new DelegateCommand(_QLLuong);
            Refresh();
        }
        public ICommand QLLuong
        {
            get;
            private set;
        }
        public void _QLLuong(object parameter)
        {
            QuanLyLuong quanLyLuong = new QuanLyLuong();
            quanLyLuong.ShowDialog();
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
            Refresh();
        }
        private ObservableCollection<NhanVien> _ListNhanVien =  new ObservableCollection<NhanVien>();
        public ObservableCollection<NhanVien> ListNhanVien
        {
            get
            {
                return _ListNhanVien;
            }
            set
            {
                _ListNhanVien = value;
                OnPropertyChanged("ListNhanVien");
            }
        }
        private NhanVien _SelectedNhanVien = new NhanVien();
        public NhanVien SelectedNhanVien
        {
            get
            {
                return _SelectedNhanVien;
            }
            set
            {
                _SelectedNhanVien = value;
                OnPropertyChanged("SelectedNhanVien");
                if(_SelectedNhanVien!=null)
                {
                    ChinhSuaViewModel.IdNhanVien = _SelectedNhanVien.IDNhanVien;
                    ChinhSuaNhanVien chinhSuaNhanVien = new ChinhSuaNhanVien();
                    chinhSuaNhanVien.ShowDialog();
                    _SelectedNhanVien = null;
                    OnPropertyChanged("SelectedNhanVien");
                    Refresh();
                }
               
              
            }
        }
        public void Refresh()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            ListNhanVien = new ObservableCollection<NhanVien>(quanLyPhanBonEntities.NhanViens.ToList());
            OnPropertyChanged("ListNhanVien");
            quanLyPhanBonEntities.SaveChanges();
        }
    }
}
