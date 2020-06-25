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
    public partial class OrdersPage : ContentPage
    {
        public ObservableCollection<OrderByUser> OrdersCollection;

        public OrdersPage()
        {
            InitializeComponent();
            OrdersCollection = new ObservableCollection<OrderByUser>();
            GetOrderItems();
        }

        private async void GetOrderItems()
        {
            var orders = await ApiService.GetOrdersByUser(Preferences.Get("userId", 0));

            foreach (var item in orders)
            {
                OrdersCollection.Add(item);
            }

            LvOrders.ItemsSource = OrdersCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}