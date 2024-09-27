using MiAppCrud.Models;
using MiAppCrud.Controllers;
namespace MiAppCrud.Views;

public partial class ProveedorListPage : ContentPage
{
    private ProveedorController _controller;

    public ProveedorListPage()
    {
        InitializeComponent();
        _controller = new ProveedorController();
        LoadProveedores();
    }

    private async void LoadProveedores()
    {
        ProveedoresListView.ItemsSource = await _controller.GetAllProveedores();
    }

    private async void OnAddProviderClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProveedorEditPage());
    }

    private async void OnProviderTapped(object sender, ItemTappedEventArgs e)
    {
        var proveedor = (Proveedor)e.Item;
        await Navigation.PushAsync(new ProveedorEditPage(proveedor));
    }
}
