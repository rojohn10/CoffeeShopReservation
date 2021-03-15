
using Expresso.Models;
using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = Expresso.Models.Menu;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public static bool First = true;

        public ObservableCollection<Menu> Menus;
        public MenuPage()
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>(); //instantiate the Menus
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();
                foreach (var menu in menus)
                {
                    Menus.Add(menu); //add item to ObservableCollection Menus
                }
                LvMenu.ItemsSource = Menus; // assign the ObservableCollection Menus to our listview
                BusyIndicator.IsRunning = false; //unload the loader indicator when the MenuPage loaded
            }

            First = false;
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu = e.SelectedItem as Menu;
            
            if (selectedMenu != null)
            {
                Navigation.PushAsync(new SubMenuPage(selectedMenu));
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}