using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace netsysacad.Models {
    public class Materia {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(10)")]
        public required string Codigo { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Observacion { get; set;}
    }
}