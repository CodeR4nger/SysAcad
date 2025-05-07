namespace netsysacad.Models {
    public class Alumno {
        public required string Apellido { get; set;}
        public required string Nombre { get; set;}
        public required string NroDocumento { get; set;}
        public required TipoDocumento TipoDocumento { get; set;}
        public required string FechaNacimiento { get; set;}
        public required string Sexo { get; set;}
        public required int NroLegajo { get; set;}
        public required DateTime FechaIngreso { get; set;}
    }
}