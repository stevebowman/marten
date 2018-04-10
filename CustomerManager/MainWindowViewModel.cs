using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable UnusedAutoPropertyAccessor.Global

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
            using (var session = App.Store.LightweightSession())
            {
                var accountManager = new AccountManager {Name = "Bob"};

                session.Store(accountManager);

                Customer.AccountManagerId = accountManager.Id;

                session.Store(Customer);

                session.SaveChanges();
            }
        }
        private void LoadData()
        {
            using (var session = App.Store.QuerySession())
            {
                Customer = session.Load<Customer>(IdToLoad);
            }
        }

        private void UpdateData()
        {
            using (var session = App.Store.LightweightSession())
            {
                session.Store(Customer);

                session.SaveChanges();
            }
        }

        private void DeleteData()
        {
            using (var session = App.Store.LightweightSession())
            {
                session.Delete(Customer);
                session.SaveChanges();
            }

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