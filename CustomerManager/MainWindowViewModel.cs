using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;

namespace CustomerManager
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Customer _customer;
        private int _idToLoad;

        public MainWindowViewModel()
        {
            Customer = new Customer();
            
            InsertCommand = new RelayCommand(InsertData);
            LoadCommand = new RelayCommand(LoadData);
            UpdateCommand = new RelayCommand(UpdateData);            
            DeleteCommand = new RelayCommand(DeleteData);            
            ClearCommand = new RelayCommand(ClearData);
        }
        
        public Customer Customer
        {
            get
            {
                return _customer;                 
            }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public int IdToLoad
        {
            get
            {
                return _idToLoad;                 
            }
            set
            {
                _idToLoad = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand InsertCommand { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        

        public event PropertyChangedEventHandler PropertyChanged;


        private void InsertData()
        {
           // TODO
        }
        private void LoadData()
        {
            // TODO
        }

        private void UpdateData()
        {
            // TODO
        }

        private void DeleteData()
        {
            // TODO

            ClearData();
        }

        private void ClearData()
        {
            Customer = new Customer();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}