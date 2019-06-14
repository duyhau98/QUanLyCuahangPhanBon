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
   public  class QuanLyLuongViewModel:BaseViewModel
    {
        public QuanLyLuongViewModel()
        {
            using (QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities())
            {
                _ListNhanVien = new ObservableCollection<NhanVien>(quanLyPhanBonEntities.NhanViens.ToList());
                OnPropertyChanged("ListNhanVien");
                quanLyPhanBonEntities.SaveChanges();
            }
        }
        private ObservableCollection<NhanVien> _ListNhanVien = new ObservableCollection<NhanVien>();
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
        public ICommand OK
        {
            get;
            private set;
        }
        public void _OK( object parameter)
        {
            var quanLyLuongWD = parameter as Window;
            quanLyLuongWD.Close();
        }
    }
}
