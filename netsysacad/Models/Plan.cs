using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace netsysacad.Models {
    public class Plan {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(20)")]
        public required string FechaInicio { get; set;}
        [Column(TypeName ="varchar(20)")]
        public required string FechaFin { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Observacion { get; set;}
    }
}