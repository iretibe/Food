using Food.Mobile.Models;
using Food.Mobile.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrderPage : ContentPage
    {
        private double _totalPrice;

        public PlaceOrderPage(double totalPrice)
        {
            InitializeComponent();
            _totalPrice = totalPrice;
        }

        private async void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {
            var order = new Order();
            order.fullName = EntName.Text;
            order.phone = EntPhone.Text;
            order.address = EntAddress.Text;
            order.userId = Preferences.Get("userId", 0);
            order.orderTotal = _totalPrice;

            var response = await ApiService.PlaceOrder(order);

            if (response != null)
            {
                await DisplayAlert("", "Your Order Id is " + response.orderId, "Okay");

                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Ooops", "Something went wrong", "Cancel");
            }
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}