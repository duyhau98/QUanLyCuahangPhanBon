using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhanPhanBon.View.Nhap;
using QuanLyPhanPhanBon.Model;
using System.Windows.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace QuanLyPhanPhanBon.ViewModel.NhapViewModel
{
    
    public class ChinhSuaPhanBonViewModel : BaseViewModel
    {
        public ChinhSuaPhanBonViewModel()
        {
           
            SaveImage = new DelegateCommand(SaveImageClick);
            EditPhanBon = new DelegateCommand(Edit);
            SavePhanBon = new DelegateCommand(Save);
            FillComboBox();
            if (phanBon!=null)
            {
                _isChinhSua = false;
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                LoaiPhanBon loaiphanBon = new LoaiPhanBon();
                loaiphanBon = quanLyPhanBonEntities.LoaiPhanBons.Find(phanBon.LoaiPhanBon);
                quanLyPhanBonEntities.SaveChanges();
                _selectedLoaiPhanBon = new KeyValuePair<int, string>(phanBon.LoaiPhanBon, loaiphanBon.TenLoaiPhanBon);
                _TenPhanBon = phanBon.TenPhanBon;
                _gia = phanBon.Gia.ToString();
                _soLuong = phanBon.SoLuong.ToString();
                imagePath = phanBon.HinhAnh;
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                bm.EndInit();
                _sourceImage = bm;
            }
            
        }
        static public PhanBon phanBon  { get; set; }
        
        private string imagePath;
        private BitmapImage _sourceImage;
        private string _TenPhanBon;
        private ObservableCollection<KeyValuePair<int,string>> _loaiPhanBon = new ObservableCollection<KeyValuePair<int, string>>();
        private KeyValuePair<int, string> _selectedLoaiPhanBon = new KeyValuePair<int, string>();
        private string _gia;
        private string _soLuong;
        private bool _isChinhSua;
        public bool isChinhSua
        {
            get { return this._isChinhSua; }
            set
            {
                if (this._isChinhSua != value)
                {
                    this._isChinhSua = value;
                    OnPropertyChanged("isChinhSua");
                }

            }
        }
        public BitmapImage SourceImage
        {
            get { return _sourceImage; }
            set
            {
                _sourceImage = value;
                OnPropertyChanged("SourceImage");
            }
        }
        public string TenPhanBon
        {
            get { return _TenPhanBon; }
            set
            {
                _TenPhanBon = value;
                OnPropertyChanged("TenPhanBon");
            }
        }
        public string SoLuong
        {
            get { return _soLuong; }
            set
            {
                _soLuong = value;
                OnPropertyChanged("SoLuong");
            }
        }
        public string Gia
        {
            get { return _gia; }
            set
            {
                _gia = value;
                OnPropertyChanged("Gia");
            }
        }
        public ObservableCollection<KeyValuePair<int, string>> LoaiPhanBon
        {
            get { return _loaiPhanBon; }
            set
            {
                _loaiPhanBon = value;
                OnPropertyChanged("LoaiPhanBon");
            }
        }
        public KeyValuePair<int, string> SelectedLoaiPhanBon
        {
            get
            {
                return _selectedLoaiPhanBon;
            }
            set
            {
                _selectedLoaiPhanBon = value;
                OnPropertyChanged("SelectedPhanBon");
              
            }
        }
        public ICommand SaveImage
        {
            get;
            private set;
        }
        public ICommand EditPhanBon
        {
            get;
            private set;
        }
        public ICommand SavePhanBon
        {
            get;
            private set;
        }
        private void Save(object parameter)
        {
            var EditWindow = parameter as Window;
            using (QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities())
            {
                try
                {
                    PhanBon phanBon1;
                   
                    phanBon1 =  quanLyPhanBonEntities.PhanBons.Find(phanBon.IDPhanBon);
                    phanBon1.TenPhanBon = _TenPhanBon;
                    phanBon1.LoaiPhanBon = _selectedLoaiPhanBon.Key;
                    phanBon1.HinhAnh = imagePath;
                    phanBon1.SoLuong = int.Parse(_soLuong);
                    phanBon1.Gia = int.Parse(_gia);
                    quanLyPhanBonEntities.SaveChanges();
                    EditWindow.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public ICommand ExitThisWindow
        {
            get;
            private set;
        }
        private void Exit(object parameter)
        {
            var EditWindow = parameter as Window;
            EditWindow.Close();
        }
        private void Edit(object parameter)
        {
            
            _isChinhSua = true;
            OnPropertyChanged("isChinhSua");
        }
       
        private void SaveImageClick(object parameter)
        {
            
            _sourceImage = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";//Chọn những file có định dạng png,jpg ban đầu

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(openFileDialog.ShowDialog()==true)
            {
                 imagePath = openFileDialog.FileName;//Lấy đường dẫn
                
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                bm.EndInit();
                _sourceImage = bm;
                OnPropertyChanged("SourceImage");
                
            }
        }
        public void FillComboBox()
        {
            QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
            ObservableCollection<LoaiPhanBon>  _listLoaiPhanBon = new ObservableCollection<LoaiPhanBon>(quanLyPhanBonEntities.LoaiPhanBons.ToList());
            quanLyPhanBonEntities.SaveChanges();
            foreach(var loaiPhan in _listLoaiPhanBon)
            {
                _loaiPhanBon.Add(new KeyValuePair<int, string>(loaiPhan.IDLoaiPhanBon, loaiPhan.TenLoaiPhanBon));
            }
        }
    }
}
