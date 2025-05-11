namespace netsysacad.Models {
    public class Orientacion {
        public required string Nombre { get; set;}
        public required Especialidad Especialidad { get; set;}
        public required Plan Plan { get; set;}
        public required List<Materia> Materias { get; set;}
    }
}