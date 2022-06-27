using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Compras
{
    [Key]
    public int CompraId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string SuplidorNombre {get;set;}

    [ForeignKey("CompraId")]
    public List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();

    public double Total { get; set; }
    public double TotalCompras { get {return Total + Total;}
     }

    public override string? ToString()
    {
        return $"Compra: Id={CompraId}, Fecha={Fecha}, Total={Total}, TotalCompras = {TotalCompras}";
    }
}