using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
using QuanLyPhanPhanBon.View.Ban;
namespace QuanLyPhanPhanBon.ViewModel.BanViewModel
{
    
    public class BanPhanBonViewModel :BaseViewModel
    {
        public static double PhanTramKM { get; set; }
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
            
            TangSLMua = new DelegateCommand(IncreaseSL);
            NhapKM = new DelegateCommand(KM);
            ThanhToan = new DelegateCommand(_ThanhToan);
            ThemKH = new DelegateCommand(_ThemKH);
            RefreshAll = new DelegateCommand(_RefreshAll);
        }
        private PhanBon_KH phanBonDaBan;
        private decimal total = 0;
        public string _TenKhachHang;
        public string TenKhachHang
        {
            get { return _TenKhachHang; }
            set
            {
                _TenKhachHang = value;
                OnPropertyChanged("TenKhachHang");
            }
            
        }
        public ICommand ThemKH
        {
            get;
            private set;
        }
        public void _ThemKH(object parameter)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.ShowDialog();
            RefreshKH();
        }
        public ICommand RefreshAll
        {
            get;
            private set;
        }
        public void _RefreshAll(object parameter)
        {
            _TongTien = "0";
            OnPropertyChanged("TongTien");
            _ThanhTien = "0";
            OnPropertyChanged("ThanhTien");
            _KhuyenMai = "0%";
            OnPropertyChanged("KhuyenMai");
            FillDataKH();
            _ListPhanBon.Clear();
            OnPropertyChanged("ListPhanBon");
            _ListPhanBon_KH.Clear();
            OnPropertyChanged("ListPhanBon_KH");
        }
        public void RefreshKH()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            _ListKH = new ObservableCollection<KhachHang>(quanLyPhanBonEntities.KhachHangs.ToList());
            OnPropertyChanged("ListKH");
            quanLyPhanBonEntities.SaveChanges();
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
                if(_SelectedKhachHang!=null)
                {
                    _TenKhachHang = _SelectedKhachHang.TenKhachHang;
                    OnPropertyChanged("TenKhachHang");
                    getDataPhanBon();
                    if (IDPreKhachHang != _SelectedKhachHang.IDKhachHang)
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
        public string PTKhuyenMai
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
                       
                    }
                
                
                
            }
        }
        ObservableCollection<PhanBon> ListPhanBonTemp = new ObservableCollection<PhanBon>();
        ObservableCollection<PhanBon> _ListPhanBonTemp = new ObservableCollection<PhanBon>();
        private void ChangeCount(int id,int? SL,bool isIncrease)
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
                    if(isIncrease)
                    {
                        ListPhanBonTemp[i].SoLuong = SL - 1;
                    }
                    else
                    {
                        ListPhanBonTemp[i].SoLuong = SL + 1;
                    }
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
                phanBon_KH.TenPhanBon = _SelectedPhanBon.TenPhanBon;
                phanBon_KH.NgayBan = DateTime.Now;
                phanBon_KH.Gia = _SelectedPhanBon.Gia;
                phanBon_KH.SoLuong = 1;
                total += phanBon_KH.Gia/phanBon_KH.SoLuong;
                PreTotal = total;
                _ListPhanBon_KH.Add(phanBon_KH);
                OnPropertyChanged("ListPhanBon_KH");
                _TongTien = total + "";
                OnPropertyChanged("TongTien");
                _ThanhTien = _TongTien;
                OnPropertyChanged("ThanhTien");
            }
          
           
            
        }
        public ICommand NhapKM
        {
            get;
            set;
        }
        decimal PreTotal = 0;
        public void KM(object parameter )
        {
            try
            {
             
                
                
                View.Ban.KhuyenMai khuyenMai = new View.Ban.KhuyenMai();
                khuyenMai.ShowDialog();
                 
              
                OnPropertyChanged("ThanhTien");
                _KhuyenMai = PhanTramKM + "%";
                OnPropertyChanged("PTKhuyenMai");
                decimal Sum = PreTotal - PreTotal * decimal.Parse((PhanTramKM / 100).ToString());
                _ThanhTien = Sum + "";
                OnPropertyChanged("ThanhTien");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
         public ICommand ThanhToan
        {
            get;
            private set;
        }
        public void _ThanhToan(object parameter)
        {
            try
            {
                ThanhToanViewModel.IDKhachHang = _SelectedKhachHang.IDKhachHang;
                ThanhToanViewModel.ToTal = decimal.Parse(_ThanhTien);
                View.Ban.ThanhToan thanhToan = new ThanhToan();
                thanhToan.ShowDialog();
               
                for(int i=0;i<_ListPhanBon_KH.Count;i++)
                {
                    QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                    quanLyPhanBonEntities.PhanBon_KH.Add(_ListPhanBon_KH[i]);
                    quanLyPhanBonEntities.SaveChanges();
                    //Chỗ này
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public ICommand GiamSLMua
        {
            get;
            private set;

        }
        ObservableCollection<PhanBon_KH> listNewPB_KH = new ObservableCollection<PhanBon_KH>();
        ObservableCollection<PhanBon> listNewPB = new ObservableCollection<PhanBon>();
        private bool decrease = false;
        private void DecreaseSL(object parameter)
        {
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
                            _ListPhanBon_KHTemp[i].SoLuong = _ListPhanBon_KHTemp[i].SoLuong - 1;
                            if(_ListPhanBon_KHTemp[i].SoLuong==0 )
                            {
                                total -= _ListPhanBon_KHTemp[i].Gia / (_ListPhanBon_KHTemp[i].SoLuong+1);
                                PreTotal = total;
                                _TongTien = total + "";
                                OnPropertyChanged("TongTien");
                                _ThanhTien = _TongTien;
                                OnPropertyChanged("ThanhTien");
                                ChangeCount(_ListPhanBon_KHTemp[i].IDPhanBon, _SelectedPhanBon.SoLuong,false);
                                _ListPhanBon_KHTemp.RemoveAt(i);
                                RefreshBill(_ListPhanBon_KHTemp);
                                



                            }
                            else
                            {
                                _ListPhanBon_KHTemp[i].Gia = _ListPhanBon_KHTemp[i].Gia - _ListPhanBon_KHTemp[i].Gia / (_ListPhanBon_KHTemp[i].SoLuong + 1);
                                total -= _ListPhanBon_KHTemp[i].Gia / _ListPhanBon_KHTemp[i].SoLuong;
                                PreTotal = total;
                                _TongTien = total + "";
                                OnPropertyChanged("TongTien");
                                _ThanhTien = _TongTien;
                                OnPropertyChanged("ThanhTien");
                                RefreshBill(_ListPhanBon_KHTemp);
                                ChangeCount(_ListPhanBon_KHTemp[i].IDPhanBon, _SelectedPhanBon.SoLuong, false);
                                //if (_SelectedPhanBon.SoLuong > 0)
                                //{
                                //    ChangeCount(_ListPhanBon_KHTemp[i].IDPhanBon, _SelectedPhanBon.SoLuong,false);
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Sản phẩm hết hàng, xin vui lòng chọn sản phẩm khác");
                                //}
                                _SelectedPhanBon = null;
                                OnPropertyChanged("SelectedPhanBon");
                            }
                           
                            return;
                        }
                    }
                }
            }
            if (isContain == false)
            {

                MessageBox.Show("Chưa thêm phân bón vào hóa đơn, vui lòng kiểm tra lại!!!");
                return;
            }
        }
        public ICommand TangSLMua
        {
            get;
            private set;
        }
        private void IncreaseSL(object parameter)
        {
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
                            if (_SelectedPhanBon.SoLuong == 0)
                            {
                                MessageBox.Show("Sản phẩm hết hàng, xin vui lòng chọn sản phẩm khác");
                            }
                            else
                            {
                                _ListPhanBon_KHTemp[i].SoLuong = _ListPhanBon_KHTemp[i].SoLuong + 1;

                                _ListPhanBon_KHTemp[i].Gia = _ListPhanBon_KHTemp[i].Gia + _ListPhanBon_KHTemp[i].Gia / (_ListPhanBon_KHTemp[i].SoLuong - 1);
                                total += _ListPhanBon_KHTemp[i].Gia / _ListPhanBon_KHTemp[i].SoLuong;
                                PreTotal = total;
                                _TongTien = total + "";
                                OnPropertyChanged("TongTien");
                                _ThanhTien = _TongTien;
                                OnPropertyChanged("ThanhTien");
                                RefreshBill(_ListPhanBon_KHTemp);
                                ChangeCount(_ListPhanBon_KHTemp[i].IDPhanBon, _SelectedPhanBon.SoLuong, true);

                                _SelectedPhanBon = null;
                                OnPropertyChanged("SelectedPhanBon");
                                return;
                            }
                            
                        }
                    }
                }
            }
            if (isContain == false)
            {

                AddListPhanBon_KH();
                if (_SelectedPhanBon.SoLuong > 0)
                {
                    ChangeCount(_SelectedPhanBon.IDPhanBon, _SelectedPhanBon.SoLuong,true);
                }
                else
                {
                    MessageBox.Show("Sản phẩm hết hàng, xin vui lòng chọn sản phẩm khác");
                }
                _SelectedPhanBon = null;
                OnPropertyChanged("SelectedPhanBon");
                IDPreKhachHang = _SelectedKhachHang.IDKhachHang;
                return;
            }
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
