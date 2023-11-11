using System.ComponentModel.DataAnnotations;

namespace ProyectoOL.Dtos
{
    public class BookDto
    {
        public int Id_Libro { get; set; }

        public string Nombre_Libro { get; set; } = string.Empty;

        public string Autor { get; set;} = string.Empty;

        [Required, MaxLength(10)]
        public string Fecha {  get; set;}

        public short Fk_Genero {  get; set; }

        public short Fk_Estado { get; set; }
        [Required, MaxLength(255)]
        public string Imagen { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string Pdf { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Descripcion { get; set; } = string.Empty;
        public int Indice {  get; set; }
    }

}