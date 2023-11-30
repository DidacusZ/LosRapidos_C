using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelos
{
    public class Prestamos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id_prestamo { get; set; }

        public int id_usuario { get; set; }
        public Usuarios usuario { get; set; }
        public int id_estdo_prestamo { get; set; }

        public int cantidad_libro { get; set; }
        public DateTime fch_inicio_prestamo { get; set; }
        public DateTime fch_fin_prestamo { get; set; }
        public DateTime fch_entrega_prestamo { get; set; }


        public List<Libros> LibrosPrestamos { get; } = new();


        #region Constructores

        public Prestamos()
        {
        }

        public Prestamos(int id_prestamo, int id_usuario, Usuarios usuario, int id_estdo_prestamo, int cantidad_libro, DateTime fch_inicio_prestamo, DateTime fch_fin_prestamo, DateTime fch_entrega_prestamo, List<Libros> librosPrestamos)
        {
            this.id_prestamo = id_prestamo;
            this.id_usuario = id_usuario;
            this.usuario = usuario;
            this.id_estdo_prestamo = id_estdo_prestamo;
            this.cantidad_libro = cantidad_libro;
            this.fch_inicio_prestamo = fch_inicio_prestamo;
            this.fch_fin_prestamo = fch_fin_prestamo;
            this.fch_entrega_prestamo = fch_entrega_prestamo;
            LibrosPrestamos = librosPrestamos;
        }

        #endregion
    }
}