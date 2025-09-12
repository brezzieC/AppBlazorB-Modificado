using AppBlazor.Entities;
using System;

namespace AppBlazor.Client.Services
{
    public class LibroService
    {
        private List<LibroListCLS> lista;
        private TipoLibroService tipolibroservice;
        public LibroService(TipoLibroService _tipolibroservice)
        {
            tipolibroservice = _tipolibroservice;
            lista = new List<LibroListCLS>();
            lista.Add(new LibroListCLS { idLibro= 1, titulo="Libro 1", nombreTipoLibro="Romance"});
            lista.Add(new LibroListCLS { idLibro = 2, titulo = "Libro 2", nombreTipoLibro = "Terror" });
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
            if (obj != null)
            {
                return new LibroFormCLS
                {
                    idLibro = obj.idLibro,
                    titulo = obj.titulo,
                    resumen = "Resumen",
                    idTipoLibro = tipolibroservice.ObtenerIdTipoLibro(obj.nombreTipoLibro),
                    image = obj.imagen // Usamos el nuevo método para obtener el ID
                };
            }
            else
            {
                return new LibroFormCLS();
            }
        }
        public string recuperarArchivoPorId(int idlibro)
        {
            var obj = lista.Where(p => p.idLibro == idlibro).FirstOrDefault();
            if (obj != null && obj.archivo != null)
            {
                return Convert.ToBase64String(obj.archivo);
            }
            else
            {
                return "";
            }
        }
        public void guardarLibro(LibroFormCLS oLibroFormCLS)
        {
            // ♦ hoy
            if(oLibroFormCLS.idLibro == 0)
            {
                int idLibro = lista.Select(p => p.idLibro).Max() + 1;
                lista.Add(new LibroListCLS
                {
                    idLibro = idLibro,
                    titulo = oLibroFormCLS.titulo,
                    nombreTipoLibro = tipolibroservice.ObtenerTipoLibro(oLibroFormCLS.idTipoLibro),
                    imagen = oLibroFormCLS.image,

                    archivo = oLibroFormCLS.archivo,
                    nombrearchivo = oLibroFormCLS.nombrearchivo
                });
            }
            else
            {
                var obj = lista.Where(p => p.idLibro == oLibroFormCLS.idLibro).FirstOrDefault();
                if(obj != null)
                {
                    obj.titulo = oLibroFormCLS.titulo;
                    obj.nombreTipoLibro = tipolibroservice.ObtenerNombreTipoLibro(oLibroFormCLS.idTipoLibro);
                    obj.imagen = oLibroFormCLS.image;

                    obj.archivo = oLibroFormCLS.archivo;
                    obj.nombrearchivo = oLibroFormCLS.nombrearchivo;
                }
            }
            
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
