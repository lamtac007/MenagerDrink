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
    class OrderDetailViewModel : BaseViewModel
    {
        private ObservableCollection<Order_Detail> _List;
        public ObservableCollection<Order_Detail> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        /*private ObservableCollection<Order> _List;
        public ObservableCollection<Order> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Beverage> _List;
        public ObservableCollection<Beverage> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        */
        private Order_Detail _SelectedItem;
        public Order_Detail SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id_orderdetail = SelectedItem.Id_orderdetail;
                   // ID = SelectedItem.Order_id;
                   // Cdouble = SelectedItem.Price;
                    Num = SelectedItem.Num;
                    //Cdouble = SelectedItem.Total_money;
                    Note = SelectedItem.Note;
                    SelectedBeverage = SelectedItem.Beverage;
                    SelectedOrder = SelectedItem.Order;
                }
            }
        }
        private int _Id_orderdetail;
        public int Id_orderdetail { get => _Id_orderdetail; set { _Id_orderdetail = value; OnPropertyChanged(); } }

        private double? _Price;
        public double? Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private int? _Num;
        public int? Num { get => _Num; set { _Num = value; OnPropertyChanged(); } }

        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        private Beverage _SelectedBeverage;
        public Beverage SelectedBeverage
        {
            get => _SelectedBeverage;
            set
            {
                _SelectedBeverage = value;
                OnPropertyChanged();
            }
        }

        private Order _SelectedOrder;
        public Order SelectedOrder
        {
            get => _SelectedOrder;
            set
            {
                _SelectedOrder = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public OrderDetailViewModel()
        {
            List = new ObservableCollection<Order_Detail>(DataProvider.Ins.DB.Order_Detail);
            AddCommand = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                var Order_Detail = new Order_Detail() { Id_orderdetail = Id_orderdetail };
                DataProvider.Ins.DB.Order_Detail.Add(Order_Detail);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Order_Detail);
            });
            /////////////////////////////////////////////////////////////////////
            EditCommand = new RelayCommand<object>((p) =>
            {
               
                return true;
            }, (p) =>
            {
                var Order_Detail = DataProvider.Ins.DB.Order_Detail.Where(x => x.Order_id == SelectedItem.Order_id).SingleOrDefault();
                Order_Detail.Id_orderdetail = Id_orderdetail;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Id_orderdetail = Id_orderdetail;

            });
        }
    }
}
