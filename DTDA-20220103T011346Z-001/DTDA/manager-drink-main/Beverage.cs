//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace manager_drink
{
    using manager_drink.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Beverage : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beverage()
        {
            this.Order_Detail = new HashSet<Order_Detail>();
        }

       // private int? _TypeOfBeverage_id;
        //public int? TypeOfBeverage_id { get => _TypeOfBeverage_id; set { _TypeOfBeverage_id = value; OnPropertyChanged(); } }

        private string _Name_beverage;
        public string Name_beverage { get => _Name_beverage; set { _Name_beverage = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }

        private double? _Price;
        public double? Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        Nullable<System.DateTime> _Manufacturing_date;
        public Nullable<System.DateTime> Manufacturing_date { get => _Manufacturing_date; set { _Manufacturing_date = value; OnPropertyChanged(); } }

        Nullable<System.DateTime> _Expiry_date;
        public Nullable<System.DateTime> Expiry_date { get => _Expiry_date; set { _Expiry_date = value; OnPropertyChanged(); } }
        Nullable<System.DateTime> _Date_in;
         public Nullable<System.DateTime> Date_in { get => _Date_in; set { _Date_in = value; OnPropertyChanged(); } }
        Nullable<System.DateTime> _Date_out;
        public Nullable<System.DateTime> Date_out { get => _Date_out; set { _Date_out = value; OnPropertyChanged(); } }

        Nullable<int> _Typeofbeverage_id;
        public Nullable<int> Typeofbeverage_id { get => _Typeofbeverage_id; set { _Typeofbeverage_id = value; OnPropertyChanged(); } }
        Nullable<int> _Total_input;
        public Nullable<int> Total_input { get => _Total_input; set { _Total_input = value; OnPropertyChanged(); } }

        Nullable<int> _Inventory;
        public Nullable<int> Inventory { get => _Inventory; set { _Inventory = value; OnPropertyChanged(); } }

        private int _Id_beverage;
        public int Id_beverage { get => _Id_beverage; set { _Id_beverage = value; OnPropertyChanged(); } }
    
        public virtual TypeOfBeverage TypeOfBeverage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
