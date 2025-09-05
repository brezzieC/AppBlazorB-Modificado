using AppBlazor.Entities;
using System.Linq;

namespace AppBlazor.Client.Services
{
    public class TipoLibroService
    {
        // Lista de tipos de libros
        private List<TipoLibroCLS> lista;

        // Constructor
        public TipoLibroService()
        {
            lista = new List<TipoLibroCLS>()
            {
                new TipoLibroCLS() { idTipoLibro = 1, nombreTipoLibro = "Ciencia Ficción" },
                new TipoLibroCLS() { idTipoLibro = 2, nombreTipoLibro = "Terror" },
                new TipoLibroCLS() { idTipoLibro = 3, nombreTipoLibro = "Romance" }
            };
        }

        // Método para listar todos los tipos de libro
        public List<TipoLibroCLS> ListarTipoLibro()
        {
            return lista;
        }

        // Método para obtener el id del tipo de libro por su nombre
      public string ObtenerTipoLibro(int idtipolibro)
        {
            var obj = lista.Where(p=>p.idTipoLibro == idtipolibro).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombreTipoLibro;

            }
        }
        // Método para obtener el id del tipo de libro por su nombre
        public int ObtenerIdTipoLibro(string nombre)
        {
            var obj = lista.FirstOrDefault(p => p.nombreTipoLibro == nombre);
            return obj?.idTipoLibro ?? 0; // Si no se encuentra, devuelve 0
        }


        // Método para obtener el nombre del tipo de libro por su id
        public string ObtenerNombreTipoLibro(int id)
        {
            var obj = lista.FirstOrDefault(t => t.idTipoLibro == id);
            return obj?.nombreTipoLibro ?? ""; // Si no se encuentra, devuelve una cadena vacía
        }

    }
}
