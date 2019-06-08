using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using QuanLyPhanPhanBon.Model;
using QuanLyPhanPhanBon.View.Nhap;

namespace QuanLyPhanPhanBon.ViewModel.NhapViewModel
{
    public class DanhSachViewModel :BaseViewModel
    {
        private bool isClickDelete = false;
        private bool CheckDeleted = false;
        public DanhSachViewModel()
        {
            _IsSelectedRow = true;
            _advancedFormat = Visibility.Collapsed;
            _AllSelected = true;
            _isChecked = true;
            FillMyDataGrid();
            DeletePhanBon = new DelegateCommand(DeletePB);
            ConfirmDelete = new DelegateCommand(ConfirmDeletePhanBon);
            RefreshData = new DelegateCommand(RefreshDataNew);
            AddPhanBon = new DelegateCommand(addPhanBon);
            //Refesh();
        }
       
        private ObservableCollection<LoaiPhanBon> _listLoaiPhanBon;
        private ObservableCollection<PhanBon> phanBonDataTable;
        private ObservableCollection<PhanBon> TemplatePhanBonDataTable;
        public ObservableCollection<PhanBon> phanBonCungLoai = new ObservableCollection<PhanBon>();
        public ObservableCollection<PhanBon> phanBonChecked = new ObservableCollection<PhanBon>();
        private LoaiPhanBon _selectedLoaiPhanBon;
        private PhanBon _selectedPhanBon;
        private bool _isChecked;
     

        private bool _AllSelected;
        public bool AllSelected
        {
            get { return _AllSelected; }
            set
            {
                _AllSelected = value;
                
                OnPropertyChanged("AllSelected");
            }
        }
        private bool _IsSelectedRow;
        public bool IsSelectedRow
        {
            get { return _IsSelectedRow; }
            set
            {
                _IsSelectedRow = value;

                OnPropertyChanged("IsSelectedRow");
            }
        }

        public bool isChecked
        {
            get { return this._isChecked; }
            set
            {
                if (this._isChecked != value)
                {
                    this._isChecked = value;
                    OnPropertyChanged("isChecked");
                }

            }
        }
        // Visible Button delete
        public Visibility _advancedFormat = Visibility.Visible ;

    public Visibility AdvancedFormat
        {
            get { return _advancedFormat; }
            set
            {
                _advancedFormat = value;
                OnPropertyChanged("AdvancedFormat");
            }
        }
        // Visible Button add
        public Visibility _AddadvancedFormat = Visibility.Visible;

        public Visibility AddAdvancedFormat
        {
            get { return _AddadvancedFormat; }
            set
            {
                _AddadvancedFormat = value;
                OnPropertyChanged("AddAdvancedFormat");
            }
        }
        public ObservableCollection<PhanBon> PhanBonDataTable
        {
            get { return phanBonDataTable; }
            set
            {
                phanBonDataTable = value;
                OnPropertyChanged("PhanBonDataTable");
            }
        }
       
      
        public ObservableCollection<LoaiPhanBon> listLoaiPhanBon
        {
            get { return _listLoaiPhanBon; }
            set
            {
                _listLoaiPhanBon = value;
                OnPropertyChanged("listLoaiPhanBon");
            }
        }
        
        public PhanBon SelectedPhanBon
        {

            get
            {
                return _selectedPhanBon;
            }
            set
            {
                _selectedPhanBon = value;
                OnPropertyChanged("SelectedPhanBon");
                
                if (isClickDelete==false)
                {
                    
                    if (_selectedPhanBon != null)
                    {
                        ChinhSuaPhanBonViewModel.phanBon = _selectedPhanBon;
                        ChinhSuaPhanBon chinhSuaPhanBon = new ChinhSuaPhanBon();
                        chinhSuaPhanBon.ShowDialog();
                        
                        if (_selectedLoaiPhanBon != null)
                        {
                            FillMyDataGrid();
                            PhanBonTheoLoai();

                            return;
                        }

                        else
                        {

                            FillMyDataGrid();
                            return;
                        }
                    }
                }
                else
                {
                   
                    if(_selectedPhanBon!=null)
                    {
                        

                        if (_selectedLoaiPhanBon == null)
                            {

                                for (int i = 0; i < phanBonDataTable.Count; i++)
                                {
                                    if (phanBonDataTable[i].IDPhanBon == _selectedPhanBon.IDPhanBon)
                                    {

                                      
                                        if(_selectedPhanBon.isDelete==true)
                                        {
                                            TemplatePhanBonDataTable[i].isDelete = false;
                                            phanBonDelete(TemplatePhanBonDataTable);
                                        //disbale selected row
                                        _selectedPhanBon = null;
                                        OnPropertyChanged("SelectedPhanBon");
                                        return;

                                    }
                                        else
                                        {
                                            TemplatePhanBonDataTable[i].isDelete = true;
                                            phanBonDelete(TemplatePhanBonDataTable);
                                            //disbale selected row
                                            _selectedPhanBon = null;
                                            OnPropertyChanged("SelectedPhanBon");
                                            return;

                                        }


                                    }
                                }
                              
                                        
                        }
                        else
                        {
                            if (phanBonCungLoai.Count>0)
                            {
                                for (int i = 0; i < phanBonDataTable.Count; i++)
                                {
                                    if (phanBonDataTable[i].IDPhanBon == _selectedPhanBon.IDPhanBon)
                                    {


                                        if (_selectedPhanBon.isDelete == true)
                                        {
                                            phanBonCungLoai[i].isDelete = false;
                                            phanBonDelete(phanBonCungLoai);
                                            //disbale selected row
                                            _selectedPhanBon = null;
                                            OnPropertyChanged("SelectedPhanBon");
                                            return;

                                        }
                                        else
                                        {
                                            phanBonCungLoai[i].isDelete = true;
                                            phanBonDelete(phanBonCungLoai);
                                            //disbale selected row
                                            _selectedPhanBon = null;
                                            OnPropertyChanged("SelectedPhanBon");
                                            return;

                                        }


                                    }
                                }
                            }
                        }
                    }
                   
                   

                 
                    
                    

                }
                
              
            }
        }
       
