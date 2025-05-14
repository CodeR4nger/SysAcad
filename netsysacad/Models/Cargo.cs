using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netsysacad.Models {
    public class Cargo {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public required string Nombre { get; set;}
        [Column(TypeName ="integer")]
        public required int Puntos { get; set;}
        public int CategoriaCargoId { get; set; }
        [ForeignKey("CategoriaCargoId")]
        public required CategoriaCargo CategoriaCargo{ get; set;}
        public int TipoDedicacionId { get; set; }
        [ForeignKey("TipoDedicacionId")]
        public required TipoDedicacion TipoDedicacion{ get; set;}
    }
}