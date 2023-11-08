
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoOL.Dtos
{
    public class BookDto
    {
        public int Id_Libro { get; set; }

        public string Nombre_Libro { get; set; } = string.Empty;

        public string Autor { get; set;} = string.Empty;

        public DateTime Fecha {  get; set;}

        public short Fk_Genero {  get; set; }

        public short Fk_Estado { get; set; }

        public string Imagen { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public int Indice {  get; set; }
    }
}