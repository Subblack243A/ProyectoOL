using ProyectoOL.Dtos;
using ProyectoOL.Repositories;

namespace ProyectoOL.Services
{
    public class BooksService
    {
        public BookDto CreateBook(BookDto book)
        {
            BookRepository bookRepository = new BookRepository();
            int res = bookRepository.CreateBook(book);
            if (res == 0)
            {
                book.Indice = 1;
                return book;
            }
            else
            {
                return Clean(book);
            }
        }

        public BookDto Clean(BookDto book)
        {
            book.Id_Libro = 0;
            book.Nombre_Libro = null;
            book.Fk_Genero = 0;
            book.Autor = null;
            book.Fk_Estado = 0;
            book.Imagen = null;
            book.Pdf = null;
            book.Indice = 0;
            return book;
        }
    }
}