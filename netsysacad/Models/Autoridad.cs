using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netsysacad.Models {
    public class Autoridad {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        public int CargoId { get; set; }
        [ForeignKey("CargoId")]
        public required Cargo Cargo { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Telefono { get; set;}
        [Column(TypeName ="varchar(100)")]
        public required string Email { get; set;}
        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public required Facultad Facultad { get; set; }
    }
}