        public LoaiPhanBon SelectedLoaiPhanBon
        {
            get
            {
                return _selectedLoaiPhanBon;
            }
            set
            {
                _selectedLoaiPhanBon = value;
                OnPropertyChanged("SelectedLoaiPhanBon");
                PhanBonTheoLoai();
                
            }
        }
        private void phanBonDelete(ObservableCollection<PhanBon> phanBons)
        {
            if (phanBonChecked.Count >0)
            {
                phanBonChecked.Clear();
            }
            for(int i=0;i<phanBons.Count;i++)           
            {
                phanBonChecked.Add(phanBons[i]);
            }
            if(phanBonDataTable!=null)
            {
                phanBonDataTable=null;
                phanBonDataTable = phanBonChecked;
                OnPropertyChanged("PhanBonDataTable");
            }
        }

        public ICommand DeletePhanBon
        {
            get;
            private set;
        }
        public ICommand ConfirmDelete
        {
            get;
            private set;
        }
        public void ConfirmDeletePhanBon(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa những phân bón chứ?", "Quản lý phân bón", MessageBoxButton.YesNo, MessageBoxImage.Hand);
            if (result == MessageBoxResult.Yes)
            {
                QuanLyPhanBonEntities quanLyPhanBonEntities = new QuanLyPhanBonEntities();
                for (int i = 0; i < phanBonChecked.Count; i++)
                {

                    if (phanBonChecked[i].isDelete == true)
                    {
                        PhanBon temp = quanLyPhanBonEntities.PhanBons.Find(phanBonChecked[i].IDPhanBon);
                        temp.isDelete = true;
                        quanLyPhanBonEntities.SaveChanges();
                    }

                }
                FillMyDataGrid();
            }
            else
            {   
                checkBox.Visibility = Visibility.Collapsed;
                AddAdvancedFormat = Visibility.Visible;
                AdvancedFormat = Visibility.Collapsed;
                isClickDelete = false;
            }
             
        }
        public ICommand AddPhanBon
        {
            get;
            private set;
        }
        private void addPhanBon(object parameter)
        {
            ThemPhanBon themPhanBon = new ThemPhanBon();
            themPhanBon.ShowDialog();
            if (_selectedLoaiPhanBon != null)
            {
                FillMyDataGrid();
                PhanBonTheoLoai();

                return;
            }

            else
            {

                FillMyDataGrid();
                return;
            }
        }
        public ICommand RefreshData
        {
            get;
            private set;
        }
        private void RefreshDataNew(object parameter)
        {
            FillMyDataGrid();
        }
        public object InventaireItemGrid { get; private set; }
        DataGridTemplateColumn checkBox = new DataGridTemplateColumn();
        public void DeletePB(object parameter)
        {
            isClickDelete = true;
             checkBox = parameter as DataGridTemplateColumn;
            checkBox.Visibility = Visibility.Visible;
            AddAdvancedFormat = Visibility.Collapsed;
            AdvancedFormat = Visibility.Visible;
        }
      
        void PhanBonTheoLoai()
        {
            phanBonCungLoai.Clear();
            for(int i=0;i< TemplatePhanBonDataTable.Count;i++)
            {
                if(_selectedLoaiPhanBon.IDLoaiPhanBon==TemplatePhanBonDataTable[i].LoaiPhanBon)
                {
                    phanBonCungLoai.Add(TemplatePhanBonDataTable[i]);
                    //MessageBox.Show(phanBonCungLoai.Count.ToString());
                    OnPropertyChanged("PhanBonDataTable");
                }
            }
            Refesh();


        }
      
        public void Refesh()
        {
            
            //phanBonDataTable.Clear();
           
            phanBonDataTable = phanBonCungLoai;
            OnPropertyChanged("PhanBonDataTable");
           // MessageBox.Show(TemplatePhanBonDataTable.Count.ToString());
        }
        public void FillMyDataGrid()
        {
             QuanLyPhanBonEntities entities = new QuanLyPhanBonEntities();

            ObservableCollection<PhanBon> phanBonDataTableEntities =  new ObservableCollection<PhanBon>(entities.PhanBons.ToList()) ;
            phanBonDataTable = new ObservableCollection<PhanBon>();
            for(int i=0;i< phanBonDataTableEntities.Count;i++)
            {
                if(phanBonDataTableEntities[i].isDelete==false)
                {
                    phanBonDataTable.Add(phanBonDataTableEntities[i]);
                }
            }
            OnPropertyChanged("PhanBonDataTable");
            _listLoaiPhanBon = new ObservableCollection<LoaiPhanBon>( entities.LoaiPhanBons.ToList());
            entities.SaveChanges();
            TemplatePhanBonDataTable = new ObservableCollection<PhanBon>();
           for(int i=0;i<phanBonDataTable.Count;i++)
            {
                TemplatePhanBonDataTable.Add(phanBonDataTable[i]);
            }
        }
    }
}
