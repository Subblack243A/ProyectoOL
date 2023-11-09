using ProyectoOL.Dtos;
using ProyectoOL.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoOL.Repositories
{
    public class BookRepository
    {
        public int CreateBook(BookDto book)
        {
            try
            {
                using (OLDBEntities1 db = new OLDBEntities1())
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
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        public List<BookDto> GetAllBooks() { 
            List<BookDto> books = new List<BookDto>();
            BookDto book;
            using (OLDBEntities db = new OLDBEntities())
            {
               var tBooks = db.CAT_LIBRO.ToList();
                foreach (var tBook in tBooks)
                {
                    book = new BookDto()
                    {
                        Id_Libro = tBook.ID_LIBRO,
                        Autor = tBook.AUTOR,
                        Nombre_Libro = tBook.NOMBRE_LIBRO,
                        Fecha = tBook.FECHA,
                        Fk_Genero = (short)tBook.FK_GENERO,
                        Fk_Estado = tBook.FK_ESTADO,
                        Imagen = tBook.IMAGEN,
                        Pdf = tBook.PDF,
                        Descripcion = tBook.SINOPSIS
                    };
                    books.Add(book);
                }
            }
            return books;
        }
    }
}