using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.QuanLyViewModel
{
    public class DiemDanhViewModel :BaseViewModel
    {
        public DiemDanhViewModel()
        {
            getData();
            CoMat = new DelegateCommand(_CoMat);
            Vang = new DelegateCommand(_Vang);
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
                if (_SelectedNhanVien != null)
                {
                    
                }


            }
        }
        public ICommand CoMat
        {
            get;
            private set;
        }
        public void _CoMat(object parameter)
        {

        }
        public ICommand Vang
        {
            get;
            private set;
        }
        public void _Vang(object parameter)
        {

        }
        public void getData()
        {
            using (var db = new QuanLyPhanBonEntities())
            {
                _ListNhanVien = new ObservableCollection<NhanVien>(db.NhanViens.ToList());
                db.SaveChanges();
            }
        }
    }
}
