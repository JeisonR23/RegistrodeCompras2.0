using System.ComponentModel.DataAnnotations;

public class Categorias
{
        [Key]
        public int CategoriaId { get; set; }
        public String? Descripcion { get; set; }
    
}