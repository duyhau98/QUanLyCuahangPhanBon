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
    public class KhuyenMaiViewModel:BaseViewModel
    {
        public KhuyenMaiViewModel()
        {
            BanPhanBonViewModel.PhanTramKM = 0;
            OKClick = new DelegateCommand(_OKClick);
            ObservableCollection<KhuyenMai> listKM ;
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();

               listKM = new ObservableCollection<KhuyenMai>(quanLyPhanBonEntities.KhuyenMais.ToList()) ;
            quanLyPhanBonEntities.SaveChanges();
            for(int i=0;i<listKM.Count;i++)
            {
                if(listKM[i].NgayBatDau>DateTime.Now||listKM[i].NgayKetThuc<DateTime.Now)
                {
                    listKM.RemoveAt(i);
                }
            }
            for(int i=0;i<listKM.Count;i++)
            {
                _ListkM.Add(new KeyValuePair<string, double>(listKM[i].IDKhuyenMai, listKM[i].PhanTram));
            }
        }
        private ObservableCollection<KeyValuePair<string, double>> _ListkM = new ObservableCollection<KeyValuePair<string, double>>();
        public ObservableCollection<KeyValuePair<string, double>> ListKM
        {
            get { return _ListkM; }
            set
            {
                _ListkM = value;
                OnPropertyChanged("ListKM");
            }
        }
        private KeyValuePair<string, double> _SelectedKM = new KeyValuePair<string, double>();
        public KeyValuePair<string, double> SelectedLoaiKM
        {
            get { return _SelectedKM; }
            set
            {
                _SelectedKM = value;
                OnPropertyChanged("SelectedLoaiKM");
                
            }
        }
        public ICommand OKClick
        {
            get;
            set;
        }
        public void _OKClick(object parameter)
        {
            BanPhanBonViewModel.PhanTramKM = _SelectedKM.Value;
            var KMWindow = parameter as Window;
            KMWindow.Close();
        }
    }
   

}
