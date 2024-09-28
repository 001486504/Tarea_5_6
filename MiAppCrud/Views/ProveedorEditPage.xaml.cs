using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views;

public partial class ProveedorEditPage : ContentPage
{
	private Proveedor _proveedor;
	private ProveedorController _controller;
	public ProveedorEditPage(Proveedor proveedor = null)
	{
		InitializeComponent();
        _proveedor = proveedor ?? new Proveedor();

        if (_proveedor.Id != 0)
        {
            NombreEntry.Text = _proveedor.Nombre;
            CelularEntry.Text = _proveedor.Telefono;

        }
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _proveedor.Nombre = NombreEntry.Text;
        _proveedor.Telefono = CelularEntry.Text;

        var controller = new ProveedorController();
        if (_proveedor.Id == 0)
            await controller.AddProveedor(_proveedor);
        else
            await controller.UpdateProveedor(_proveedor);

        await Navigation.PopAsync();
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var controller = new ProveedorController();
        if (_proveedor.Id != 0)
            await controller.DeleteProveedor(_proveedor.Id);

        await Navigation.PopAsync();
    }
}