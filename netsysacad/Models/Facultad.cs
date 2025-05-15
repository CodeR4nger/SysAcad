using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace netsysacad.Models {
    public class Facultad {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="varchar(20)")]
        public required string Abreviatura { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Directorio { get; set;}
        [Column(TypeName ="varchar(10)")]
        public required string Sigla { get; set;}
        [Column(TypeName ="varchar(10)")]
        public required string CodigoPostal { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Ciudad { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Domicilio { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Telefono { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Contacto { get; set;}
        [Column(TypeName ="varchar(50)")]
        public required string Email { get; set;}
        public int UniversidadId { get; set; }
        [ForeignKey("UniversidadId")]
        public required Universidad Universidad { get; set;}
    }
}