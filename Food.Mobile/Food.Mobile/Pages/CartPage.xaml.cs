using Food.Mobile.Models;
using Food.Mobile.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<ShoppingCartItem> ShoppingCartCollection;

        public CartPage()
        {
            InitializeComponent();
            ShoppingCartCollection = new ObservableCollection<ShoppingCartItem>();
            GetShoppingCartItems();
            GetTotalPrice();
        }

        private async void GetTotalPrice()
        {
            var totalPrice = await ApiService.GetCartSubTotal(Preferences.Get("userId", 0));
            LblTotalPrice.Text = totalPrice.subTotal.ToString();
        }

        private async void GetShoppingCartItems()
        {
            var shoppingCartItems = await ApiService.GetShoppingCartItems(Preferences.Get("userId", 0));

            foreach (var item in shoppingCartItems)
            {
                ShoppingCartCollection.Add(item);
            }

            LvShoppingCart.ItemsSource = ShoppingCartCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TapClearCart_Tapped(object sender, EventArgs e)
        {
            var response = await ApiService.ClearShoppingCart(Preferences.Get("userId", 0));
            
            if (response)
            {
                await DisplayAlert("", "Your cart has been cleared", "Okay");
                LvShoppingCart.ItemsSource = null;
                LblTotalPrice.Text = 0.ToString();
            }
            else
            {
                await DisplayAlert("Ooops", "Something went wrong", "Cancel");
            }
        }

        private void BtnProceed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PlaceOrderPage(Convert.ToDouble(LblTotalPrice.Text)));
        }
    }
}