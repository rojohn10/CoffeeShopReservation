using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void TapFacebook_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/stifmeisterPH/?view_public_for=101689931305164"));
        }

        private void TapTwitter_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://twitter.com/stifLerojohn10"));
        }

        private void TapInstagram_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/stiflerojohn/"));
        }

        private void TapYoutube_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/channel/UCoOMBMynlhiLubugCNv85OA?view_as=subscriber"));
        }

        private void TapPhone_Tapped(object sender, EventArgs e)
        {
            PhoneDialer.Open("09170000000");
        }
    }
}