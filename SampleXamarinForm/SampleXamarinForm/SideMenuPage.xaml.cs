using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleXamarinForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuPage : ContentPage
    {
        public ListView ListView;

        public SideMenuPage()
        {
            InitializeComponent();
            ListView = lvMenuSide;
            BindingContext = new SideMenuPageViewModel();
        }
    }

    class SideMenuPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyMenuItem> MenuItems { get; set; }
        public SideMenuPageViewModel()
        {
            MenuItems = new ObservableCollection<MyMenuItem>(new[]{
                new MyMenuItem(){Id=0,Title="Main Page",TargetType=typeof(MainPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=1,Title="Setup Employee",TargetType=typeof(ShowEmployeeSQLPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=2,Title="Simple List",TargetType=typeof(SimpleListViewPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=3,Title="Custom List",TargetType=typeof(CustomListViewPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=4,Title="Tab Page",TargetType=typeof(MyTabbedPage),ImageIcon="ic_add.png"}
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}