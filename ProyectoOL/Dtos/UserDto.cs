
namespace ProyectoOL.Dto
{
    public class UserDto
    {
        public int Id_Usuario {  get; set; }
        
        public string Nombre_Usuario { get; set; } = string.Empty;

        public short Tipo_Documento { get; set;}

        public short Tipo_Usuario { get; set;}

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Correo_Electronico { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;

        public string Message {  get; set; } = string.Empty;

        public int Estado { get; set; }

        public string KeySafe {  get; set; } = string.Empty;

        public string Iv { get; set;} = string.Empty;
    }
}