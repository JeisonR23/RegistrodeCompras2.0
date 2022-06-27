using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ComprasDetalle
    {
        [Key]
        public int CompraDetalleId { get; set; }

        public int CompraId { get; set; }

        public int ProductoId { get; set; }

        [NotMapped]
        public string Descripcion { get; set; }
        
        public double Cantidad { get; set; }
        public double Costo { get; set; }

        [NotMapped]
        public double Importe { 
            get { return Cantidad * Costo; }
        }
        
        public override string? ToString()
        {
            return $"Detalle # {CompraDetalleId}, ProductoId= {ProductoId} , cantidad={Cantidad} ";
        }
    }