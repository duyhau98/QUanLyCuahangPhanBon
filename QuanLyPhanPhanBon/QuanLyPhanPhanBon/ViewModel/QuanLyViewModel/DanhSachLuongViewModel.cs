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
    public class DanhSachLuongViewModel :BaseViewModel
    {
        public DanhSachLuongViewModel()
        {
            getData();
            Dong = new DelegateCommand(_Dong);
        }
        
        private ObservableCollection<LuongHienTai> _listTienLuong = new ObservableCollection<LuongHienTai>();
        public ObservableCollection<LuongHienTai> ListTienLuong
        {
            get
            {
                return _listTienLuong;
            }
            set
            {
                _listTienLuong = value;
                OnPropertyChanged("ListTienLuong");
            }
        }
        private void getData()
        {
            using (var db = new QuanLyPhanBonEntities())
            {
                var listDiemDanh = db.DiemDanhs.Where(s => s.NgayLam.Year == DateTime.Now.Year && s.NgayLam.Month == DateTime.Now.Month && s.isCoMat == true).ToList();
                foreach(var s in listDiemDanh)
                {
                    LuongHienTai luongHienTai = new LuongHienTai();
                    luongHienTai.TenNhanVien = db.NhanViens.Find(s.NhanVien).TenNhanVien;
                    luongHienTai.TienLuong = db.NhanViens.Find(s.NhanVien).Luong;
                    _listTienLuong.Add(luongHienTai);
                }
                for (int i = 0; i < (_listTienLuong.Count - 1); i++)
                {
                    for (int j = i + 1; j < _listTienLuong.Count; j++)
                    {

                        if (_listTienLuong[i].TenNhanVien == _listTienLuong[j].TenNhanVien)
                        {

                            _listTienLuong[i].TienLuong += _listTienLuong[j].TienLuong;
                            _listTienLuong.RemoveAt(j);
                            OnPropertyChanged("ListTienLuong");
                            j--;
                        }
                    }
                }
            }
        }
        public ICommand Dong
        {
            get;
            set;
        }
        public void _Dong(object parameter)
        {
            var wd = parameter as Window;
            wd.Close();
        }
    }
}
