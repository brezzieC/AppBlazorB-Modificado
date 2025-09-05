using AppBlazor.Entities;
using System;

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


        public LibroFormCLS recuperarLibroPorId(int idlibro)
        { 
            var obj = lista.Where(p => p.idLibro == idlibro).FirstOrDefault();
            if(obj != null)
            {
                return new LibroFormCLS { idLibro = obj.idLibro, titulo = obj.titulo, resumen="Resumen"};
            }
            else
            {
                return new LibroFormCLS();
            }
        }
        public void guardarLibro(LibroFormCLS oLibroFormCLS)
        {
            lista.Add(new LibroListCLS
            {
                idLibro = oLibroFormCLS.idLibro,
                titulo = oLibroFormCLS.titulo,
                resumen = oLibroFormCLS.resumen
            });
        }

        public void actualizarLibro(LibroFormCLS libro)
        {
            var libroExistente = lista.FirstOrDefault(l => l.idLibro == libro.idLibro);

            if (libroExistente != null)
            {
                libroExistente.titulo = libro.titulo;
                libroExistente.resumen = libro.resumen;
            }
            else
            {
                throw new Exception("Libro no encontrado para actualizar.");
            }
        }



    }
}
