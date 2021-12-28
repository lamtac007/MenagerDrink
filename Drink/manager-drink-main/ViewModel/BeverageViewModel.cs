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
    class BeverageViewModel : BaseViewModel
    {
        private ObservableCollection<Beverage> _List;
        public ObservableCollection<Beverage> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Beverage _SelectedItem;
        public Beverage SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id_beverage = SelectedItem.Id_beverage;
                    Typeofbeverage_id = SelectedItem.Typeofbeverage_id;
                    Name_beverage = SelectedItem.Name_beverage;
                    Description = SelectedItem.Description;
                    Price = SelectedItem.Price;
                    ContractDate = SelectedItem.Manufacturing_date;
                    ContractDate1 = SelectedItem.Expiry_date;
                    ContractDate2 = SelectedItem.Date_in;
                    ContractDate3 = SelectedItem.Date_out;
                    Total_in = SelectedItem.Total_input;
                    Inventory = SelectedItem.Inventory;

                }
            }
        }
        private string _Name_beverage;
        public string Name_beverage { get => _Name_beverage; set { _Name_beverage = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }

        private double? _Price;
        public double? Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate1;
        public DateTime? ContractDate1 { get => _ContractDate1; set { _ContractDate1 = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate2;
        public DateTime? ContractDate2 { get => _ContractDate2; set { _ContractDate2 = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate3;
        public DateTime? ContractDate3 { get => _ContractDate3; set { _ContractDate3 = value; OnPropertyChanged(); } }
       
        private int? _Typeofbeverage_id;
        public int? Typeofbeverage_id { get => _Typeofbeverage_id; set { _Typeofbeverage_id = value; OnPropertyChanged(); } }
        private int? _Total_in;
        public int? Total_in { get => _Total_in; set { _Total_in = value; OnPropertyChanged(); } }

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
                var Beverage = new Beverage() { Name_beverage= Name_beverage, Description = Name_beverage, Price = Price, Inventory=Inventory,Total_input=Total_in,Date_out=ContractDate3, Expiry_date = ContractDate1, Manufacturing_date=ContractDate};
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
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Beverage = DataProvider.Ins.DB.Beverages.Where(x => x.Id_beverage == SelectedItem.Id_beverage).SingleOrDefault();
                Beverage.Name_beverage= Name_beverage;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_beverage= Name_beverage;

            });
        }


    }
}
