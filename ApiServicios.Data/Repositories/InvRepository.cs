using ApiServicios.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServicios.Data.Repositories
{
    public class InvRepository : InveRepositories
    {
        private readonly MySqlConfiguration _connectionString;

        public InvRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteInve(Inve inve)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM inventario WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new {Id = inve.Id});

            return result > 0;
        }

        public  async Task<IEnumerable<Inve>> GetAllInv()
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, tipo, cantidad, fechar, fechae, bodega, precio, descuento, placa, guia
                         FROM inventario ";

            return await db.QueryAsync<Inve>(sql, new {});
        }

        public  async Task<Inve> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, tipo, cantidad, fechar, fechae, bodega, precio, descuento, placa, guia
                         FROM inventario 
                         WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Inve>(sql, new { Id = id});
        }

        public async Task<bool> InsetInve(Inve inve)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO inventario(nombre, tipo, cantidad, fechar, fechae, bodega, precio, descuento, placa, guia)
                         VALUES(@Nombre, @Tipo, @Cantidad, @Fechar, @Fechae, @Bodega, @Precio, @Descuento, @Placa, @Guia)"; 

            var result = await db.ExecuteAsync(sql, new 
            { inve.Nombre, inve.Tipo, inve.Cantidad, inve.FechaR, inve.FechaE, inve.Bodega, inve.Precio, inve.Descuento, inve.Placa, inve.Guia });

            return result > 0;
        }

        public async Task<bool> UpdateInve(Inve inve)
        {
            var db = dbConnection();

            var sql = @" UPDATE inventario
                         SET nombre = @Nombre, 
                             tipo = @Tipo, 
                             cantidad = @Cantidad, 
                             fechar = Fechar, 
                             fechae = @Fehcae, 
                             bodega = @Bodega, 
                             precio = @Precio, 
                             descuento = @Descuento, 
                             placa = @Placa, 
                             guia = @Guia
                             WHERE id = @Id";
                         

            var result = await db.ExecuteAsync(sql, new
            { inve.Nombre, inve.Tipo, inve.Cantidad, inve.FechaR, inve.FechaE, inve.Bodega, inve.Precio, inve.Descuento, inve.Placa, inve.Guia, inve.Id });

            return result > 0;
        }
    }
}
