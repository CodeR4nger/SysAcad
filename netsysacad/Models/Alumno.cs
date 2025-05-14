using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netsysacad.Models {
    public class Alumno {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Apellido { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(15)")]
        public required string NroDocumento { get; set;}
        [Column(TypeName = "varchar(50)")]
        public required TipoDocumento TipoDocumento { get; set;}
        [Column(TypeName = "varchar(50)")]
        public required string FechaNacimiento { get; set;}
        [Column(TypeName = "varchar(5)")]
        public required string Sexo { get; set;}
        [Column(TypeName = "int")]
        public required int NroLegajo { get; set;}
        [Column(TypeName = "date")]
        public required DateTime FechaIngreso { get; set;}
    }
}