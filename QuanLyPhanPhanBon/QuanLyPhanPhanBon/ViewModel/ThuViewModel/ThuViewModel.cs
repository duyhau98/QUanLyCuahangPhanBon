using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.ThuViewModel
{
    public class ThuViewModel : BaseViewModel
    {
        public ThuViewModel()
        {
            getData();
            _TongTien = "100000";OnPropertyChanged("TongTien");

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
        public void getData()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListPhanBon_KH = new ObservableCollection<PhanBon_KH>(quanLyPhanBonEntities.PhanBon_KH.ToList());
            OnPropertyChanged("ListPhanBon_KH");
            quanLyPhanBonEntities.SaveChanges();
        }
    }
}
