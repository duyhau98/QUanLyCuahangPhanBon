using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.ThongKeViewModel
{
    public class ThongKeViewModel:BaseViewModel
    {
        public ThongKeViewModel()
        {
            using (QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities())
            {
                ObservableCollection<PhanBon_KH> phanBon_KHs = new ObservableCollection<PhanBon_KH>(quanLyPhanBonEntities.PhanBon_KH.ToList());
                ObservableCollection<PhanBon_KH> TempPB_KH = new ObservableCollection<PhanBon_KH>();


                for (int i=0;i<phanBon_KHs.Count;i++)
                {
                    
                        if (phanBon_KHs[i].NgayBan.Month==DateTime.Now.Month&&phanBon_KHs[i].NgayBan.Year==DateTime.Now.Year)
                        {
                            TempPB_KH.Add(phanBon_KHs[i]);
                            
                        }
                }
                
                for(int i=0;i<(TempPB_KH.Count-1);i++)
                {
                    for(int j=i+1;j<TempPB_KH.Count;j++)
                    {
                      
                        if (TempPB_KH[i].IDPhanBon == TempPB_KH[j].IDPhanBon)
                        {
                           
                            TempPB_KH[i].SoLuong += TempPB_KH[j].SoLuong;
                            TempPB_KH.RemoveAt(j);
                            j--;
                           
                            



                        }
                    }
                }
                for(int i=0;i<TempPB_KH.Count;i++)
                {
                    banChayTrongThang.Add(new KeyValuePair<string, int>(TempPB_KH[i].TenPhanBon, TempPB_KH[i].SoLuong));
                }
                _TopBanChay = banChayTrongThang;
                OnPropertyChanged("TopBanChay");
                    
            }
        }
        private ObservableCollection<KeyValuePair<string, int>> banChayTrongThang = new ObservableCollection<KeyValuePair<string, int>>();
        private ObservableCollection<KeyValuePair<string,int>> _TopBanChay;
        public ObservableCollection<KeyValuePair<string, int>> TopBanChay
        {
            get { return _TopBanChay; }
            set
            {
                _TopBanChay = value;
                OnPropertyChanged("TopBanChay");
            }
        }
    }
}
