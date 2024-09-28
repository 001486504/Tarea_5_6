using MiAppCrud.Models;
using MiAppCrud.Controllers;
namespace MiAppCrud.Views;

public partial class ProductoEditPage : ContentPage
{
    private Producto _producto;
    private CategoriaController _categoriaController;
    private ProveedorController _proveedorController;

    public ProductoEditPage(Producto producto = null)
    {
        InitializeComponent();
        _producto = producto ?? new Producto();
        _categoriaController = new CategoriaController();
        _proveedorController = new ProveedorController();

        LoadCategorias();
        if (_producto.Id != 0)
        {
            NombreEntry.Text = _producto.Nombre;
            PrecioEntry.Text = _producto.Precio.ToString();
            CategoriaPicker.SelectedIndex = _producto.CategoriaId - 1;
            ProveedorPicker.SelectedIndex = (_producto.ProveedorId - 1);
        }
    }

    private async void LoadCategorias()
    {
        var categorias = await _categoriaController.GetAllCategorias();
        CategoriaPicker.ItemsSource = categorias;
        CategoriaPicker.ItemDisplayBinding = new Binding("Nombre");

        var proveedor = await _proveedorController.GetAllProveedores();
        ProveedorPicker.ItemsSource = proveedor;
        ProveedorPicker.ItemDisplayBinding = new Binding("Nombre");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _producto.Nombre = NombreEntry.Text;
        _producto.Precio = decimal.Parse(PrecioEntry.Text);
        _producto.CategoriaId = ((Categoria)CategoriaPicker.SelectedItem).Id;

        var controller = new ProductoController();
        if (_producto.Id == 0)
            await controller.AddProducto(_producto);
        else
            await controller.UpdateProducto(_producto);

        await Navigation.PopAsync();
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var controller = new ProductoController();
        if (_producto.Id != 0)
            await controller.DeleteProducto(_producto.Id);
         
            await Navigation.PopAsync();
    }
}
