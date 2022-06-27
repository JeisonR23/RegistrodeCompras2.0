using Microsoft.EntityFrameworkCore;

public class ComprasBLL
{
    private Contexto _contexto;
    public ComprasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }


    public bool Guardar(Compras compra)
    {

        _contexto.Compras.Add(compra);

        foreach (var item in compra.Detalle)
        {
            var producto = _contexto.Productos.Find(item.ProductoId);

            producto.Existencia += item.Cantidad;

        }

        var insertados = _contexto.SaveChanges();

        return insertados > 0;
    }


    public List<Compras> Buscar(DateTime fecha, DateTime fecha2)
    {

        var fechas = _contexto.Compras
         .Where(f => f.Fecha.Date == fecha.Date || f.Fecha.Date == fecha2.Date)
         .AsNoTracking().ToList();
        return fechas;
    }

    public bool Eliminar(int idCompra)
    {
        bool elimina = false;
        var eliminado = _contexto.Compras.Find(idCompra);
        _contexto.Entry(eliminado).State=EntityState.Deleted;
        elimina =(_contexto.SaveChanges() > 0);
        return elimina;
    }


    public Compras BuscarP(int idCompras)
    {
        var compra = _contexto.Compras.Include(x => x.Detalle)
            .Where(c => c.CompraId == idCompras)
            .AsNoTracking().SingleOrDefault();

        return compra;
    }



}
