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
        static double PhanTramKM { get; set; }
        public BanPhanBonViewModel()
        {
            _TongTien = "0";
            OnPropertyChanged("TongTien");
            _ThanhTien = "0";
            OnPropertyChanged("ThanhTien");
            _KhuyenMai = "0%";
            OnPropertyChanged("KhuyenMai");
            FillDataKH();
            GiamSLMua = new DelegateCommand(DecreaseSL);
            //getDataPhanBon();
            


        }
        private PhanBon_KH phanBonDaBan;
        private decimal total = 0;
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
                if(IDPreKhachHang!=_SelectedKhachHang.IDKhachHang)
                {
                    if (_ListPhanBon_KH.Count > 0)
                    {
                        _ListPhanBon_KH.Clear();
                        OnPropertyChanged("ListPhanBon_KH");
                        _TongTien = "0";
                        OnPropertyChanged("TongTien");
                        _ThanhTien = "0";
                        OnPropertyChanged("ThanhTien");
                        _KhuyenMai = "0%";
                        OnPropertyChanged("KhuyenMai");

                    }
                  
                    
                }
             
             

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
        private ObservableCollection<PhanBon_KH> _ListPhanBon_KHTemp = new ObservableCollection<PhanBon_KH>();
        private ObservableCollection<PhanBon_KH> _ListPhanBon_KHRef = new ObservableCollection<PhanBon_KH>();
        private ObservableCollection<PhanBon_KH> _ListPhanBon_KH = new ObservableCollection<PhanBon_KH>();
        public ObservableCollection<PhanBon_KH> ListPhanBon_KH
        {
            get { return _ListPhanBon_KH; }
            set
            {
                _ListPhanBon_KH = value;
                OnPropertyChanged("ListPhanBon_KH");
               
            }
        }
        private string _TongTien;
        public string TongTien
        {
            get { return _TongTien; }
            set
            {
                _TongTien = value;
                OnPropertyChanged("TongTien");
            }
        }
        private string _ThanhTien;
        public string ThanhTien
        {
            get { return _ThanhTien; }
            set
            {
                _TongTien = value;
                OnPropertyChanged("ThanhTien");
            }
        }
        private string _KhuyenMai;
        public string KhuyenMai
        {
            get { return _KhuyenMai; }
            set
            {
                _TongTien = value;
                OnPropertyChanged("KhuyenMai");
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
        private PhanBon _SelectedPhanBon;
        int count = 0;
        bool isContain = false;
        private int IDPreKhachHang ;
        private int IDPrSelectedPB;
        public PhanBon SelectedPhanBon
        {
            get
            {
                return _SelectedPhanBon;
            }
            set
            {
                _SelectedPhanBon = value;
                OnPropertyChanged("SelectedPhanBon");


                if (_SelectedPhanBon != null)
                {

                    IDPrSelectedPB = _SelectedPhanBon.IDPhanBon;
                    isContain = false;

                    for (int i = 0; i < _ListPhanBon_KH.Count; i++)
                    {
                        if (_SelectedPhanBon.IDPhanBon == _ListPhanBon_KH[i].IDPhanBon)
                        {
                            isContain = true;
                            break;
                        }

                    }
                    if (isContain == true)
                    {


                        if (_ListPhanBon_KH.Count > 0 && _SelectedPhanBon != null)
                        {

                            _ListPhanBon_KHTemp.Clear();
                            for (int i = 0; i < _ListPhanBon_KH.Count; i++)
                            {
                                _ListPhanBon_KHTemp.Add(_ListPhanBon_KH[i]);
                            }
                            for (int i = 0; i < _ListPhanBon_KHTemp.Count; i++)
                            {

                                if (_SelectedPhanBon.IDPhanBon == _ListPhanBon_KHTemp[i].IDPhanBon)
                                {

                                    _ListPhanBon_KHTemp[i].SoLuong = _ListPhanBon_KHTemp[i].SoLuong + 1;

                                    _ListPhanBon_KHTemp[i].Gia = _ListPhanBon_KHTemp[i].Gia + _ListPhanBon_KHTemp[i].Gia / (_ListPhanBon_KHTemp[i].SoLuong - 1);
                                    total += _ListPhanBon_KHTemp[i].Gia / _ListPhanBon_KHTemp[i].SoLuong;
                                    _TongTien = total + "";
                                    OnPropertyChanged("TongTien");
                                    _ThanhTien = _TongTien;
                                    OnPropertyChanged("ThanhTien");


                                    RefreshBill(_ListPhanBon_KHTemp);
                                    if (_SelectedPhanBon.SoLuong > 0)
                                    {
                                        ChangeCount(_ListPhanBon_KHTemp[i].IDPhanBon, _SelectedPhanBon.SoLuong);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sản phẩm hết hàng, xin vui lòng chọn sản phẩm khác");
                                    }

                                    _SelectedPhanBon = null;
                                    OnPropertyChanged("SelectedPhanBon");
                                    return;

                                }
                            }


                        }



                    }
                    if (isContain == false)
                    {

                        AddListPhanBon_KH();
                        if (_SelectedPhanBon.SoLuong > 0)
                        {
                            ChangeCount(_SelectedPhanBon.IDPhanBon, _SelectedPhanBon.SoLuong);
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm hết hàng, xin vui lòng chọn sản phẩm khác");
                        }


                        _SelectedPhanBon = null;
                        OnPropertyChanged("SelectedPhanBon");
                        return;
                    }




                    IDPreKhachHang = _SelectedKhachHang.IDKhachHang;
                }




            }
        }
        ObservableCollection<PhanBon> ListPhanBonTemp = new ObservableCollection<PhanBon>();
        ObservableCollection<PhanBon> _ListPhanBonTemp = new ObservableCollection<PhanBon>();
        private void ChangeCount(int id,int? SL)
        {
            
            if(ListPhanBonTemp.Count>0)
            {
                ListPhanBonTemp.Clear();
            }
            for(int i=0;i<_ListPhanBon.Count;i++)
            {
                ListPhanBonTemp.Add(_ListPhanBonTemp[i]);
            }
            for (int i = 0; i < ListPhanBonTemp.Count; i++)
            {
                if (id == ListPhanBonTemp[i].IDPhanBon)
                {
                    ListPhanBonTemp[i].SoLuong = SL-1;
                    break;
                }
            }
            if(_ListPhanBon.Count>0)
            {
                _ListPhanBon.Clear();
            }
            for(int i=0;i<_ListPhanBonTemp.Count;i++)
            {
                _ListPhanBon.Add(_ListPhanBonTemp[i]);
            }
            
            OnPropertyChanged("ListPhanBon");
      
            return;
        }
        private void RefreshBill(ObservableCollection<PhanBon_KH> phanBon_KHs)
        {
            
            if (_ListPhanBon_KHRef.Count>0)
            {
                _ListPhanBon_KHRef.Clear();
            }
            for(int i=0;i<phanBon_KHs.Count;i++)
            {
                _ListPhanBon_KHRef.Add(phanBon_KHs[i]);
            }
            if ( _ListPhanBon_KH != null)
            {
                
                _ListPhanBon_KH = _ListPhanBon_KHRef;
               
                OnPropertyChanged("ListPhanBon_KH");
            }
            
        }
        private void AddListPhanBon_KH()
        {
            if(SelectedPhanBon!=null)
            {
                PhanBon_KH phanBon_KH = new PhanBon_KH();
                phanBon_KH.IDKhachHang = _SelectedKhachHang.IDKhachHang;
                phanBon_KH.IDPhanBon = _SelectedPhanBon.IDPhanBon;
                phanBon_KH.NgayBan = DateTime.Now;
                phanBon_KH.Gia = _SelectedPhanBon.Gia;
                phanBon_KH.SoLuong = 1;
                total += phanBon_KH.Gia/phanBon_KH.SoLuong;
             
                _ListPhanBon_KH.Add(phanBon_KH);
                OnPropertyChanged("ListPhanBon_KH");
                _TongTien = total + "";
                OnPropertyChanged("TongTien");
                _ThanhTien = _TongTien;
                OnPropertyChanged("ThanhTien");
            }
          
           
            
        }
        public ICommand GiamSLMua
        {
            get;
            private set;

        }
        private void DecreaseSL(object parameter)
        {
           
            

                MessageBox.Show(IDPrSelectedPB.ToString());
            
          
        }
        private void getDataPhanBon()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListPhanBon = new ObservableCollection < PhanBon > (quanLyPhanBonEntities.PhanBons.ToList()) ;
            OnPropertyChanged("ListPhanBon");
            quanLyPhanBonEntities.SaveChanges();

            if(_ListPhanBonTemp.Count>0)
            {
                _ListPhanBonTemp.Clear();
            }
            for(int i=0;i<_ListPhanBon.Count;i++)
            {
                _ListPhanBonTemp.Add(_ListPhanBon[i]);
            }
            
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
