
namespace ProyectoOL.Dtos
{
    public class BookDto
    {
        /*public BookDto(int Id_Libro, string Nombre_Libro, string Autor, string Fecha,short Fk_Genero,short Fk_EStado,string Imagen,string Pdf,string Descripción) 
        { 
            this.Id_Libro = Id_Libro;
            this.Nombre_Libro = Nombre_Libro;
            this.Autor = Autor;
            this.Fecha = Fecha;
            this.Fk_Genero = Fk_Genero;
            this.Fk_Estado = Fk_Estado;
            this.Imagen = Imagen;
            this.Pdf = Pdf;
            this.Descripcion = Descripcion;
        }*/
        public int Id_Libro { get; set; }

        public string Nombre_Libro { get; set; } = string.Empty;

        public string Autor { get; set;} = string.Empty;

        public string Fecha {  get; set;}

        public short Fk_Genero {  get; set; }

        public short Fk_Estado { get; set; }

        public string Imagen { get; set; } = string.Empty;

        public string Pdf { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;
        public int Indice {  get; set; }
    }

}