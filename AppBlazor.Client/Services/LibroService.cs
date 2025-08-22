using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class LibroService
    {
        private List<LibroListCLS> lista;
        public LibroService()
        {
            lista = new List<LibroListCLS>();
            lista.Add(new LibroListCLS { idLibro= 1, titulo="Libro 1"});
            lista.Add(new LibroListCLS { idLibro = 2, titulo = "Libro 2" });
        }
        public List<LibroListCLS> listarLibros()
        {
            return lista;
        }
        public void eliminarLibros(int idlibro)
        {
            var listaQueda = lista.Where(p => p.idLibro != idlibro).ToList();
           lista = listaQueda;
        }
    }
}
