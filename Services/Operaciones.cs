using InventarioNet6.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Linq;
namespace InventarioNet6.Services
{
    public class Operaciones : IOperaciones
    {
        private readonly IConfiguration _config;

        public Operaciones(IConfiguration config)
        {
            this._config = config;
        }
        public Productos GetProductoById(int id)
        {
            Productos p = new Productos();
            using (MySqlConnection db = new MySqlConnection(_config.GetConnectionString("DbMySql")))
            {
                string sql = $"select * from Productos where Id = {id}";
                p = db.QueryFirstOrDefault<Productos>(sql);
                return p;
            }
        }

        public List<Productos> GetProductos()
        {
            using (MySqlConnection db = new MySqlConnection(_config.GetConnectionString("DbMySql")))
            {
                string sql = "Select Nombre, Precio, Stock, Id_Categoria from Productos";
                List<Productos> productos = db.Query<Productos>(sql).ToList();
                return productos;
            }
        }

        public void AddProducto(Productos producto)
        {
            using (MySqlConnection db = new MySqlConnection(_config.GetConnectionString("DbMySql")))
            {
                string sql = "insert into Productos (Nombre, Precio, Stock, Id_Categoria) " +
                             "values (@nombre, @precio, @stock, @id_categoria)";
                var resultado = db.Execute(sql, producto);
            }
        }
    }
}