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
    public class DiemDanhViewModel :BaseViewModel
    {
        public DiemDanhViewModel()
        {
            getData();
            CoMat = new DelegateCommand(_CoMat);
            Vang = new DelegateCommand(_Vang);
            TienLuong = new DelegateCommand(_TienLuong);
        }
        private ObservableCollection<NhanVien> _ListNhanVien = new ObservableCollection<NhanVien>();
        private ObservableCollection<DiemDanh> listDiemDanh = new ObservableCollection<DiemDanh>();
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
            using (var db = new QuanLyPhanBonEntities())
            {
                DiemDanh diemDanh = new DiemDanh();
                diemDanh.isCoMat = true;
                diemDanh.isVang = false;
                diemDanh.NgayLam = DateTime.Now;
                diemDanh.NhanVien = _SelectedNhanVien.IDNhanVien;
                db.DiemDanhs.Add(diemDanh);
                _ListNhanVien.Remove(_SelectedNhanVien);
                OnPropertyChanged("ListNhanVien");
                db.SaveChanges();
            }
        }
        public ICommand Vang
        {
            get;
            private set;
        }
        public void _Vang(object parameter)
        {
            using (var db = new QuanLyPhanBonEntities())
            {
                DiemDanh diemDanh = new DiemDanh();
                diemDanh.isCoMat = false;
                diemDanh.isVang = true;
                diemDanh.NgayLam = DateTime.Now;
                diemDanh.NhanVien = _SelectedNhanVien.IDNhanVien;
                db.DiemDanhs.Add(diemDanh);
                _ListNhanVien.Remove(_SelectedNhanVien);
                OnPropertyChanged("ListNhanVien");
                db.SaveChanges();
            }
        }
        public ICommand TienLuong
        {
            get;
            private set;
        }
        public void _TienLuong(object parameter)
        {
            var danhSachLuong = new View.QuanLy.DanhSachLuong();
            danhSachLuong.ShowDialog();
        }
        public void getData()
        {
            using (var db = new QuanLyPhanBonEntities())
            {
                _ListNhanVien = new ObservableCollection<NhanVien>(db.NhanViens.ToList());
                var listDiemDanh = new ObservableCollection<DiemDanh>(db.DiemDanhs.ToList());
                foreach (var s in listDiemDanh)
                {
                    if(s.NgayLam.Date==DateTime.Now.Date&&s.NgayLam.Month==DateTime.Now.Month&&s.NgayLam.Year==DateTime.Now.Year)
                    {
                        NhanVien nhanVien = db.NhanViens.Find(s.NhanVien);
                        _ListNhanVien.Remove(nhanVien);
                        OnPropertyChanged("ListNhanVien");
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
