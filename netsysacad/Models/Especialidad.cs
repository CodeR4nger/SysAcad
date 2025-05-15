using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace netsysacad.Models {
    public class Especialidad {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(3)")]
        public required string Letra { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Observacion { get; set;}
        public int TipoEspecialidadId { get; set; }
        [ForeignKey("TipoEspecialidadId")]
        public required TipoEspecialidad TipoEspecialidad { get; set;}
    }
}