using MiAppCrud.Models;
using MiAppCrud.Controllers;

namespace MiAppCrud.Views;

public partial class OrdenEditPage : ContentPage
{
    private Orden _orden;
    private ProductoController _productoController;

    public OrdenEditPage(Orden orden = null)
    {
        InitializeComponent();
        _orden = orden ?? new Orden();
        _productoController = new ProductoController();
        LoadProductos();
        if (_orden.Id != 0)
        {
            ProductoPicker.SelectedIndex = (_orden.ProductoId - 1);
        }
    }

    private async void LoadProductos()
    {
        var productos = await _productoController.GetAllProductos();
        ProductoPicker.ItemsSource = productos;
        ProductoPicker.ItemDisplayBinding = new Binding("Nombre");

    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _orden.Fecha = FechaPicker.Date;
        _orden.ProductoId = ((Producto)ProductoPicker.SelectedItem).Id;

        var controller = new OrdenController();
        if (_orden.Id == 0)
            await controller.AddOrden(_orden);
        else
            await controller.UpdateOrden(_orden);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var controller = new OrdenController();
        if (_orden.Id != 0)
            await controller.DeleteOrden(_orden.Id);

        await Navigation.PopAsync();
    }
}