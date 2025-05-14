using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netsysacad.Models {
    public class Autoridad {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Cargo { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Telefono { get; set;}
        [Column(TypeName ="varchar(100)")]
        public required string Email { get; set;}
    }
}