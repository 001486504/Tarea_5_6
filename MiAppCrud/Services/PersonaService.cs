using MiAppCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAppCrud.Services
{
    public class PersonaService
    {
        private List<Persona> _personas = new List<Persona>();
        private int _nextId = 1;

        public List<Persona> GetAll() => _personas;

        public void Add(Persona persona)
        {
            persona.Id = _nextId++;
            _personas.Add(persona);
        }

        public void Update(Persona persona)
        {
            var existing = _personas.FirstOrDefault(p => p.Id == persona.Id);
            if (existing != null)
            {
                existing.Nombre = persona.Nombre;
                existing.Apellido = persona.Apellido;
                existing.Edad = persona.Edad;
            }
        }

        public void Delete(int id)
        {
            var persona = _personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                _personas.Remove(persona);
            }
        }
    }

}
