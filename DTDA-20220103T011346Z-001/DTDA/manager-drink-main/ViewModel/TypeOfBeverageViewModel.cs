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
    class TypeOfBeverageViewModel : BaseViewModel
    {
        private ObservableCollection<TypeOfBeverage> _List;
        public ObservableCollection<TypeOfBeverage> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private TypeOfBeverage _SelectedItem;
        public TypeOfBeverage SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id_TypeOfBeverage = SelectedItem.Id_TypeOfBeverage;
                    Name_TypeOfBeverage = SelectedItem.Name_TypeOfBeverage;
                    Image = SelectedItem.Image;
                    Created_at = SelectedItem.Created_at;


                }
            }
        }
        private string _Name_TypeOfBeverage;
        public string Name_TypeOfBeverage { get => _Name_TypeOfBeverage; set { _Name_TypeOfBeverage = value; OnPropertyChanged(); } }

        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }

        private int _Id_TypeOfBeverage;
        public int Id_TypeOfBeverage { get => _Id_TypeOfBeverage; set { _Id_TypeOfBeverage = value; OnPropertyChanged(); } }

        private DateTime? _Created_at;
        public DateTime? Created_at { get => _Created_at; set { _Created_at = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TypeOfBeverageViewModel()
        {
            List = new ObservableCollection<TypeOfBeverage>(DataProvider.Ins.DB.TypeOfBeverages);
            AddCommand = new RelayCommand<object>((p) =>
            {
                /*
                if (string.IsNullOrEmpty(Name_TypeOfBeverage))
                    return false;
                var displayList = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Name_TypeOfBeverage == Name_TypeOfBeverage);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                */
                return true;
            }, (p) =>
            {
                var TypeOfBeverage = new TypeOfBeverage() { Name_TypeOfBeverage = Name_TypeOfBeverage , Id_TypeOfBeverage=Id_TypeOfBeverage, Image=Image, Created_at=Created_at};
                DataProvider.Ins.DB.TypeOfBeverages.Add(TypeOfBeverage);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(TypeOfBeverage);
            });
            /////////////////////////////////////////////////////////////////////
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Id_TypeOfBeverage== Id_TypeOfBeverage);
                var displayList1 = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Name_TypeOfBeverage == Name_TypeOfBeverage);
                var displayList2 = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Image == Image);
                var displayList3 = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Created_at == Created_at);

                if (displayList != null || displayList.Count() == 0 || (displayList1 != null || displayList1.Count() == 0) || (displayList2 != null || displayList2.Count() == 0) || (displayList3 != null || displayList3.Count() == 0))
                    return true;
                return false;
            }, (p) =>
            {
                var TypeOfBeverage = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Id_TypeOfBeverage == SelectedItem.Id_TypeOfBeverage).SingleOrDefault();
                TypeOfBeverage.Name_TypeOfBeverage= Name_TypeOfBeverage;
                TypeOfBeverage.Created_at = Created_at;
                TypeOfBeverage.Id_TypeOfBeverage = Id_TypeOfBeverage;
                TypeOfBeverage.Image = Image;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_TypeOfBeverage = Name_TypeOfBeverage;

            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.TypeOfBeverages.Where(x => x.Id_TypeOfBeverage == Id_TypeOfBeverage);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var TypeOfBeverage = new TypeOfBeverage() { Name_TypeOfBeverage = Name_TypeOfBeverage, Id_TypeOfBeverage = Id_TypeOfBeverage, Image = Image };
                DataProvider.Ins.DB.TypeOfBeverages.Remove(TypeOfBeverage);
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_TypeOfBeverage = Name_TypeOfBeverage;

            });
        }


    }
   
}
