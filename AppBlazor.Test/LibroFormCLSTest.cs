//Agregar de manera manual la directiva para acceder al formulario de
//la directiva que tenemos aca.
using AppBlazor.Entities;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Test
{
    public class LibroFormCLSTest
    {
        [Fact] // Automatiza que la prueba se vaya ejecutando
        public void Test1()
        {

        }
        //Primero crear un metodo privado, para hacer la validacion
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            //Se validara el objeto, en base a un contexto en la que se obtendran resultados.
            return resultados;
        }//Lista que contienen los resultados de las validaciones

        //Iniciaremos la prueba unitaria 1
        [Fact]
        public void ValidacionDebeFallarCuandoCamposEstanVacios()
        {
            var libro = new LibroFormCLS();
            var errores = ValidarModelo(libro);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El Id del libro es requerido.") ||
            e.ErrorMessage!.Contains("El id del libro debe ser positivo"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El titulo es requerido."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El resumen es requerido."));
            //assert -> mensajes que seran la comparacion de los mensajes
        }

        //Prueba unitaria 2
        [Fact]
        public void ValidacionDebePasarConDatosCorrectos()
        {
            var libro = new LibroFormCLS
            {
                idLibro = 1,
                titulo = "Libro de prueba",
                resumen = "Este es el resumen el libro de prueba"
            };
            var errores = ValidarModelo(libro);

            Assert.Empty(errores);
        }
    }
}