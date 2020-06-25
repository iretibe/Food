using Food.Mobile.Models;
using Food.Mobile.Services;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
        public ObservableCollection<OrderDetail> OrderDetailCollection;

        public OrderDetailPage(int orderId)
        {
            InitializeComponent();
            OrderDetailCollection = new ObservableCollection<OrderDetail>();
            GetOrderDetail(orderId);
        }

        private async void GetOrderDetail(int orderId)
        {
            var orders = await ApiService.GetOrderDetails(orderId);
            var orderDetails = orders[0].orderDetails;

            foreach (var item in orderDetails)
            {
                OrderDetailCollection.Add(item);
            }

            LvOrderDetail.ItemsSource = OrderDetailCollection;

            LblTotalPrice.Text = orders[0].orderTotal + " $ ";
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}