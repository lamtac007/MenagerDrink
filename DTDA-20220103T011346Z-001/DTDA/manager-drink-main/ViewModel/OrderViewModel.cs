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
                    Order_date = SelectedItem.Order_date;
                    Order_status = SelectedItem.Order_status;
                    User_id = SelectedItem.User_id;
                    Total_money = SelectedItem.Total_money;
                    Id_order = SelectedItem.Id_order;
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

        private DateTime? _Order_date;
        public DateTime? Order_date { get => _Order_date; set { _Order_date = value; OnPropertyChanged(); } }

        private int _Id_order;
        public int Id_order { get => _Id_order; set { _Id_order = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public OrderViewModel()
        {
            List = new ObservableCollection<Order>(DataProvider.Ins.DB.Orders);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Order = new Order() { Name_customer = Name_customer, Address=Address, Email=Email, Customer_balance= Customer_balance, Order_date=Order_date, Order_status=Order_status, Total_money=Total_money, Phone_number=Phone_number,User_id=User_id };
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
                var displayList1 = DataProvider.Ins.DB.Orders.Where(x => x.Phone_number==Phone_number);
                var displayList2 = DataProvider.Ins.DB.Orders.Where(x => x.Total_money==Total_money);
                var displayList3 = DataProvider.Ins.DB.Orders.Where(x => x.Address==Address);
                var displayList4 = DataProvider.Ins.DB.Orders.Where(x => x.Email==Email);
                var displayList5 = DataProvider.Ins.DB.Orders.Where(x => x.Order_date==Order_date);

                var displayList6 = DataProvider.Ins.DB.Orders.Where(x => x.Order_status==Order_status);
                if ((displayList != null || displayList.Count() == 0) || (displayList1 != null || displayList1.Count() == 0) || (displayList2 != null || displayList2.Count() == 0) || (displayList3 != null || displayList3.Count() == 0) || (displayList4 != null || displayList4.Count() == 0) || displayList5 != null || displayList5.Count() == 0 || displayList6 != null || displayList6.Count() == 0)
                    return true;
                return false;
            }, (p) =>
            {
                var Order = DataProvider.Ins.DB.Orders.Where(x => x.User_id== SelectedItem.User_id).SingleOrDefault();
                Order.Phone_number=Phone_number;
                Order.Total_money=Total_money;
                Order.Order_status=Order_status;
                Order.Order_date=Order_date;
                Order.Name_customer=Name_customer;
                Order.Email=Email;
                Order.Address = Address;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_customer = Name_customer;

            });


        }


    }
}
