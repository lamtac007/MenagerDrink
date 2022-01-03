
using manager_drink.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace manager_drink.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        private ObservableCollection<Beverage> _Beverage;
        public ObservableCollection<Beverage> Beverage { get => _Beverage; set { _Beverage = value; OnPropertyChanged(); } }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand OrderDetailCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand BeverageCommand { get; set; }
        public ICommand TypeOfBeverageCommand { get; set; }
        public ICommand RoleCommand { get; set; }

        public MainViewModel()
        {
            Beverage = new ObservableCollection<Beverage>(DataProvider.Ins.DB.Beverages);
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null) return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                  p.Show();
              
                 if (loginWindow.DataContext == null)
                    return;
                
                var loginVM = loginWindow.DataContext as LoginViewModel;
                  if (loginVM.IsLogin)
                  {
                      p.Show();
                  }
                  else {
                      p.Close();
                  }
                  
               
            });
            

            OrderCommand = new RelayCommand<object>((p) => { return true; }, (p) => {OrderWindow wd = new OrderWindow(); wd.ShowDialog(); });
            OrderDetailCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OrderDetailWindow wd = new OrderDetailWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });
            BeverageCommand = new RelayCommand<object>((p) => { return true; }, (p) => { BeverageWindow wd = new BeverageWindow(); wd.ShowDialog(); });
            TypeOfBeverageCommand = new RelayCommand<object>((p) => { return true; }, (p) => {TypeOfBeverageWindow wd = new TypeOfBeverageWindow(); wd.ShowDialog(); });
            RoleCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RoleWindow wd = new RoleWindow(); wd.ShowDialog(); });

           
        }
    }
}
