using ProyectoOL.Dtos;
using ProyectoOL.Repositories.Models;
using System;
using System.Linq;

namespace ProyectoOL.Repositories
{
    public class BookRepository
    {
        public int CreateBook(BookDto book)
        {
            try
            {
                using (OLDBEntities db = new OLDBEntities())
                {
                    CAT_LIBRO tBook = new CAT_LIBRO
                    {
                        NOMBRE_LIBRO = book.Nombre_Libro,
                        AUTOR = book.Autor,
                        FECHA = book.Fecha,
                        FK_ESTADO = (short)4,
                        FK_GENERO = book.Fk_Genero,
                        PDF = book.Pdf,
                        SINOPSIS = book.Descripcion,
                        IMAGEN = book.Imagen
                    };
                    db.CAT_LIBRO.Add(tBook);
                    db.SaveChanges();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return 1;
            }
        }
    }
}