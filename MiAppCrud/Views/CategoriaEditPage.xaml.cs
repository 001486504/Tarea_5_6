using MiAppCrud.Controllers;
using MiAppCrud.Models;
namespace MiAppCrud.Views;

public partial class CategoriaEditPage : ContentPage
{
    private Categoria _categoria;

    public CategoriaEditPage(Categoria categoria = null)
    {
        InitializeComponent();
        if (categoria != null)
        {
            _categoria = categoria;
            NombreEntry.Text = _categoria.Nombre;
        }
        else
        {
            _categoria = new Categoria();
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _categoria.Nombre = NombreEntry.Text;

        var controller = new CategoriaController();
        if (_categoria.Id == 0)
            await controller.AddCategoria(_categoria);
        else
            await controller.UpdateCategoria(_categoria);

        await Navigation.PopAsync();
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var controller = new CategoriaController();
        if (_categoria.Id != 0)
            await controller.DeleteCategoria(_categoria.Id);
            await Navigation.PopAsync();
    }
}