namespace netsysacad.Models {
    public class Especialidad {
        public required string Nombre { get; set;}
        public required string Letra { get; set;}
        public required string Observacion { get; set;}
        public required TipoEspecialidad TipoEspecialidad { get; set;}
    }
}