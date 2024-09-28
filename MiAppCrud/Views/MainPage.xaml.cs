using MiAppCrud.Services;
using MiAppCrud.Models;
using MiAppCrud.Views;

namespace MiAppCrud.Views;

public partial class MainPage : ContentPage
{
    private PersonaService _service = new PersonaService();

    public MainPage()
    {
        InitializeComponent();
        personasList.ItemsSource = _service.GetAll();
    }

    private async void OnAddPersona(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonaPage(_service, null));
    }

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        var persona = e.Item as Persona;
        await Navigation.PushAsync(new PersonaPage(_service, persona));
    }
}
