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
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<User> _List;
        public ObservableCollection<User> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Role> _Role;
        public ObservableCollection<Role> Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }

        private User _SelectedItem;
        public User SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                  //  Id_user=SelectedItem.Id_user;
                    Name_user = SelectedItem.Name_user;
                    Phone_number = SelectedItem.Phone_number;
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    Password = SelectedItem.Password;         
                    ContractDate = SelectedItem.Created_at;
                    ContractDate = SelectedItem.Update_at;
                    Role_id = SelectedItem.Role_id;

                }
            }
        }
        private string _Name_user;
        public string Name_user { get => _Name_user; set { _Name_user = value; OnPropertyChanged(); } }

        private int? _Role_id;
        public int? Role_id { get => _Role_id; set { _Role_id = value; OnPropertyChanged(); } }

        private string _Phone_number;
        public string Phone_number { get => _Phone_number; set { _Phone_number = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }
     


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public UserViewModel()
        {
            List = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
            Role = new ObservableCollection<Role>(DataProvider.Ins.DB.Roles);
            AddCommand = new RelayCommand<object>((p) =>
            {
                
                return true;
            }, (p) =>
            {
                var User = new User() { Name_user = Name_user, Address=Address, Email= Email, Password = Password ,Phone_number = Phone_number, Role_id = Role_id };
                DataProvider.Ins.DB.Users.Add(User);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(User);
            });
            /////////////////////////////////////////////////////////////////////
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name_user) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Users.Where(x => x.Name_user == Name_user);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var User = DataProvider.Ins.DB.Users.Where(x => x.Id_user == SelectedItem.Id_user).SingleOrDefault();
                User.Name_user = Name_user;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name_user = Name_user;

            });
        }


    }
  
}
