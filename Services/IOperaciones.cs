using InventarioNet6.Models;

namespace InventarioNet6.Services{
    public interface IOperaciones{
         public Productos GetProductoById(int id);
        public List<Productos> GetProductos();
        public void AddProducto(Productos producto);
    }
}