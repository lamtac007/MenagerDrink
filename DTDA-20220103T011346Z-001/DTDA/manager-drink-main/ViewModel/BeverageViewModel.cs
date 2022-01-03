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
    public class BeverageViewModel : BaseViewModel
    {
        private ObservableCollection<Beverage> _List;
        public ObservableCollection<Beverage> List { get => _List; set { _List = value; OnPropertyChanged(); } }
       // private ObservableCollection<TypeOfBeverage> _TypeOfBeverage;
        //public ObservableCollection<TypeOfBeverage> TypeOfBeverage { get => _TypeOfBeverage; set { _TypeOfBeverage = value; OnPropertyChanged(); } }

        private Beverage _SelectedItem;
        public Beverage SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id_beverage = SelectedItem.Id_beverage;
                    Name_beverage = SelectedItem.Name_beverage;
                    Description = SelectedItem.Description;
                    TypeOfBeverage_id = SelectedItem.Typeofbeverage_id;
                    Price = SelectedItem.Price;
                    Manufacturing_date = SelectedItem.Manufacturing_date;
                    Expiry_date = SelectedItem.Expiry_date;
                    Date_in = SelectedItem.Date_in;
                    Date_out = SelectedItem.Date_out;
                    Total_input = SelectedItem.Total_input;
                    Inventory = SelectedItem.Inventory;

                }
            }
        }
        private int? _TypeOfBeverage_id;
        public int? TypeOfBeverage_id { get => _TypeOfBeverage_id; set { _TypeOfBeverage_id = value; OnPropertyChanged(); } }

        private string _Name_beverage;
        public string Name_beverage { get => _Name_beverage; set { _Name_beverage = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }

        private double? _Price;
        public double? Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private DateTime? _Manufacturing_date;
        public DateTime? Manufacturing_date { get => _Manufacturing_date; set { _Manufacturing_date = value; OnPropertyChanged(); } }

        private DateTime? _Expiry_date;
        public DateTime? Expiry_date { get => _Expiry_date; set { _Expiry_date = value; OnPropertyChanged(); } }
        private DateTime? _Date_in;
        public DateTime? Date_in { get => _Date_in; set { _Date_in = value; OnPropertyChanged(); } }
        private DateTime? _Date_out;
        public DateTime? Date_out { get => _Date_out; set { _Date_out = value; OnPropertyChanged(); } }
       
        private int? _Total_input;
        public int? Total_input { get => _Total_input; set { _Total_input = value; OnPropertyChanged(); } }

        private int? _Inventory;
        public int? Inventory { get => _Inventory; set { _Inventory = value; OnPropertyChanged(); } }

        private int _Id_beverage;
        public int Id_beverage { get => _Id_beverage; set { _Id_beverage = value; OnPropertyChanged(); } }

       

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public BeverageViewModel()
        {
            List = new ObservableCollection<Beverage>(DataProvider.Ins.DB.Beverages);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Beverage = new Beverage() { Name_beverage= Name_beverage, Description = Description, Price = Price, Typeofbeverage_id = TypeOfBeverage_id, Inventory=Inventory,Total_input=Total_input,Date_out= Date_out, Expiry_date = Expiry_date, Manufacturing_date= Manufacturing_date, Date_in=Date_in };
                DataProvider.Ins.DB.Beverages.Add(Beverage);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Beverage);
            });
            /////////////////////////////////////////////////////////////////////
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name_beverage) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Beverages.Where(x => x.Name_beverage == Name_beverage);
                var displayList1 = DataProvider.Ins.DB.Beverages.Where(x => x.Price ==Price);
                var displayList2 = DataProvider.Ins.DB.Beverages.Where(x => x.Total_input == Total_input);
                var displayList3 = DataProvider.Ins.DB.Beverages.Where(x => x.Typeofbeverage_id == TypeOfBeverage_id);
                var displayList4 = DataProvider.Ins.DB.Beverages.Where(x => x.Inventory==Inventory);
                var displayList5 = DataProvider.Ins.DB.Beverages.Where(x => x.Description == Description);

                var displayList6 = DataProvider.Ins.DB.Beverages.Where(x => x.Expiry_date == Expiry_date);
                if ((displayList != null || displayList.Count() == 0) || (displayList1 != null || displayList1.Count() == 0) || (displayList2 != null || displayList2.Count() == 0) || (displayList3 != null || displayList3.Count() == 0) || (displayList4 != null || displayList4.Count() == 0)|| displayList5 != null || displayList5.Count() == 0|| displayList6 != null || displayList6.Count() == 0)
                    return true;
                return false;
            }, (p) =>
            {
                var Beverage = DataProvider.Ins.DB.Beverages.Where(x => x.Id_beverage == SelectedItem.Id_beverage).SingleOrDefault();
                Beverage.Name_beverage= Name_beverage;
                Beverage.Description = Description;
                Beverage.Inventory = Inventory;
                Beverage.Price = Price;
                Beverage.Expiry_date = Expiry_date;
                Beverage.Total_input = Total_input;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_beverage= Name_beverage;

            });
        }


    }
}
