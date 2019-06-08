using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using QuanLyPhanPhanBon.Model;
namespace QuanLyPhanPhanBon.ViewModel.NhapViewModel
{
   public class ThemPhanBonViewModel :BaseViewModel
    {
        public ThemPhanBonViewModel()
        {
            FillComboBox();
            SaveImage = new DelegateCommand(SaveImageClick);
            SavePhanBon = new DelegateCommand(Save);
            ExitThisWindow = new DelegateCommand(Exit);
        }
        private string imagePath;
        private BitmapImage _sourceImage;
        private string _TenPhanBon;
        private ObservableCollection<KeyValuePair<int, string>> _loaiPhanBon = new ObservableCollection<KeyValuePair<int, string>>();
        private KeyValuePair<int, string> _selectedLoaiPhanBon = new KeyValuePair<int, string>();
        private string _gia;
        private string _soLuong;
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
        public ICommand SavePhanBon
        {
            get;
            private set;
        }
        private void Save(object parameter)
        {
            var AddWindow = parameter as Window;
            using (QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities())
            {
                try
                {
                    PhanBon phanBon1 = new PhanBon();

                    
                    phanBon1.TenPhanBon = _TenPhanBon;
                    phanBon1.LoaiPhanBon = _selectedLoaiPhanBon.Key;
                    phanBon1.HinhAnh = imagePath;
                    phanBon1.SoLuong = int.Parse(_soLuong);
                    phanBon1.Gia = int.Parse(_gia);
                    quanLyPhanBonEntities.PhanBons.Add(phanBon1);
                    quanLyPhanBonEntities.SaveChanges();
                    AddWindow.Close();
                }
                catch (Exception ex)
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
        private void SaveImageClick(object parameter)
        {

            _sourceImage = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";//Chọn những file có định dạng png,jpg ban đầu

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
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
            ObservableCollection<LoaiPhanBon> _listLoaiPhanBon = new ObservableCollection<LoaiPhanBon>(quanLyPhanBonEntities.LoaiPhanBons.ToList());
            quanLyPhanBonEntities.SaveChanges();
            foreach (var loaiPhan in _listLoaiPhanBon)
            {
                _loaiPhanBon.Add(new KeyValuePair<int, string>(loaiPhan.IDLoaiPhanBon, loaiPhan.TenLoaiPhanBon));
            }
        }
    }
}
