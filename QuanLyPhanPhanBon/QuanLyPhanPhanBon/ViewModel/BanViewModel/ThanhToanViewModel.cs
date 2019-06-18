using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.BanViewModel
{
    public class ThanhToanViewModel : BaseViewModel
    {
        public static decimal ToTal {get;set;}
        public static int IDKhachHang { get; set; }
        public ThanhToanViewModel()
        {
            ThanhToan = new DelegateCommand(_ThanhToan);
            No = new DelegateCommand(_No);
            Exit = new DelegateCommand(_Exit);
        }
        private string _TienKhach;
        public string TienKhach
        {
            get { return _TienKhach; }
            set
            {
                _TienKhach = value;
                OnPropertyChanged("TienKhach");
            }
        }
        public ICommand ThanhToan
        {
            get;
            private set;
        }
        public void _ThanhToan(object parameter)
        {
            var ThanhToanWinDow = parameter as Window;
            try
            {
                decimal result = decimal.Parse(_TienKhach) - ToTal;
                if (result >= 0)
                {
                    MessageBox.Show("Số tiền khách đưa là: " + _TienKhach + "\n" + "Tiền trả lại khách là: " + result);
                    ThanhToanWinDow.Close();
                }
                else
                {
                    MessageBox.Show("Nhập sai, xin vui lòng nhập lại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand No
        {
            get;
            private set;
        }
        public void _No(object parameter)
        {
            try
            {
                var ThanhToanWinDow = parameter as Window;
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                KhachHang khachHang = new KhachHang();
                khachHang = quanLyPhanBonEntities.KhachHangs.Find(IDKhachHang);
                if (khachHang.IsThieuTien == false)
                {
                    khachHang.TienNo = ToTal;
                }
                else
                {
                    khachHang.TienNo = khachHang.TienNo + ToTal;
                }
                quanLyPhanBonEntities.SaveChanges();
                MessageBox.Show("Thanh toán thành công!!");
                ThanhToanWinDow.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
                
        }
        public ICommand Exit
        {
            get;
            private set;
        }
        public void _Exit(object parameter)
        {
            var ThanhToanWinDow = parameter as Window;
            ThanhToanWinDow.Close();
        }
    }
}
