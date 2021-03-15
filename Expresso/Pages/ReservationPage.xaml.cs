using Expresso.Models;
using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }

        private async void BtnBookTable_Clicked(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation()
            {
                //Assign the values of the properties of the Reservation page to the Reservation model
                Name = EntName.Text,
                Email = EntEmail.Text,
                Phone = EntPhone.Text,
                TotalPeople = EntTotalPeople.Text,
                Date = DpBookingDate.Date.ToString(),
                Time = TpBookingTime.Time.ToString() 
            };
            
            ApiServices apiServices = new ApiServices(); //initialize ApiServices so we can use the ReserveTable method
            bool response = await apiServices.ReserveTable(reservation);
            if (response != true)
            {
                await DisplayAlert("Oops", "Something goes wrong!", "Alright!");
            }
            else
            {
                await DisplayAlert("Success", "Your table has been reserved successfully!", "Alright");
                ClearReservationPage();
            }
        }

        void ClearReservationPage()
        {
            EntName.Text = "";
            EntEmail.Text = "";
            EntPhone.Text = "";
            EntTotalPeople.Text = "";
        }
    }
}