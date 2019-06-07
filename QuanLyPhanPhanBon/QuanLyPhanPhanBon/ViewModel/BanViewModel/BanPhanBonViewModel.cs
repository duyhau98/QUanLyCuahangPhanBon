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
    public class BanPhanBonViewModel :BaseViewModel
    {
        public BanPhanBonViewModel()
        {
            try
            {
                FillDataKH();
                //getDataPhanBon();
                GiamSLMua = new DelegateCommand(DecreaseSL);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private KhachHang _SelectedKhachHang;
        public KhachHang SelectedKhachHang
        {
            get
            {
                return _SelectedKhachHang;
            }
            set
            {
                 _SelectedKhachHang = value;
                OnPropertyChanged("SelectedKhachHang");
                getDataPhanBon();
          
            }
        }
        private ObservableCollection<KhachHang> _ListKH;
        public ObservableCollection<KhachHang> ListKH
        {
            get { return _ListKH; }
            set
            {
                _ListKH = value;
                OnPropertyChanged("ListKH");
            }
        }
        private ObservableCollection<PhanBon> _ListPhanBon;
        public ObservableCollection<PhanBon> ListPhanBon
        {
            get { return _ListPhanBon; }
            set
            {
                _ListPhanBon = value;
                OnPropertyChanged("ListPhanBon");
            }
        }
        private KhachHang _SelectedPhanBon;
        public KhachHang SelectedPhanBon
        {
            get
            {
                return _SelectedPhanBon;
            }
            set
            {
                _SelectedPhanBon = value;
                OnPropertyChanged("SelectedPhanBon");


            }
        }
        public ICommand GiamSLMua
        {
            get;
            private set;
        }
        private void DecreaseSL(object parameter)
        {
            MessageBox.Show("Huhu");
        }
        private void getDataPhanBon()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListPhanBon = new ObservableCollection < PhanBon > (quanLyPhanBonEntities.PhanBons.ToList()) ;
            OnPropertyChanged("ListPhanBon");
            quanLyPhanBonEntities.SaveChanges();
        }
        private void FillDataKH()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListKH = new ObservableCollection < KhachHang >(quanLyPhanBonEntities.KhachHangs.ToList());
            OnPropertyChanged("ListKH");
            quanLyPhanBonEntities.SaveChanges();
            
        }
    }
}
