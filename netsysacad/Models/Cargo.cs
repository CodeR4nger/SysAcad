namespace netsysacad.Models {
    public class Cargo {
        public required string Nombre { get; set;}
        public required int Puntos { get; set;}
        public required CategoriaCargo CategoriaCargo{ get; set;}
        public required TipoDedicacion TipoDedicacion{ get; set;}
    }
}