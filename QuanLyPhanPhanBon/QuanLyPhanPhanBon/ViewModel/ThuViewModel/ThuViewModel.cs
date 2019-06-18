using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.ThuViewModel
{
    public class ThuViewModel : BaseViewModel
    {
        public ThuViewModel()
        {
            
            getData();
            
            decimal Total = 0;
            for(int i=0;i<_ListPhanBon_KH.Count;i++)
            {
                Total += _ListPhanBon_KH[i].Gia;
            }
            _TongTien = Total +"";
            OnPropertyChanged("TongTien");
            Refresh = new DelegateCommand(_Refresh);
        }
        private DateTime _RecentDate;
        public DateTime RecentDate
        {
            get
            {
                return _RecentDate;
            }
            set
            {
                _RecentDate = value;
                OnPropertyChanged("RecentDate");
            }
        }
        private ObservableCollection<PhanBon_KH> _ListPhanBon_KH = new ObservableCollection<PhanBon_KH>();
        public ObservableCollection<PhanBon_KH> ListPhanBon_KH
        {
            get
            {
                return _ListPhanBon_KH;
                
            }
            set
            {
                _ListPhanBon_KH = value;
                OnPropertyChanged("ListPhanBon_KH");
            }
        }
        private string _TongTien;
        public string TongTien
        {
            get
            {
                return _TongTien;
            }
            set
            {
                _TongTien = value;
                OnPropertyChanged("TongTien");
            }
        }
        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                _SelectedDate = value;
                OnPropertyChanged("SelectedDate");
                
                if(_SelectedDate!=null)
                {
                    for(int i=0;i<_ListPhanBon_KH.Count;i++)
                    {
                        if(_ListPhanBon_KH[i].NgayBan.Day==_SelectedDate.Day&& _ListPhanBon_KH[i].NgayBan.Month == _SelectedDate.Month&& _ListPhanBon_KH[i].NgayBan.Year == _SelectedDate.Year)
                        {
                            _ListTheoNgay.Add(_ListPhanBon_KH[i]);
                        }
                    }
                    if(_ListPhanBon_KH.Count>0&&_ListTheoNgay.Count>0)
                    {
                        _ListPhanBon_KH.Clear();
                        OnPropertyChanged("ListPhanBon_KH");
                    }
                    decimal totalDate = 0;
                    for(int i=0;i<_ListTheoNgay.Count;i++)
                    {
                        _ListPhanBon_KH.Add(_ListTheoNgay[i]);
                        totalDate += _ListTheoNgay[i].Gia;
                    }
                    _TongTien = totalDate + "";
                    OnPropertyChanged("ListPhanBon_KH");
                    
                    return;
                }
            }
        }
        public ICommand Refresh
        {
            get;
            private set;
        }
        public void _Refresh(object parameter)
        {
            
            _ListPhanBon_KH.Clear();
            OnPropertyChanged("ListPhanBon_KH");
            getData();
            decimal Total = 0;
            for (int i = 0; i < _ListPhanBon_KH.Count; i++)
            {
                Total += _ListPhanBon_KH[i].Gia;
            }
            _TongTien = Total + "";
            OnPropertyChanged("TongTien");
        }
        private ObservableCollection<PhanBon_KH> _ListTheoNgay = new ObservableCollection<PhanBon_KH>();
        public void getData()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListPhanBon_KH = new ObservableCollection<PhanBon_KH>(quanLyPhanBonEntities.PhanBon_KH.ToList());
            OnPropertyChanged("ListPhanBon_KH");
            quanLyPhanBonEntities.SaveChanges();
        }
    }
}
