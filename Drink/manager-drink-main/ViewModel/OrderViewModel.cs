using manager_drink.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace manager_drink.ViewModel
{
    class OrderViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _List;
        public ObservableCollection<Order> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Order _SelectedItem;
        public Order SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Name_customer = SelectedItem.Name_customer;
                    Phone_number = SelectedItem.Phone_number;
                    Customer_balance = SelectedItem.Customer_balance;
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    ContractDate = SelectedItem.Order_date;
                    Order_status = SelectedItem.Order_status;
                    User_id = SelectedItem.User_id;
                    Total_money = SelectedItem.Total_money;
                    
                }
            }
        }
        private string _Name_customer;
        public string Name_customer { get => _Name_customer; set { _Name_customer = value; OnPropertyChanged(); } }

        private string _Phone_number;
        public string Phone_number { get => _Phone_number; set { _Phone_number = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private double? _Customer_balance;
        public double? Customer_balance { get => _Customer_balance; set { _Customer_balance = value; OnPropertyChanged(); } }

        private int _Order_status;
        public int Order_status { get => _Order_status; set { _Order_status = value; OnPropertyChanged(); } }

        private int? _User_id;
        public int? User_id { get => _User_id; set { _User_id = value; OnPropertyChanged(); } }

        private double? _Total_money;
        public double? Total_money { get => _Total_money; set { _Total_money = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }



        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public OrderViewModel()
        {
            List = new ObservableCollection<Order>(DataProvider.Ins.DB.Orders);
            AddCommand = new RelayCommand<object>((p) =>
            {
                /*if (string.IsNullOrEmpty(Name_customer))
                    return false;
                var displayList = DataProvider.Ins.DB.Orders.Where(x => x.Name_customer == Name_customer);
                if (displayList == null || displayList.Count() != 0)
                    return false;*/
                return true;
            }, (p) =>
            {
                var Order = new Order() { Name_customer = Name_customer };
                DataProvider.Ins.DB.Orders.Add(Order);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Order);
            });
            /////////////////////////////////////////////////////////////////////
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name_customer) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Orders.Where(x => x.Name_customer == Name_customer);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Order = DataProvider.Ins.DB.Orders.Where(x => x.Id_order == SelectedItem.Id_order).SingleOrDefault();
                Order.Name_customer = Name_customer;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_customer = Name_customer;

            });
        }


    }
}
