using MiAppCrud.Models;
using MiAppCrud.Controllers;

namespace MiAppCrud.Views;

public partial class OrdenListPage : ContentPage
{
    private OrdenController _controller;

    public OrdenListPage()
    {
        InitializeComponent();
        _controller = new OrdenController();
        LoadCategorias();
    }

    private async void LoadCategorias()
    {
        OrdenesListView.ItemsSource = await _controller.GetAllOrdenes();
    }

    private async void OnAddOrderClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrdenEditPage());
    }

    private async void OnOrderTapped(object sender, ItemTappedEventArgs e)
    {
        var orden = (Orden)e.Item;
        await Navigation.PushAsync(new OrdenEditPage(orden));
    }
}
