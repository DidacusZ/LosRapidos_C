using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelos
{
    public class Libros
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id_libro { get; set; }
        public string isbn_libro { get; set; }
        public string titulo_libro { get; set; }
        public string edicion_libro { get; set; }


        public int id_editorial { get; set; }//FK-Editoriales
        //public Editorial editorial { get; set; }
        public int id_genero { get; set; }//FK-generos
        //public Genero genero { get; set; }
        public int id_coleccion { get; set; }//FK-coleccion
        //public Coleccion coleccion { get; set; }


        public List<Prestamos> PrestamosLibros { get; } = new();


        #region Constructores

        public Libros()
        {
        }

        public Libros(int id_libro, string isbn_libro, string titulo_libro, string edicion_libro, int id_editorial, int id_genero, int id_coleccion, List<Prestamos> prestamosLibros)
        {
            this.id_libro = id_libro;
            this.isbn_libro = isbn_libro;
            this.titulo_libro = titulo_libro;
            this.edicion_libro = edicion_libro;
            this.id_editorial = id_editorial;
            this.id_genero = id_genero;
            this.id_coleccion = id_coleccion;
            PrestamosLibros = prestamosLibros;
        }

        #endregion
    }
}