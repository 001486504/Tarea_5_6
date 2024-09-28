using MiAppCrud.Services;
using MiAppCrud.Models;

namespace MiAppCrud.Views;

public partial class PersonaPage : ContentPage
{
    private PersonaService _service;
    private Persona _persona;

    public PersonaPage(PersonaService service, Persona persona)
    {
        InitializeComponent();
        _service = service;
        _persona = persona;

        if (_persona != null)
        {
            nombreEntry.Text = _persona.Nombre;
            apellidoEntry.Text = _persona.Apellido;
            edadEntry.Text = _persona.Edad.ToString();
            deleteButton.IsVisible = true;
        }
    }

    private async void OnSavePersona(object sender, EventArgs e)
    {
        if (_persona == null)
        {
            var nuevaPersona = new Persona
            {
                Nombre = nombreEntry.Text,
                Apellido = apellidoEntry.Text,
                Edad = int.Parse(edadEntry.Text)
            };
            _service.Add(nuevaPersona);
        }
        else
        {
            _persona.Nombre = nombreEntry.Text;
            _persona.Apellido = apellidoEntry.Text;
            _persona.Edad = int.Parse(edadEntry.Text);
            _service.Update(_persona);
        }

        await Navigation.PopAsync();
    }

    private async void OnDeletePersona(object sender, EventArgs e)
    {
        if (_persona != null)
        {
            _service.Delete(_persona.Id);
            await Navigation.PopAsync();
        }
    }
}
