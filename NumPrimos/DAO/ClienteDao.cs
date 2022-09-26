using MySql.Data.MySqlClient;
using NumPrimos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumPrimos.DAO
{
    internal class ClienteDao
    {
        public MySqlConnection Conectar()
        {
            string servidor = "127.0.0.1";
            string usuario = "user";
            string password = "password";
            string dataBase = "database";
            

            string cadenaConexion = "Database=" + dataBase + "; Data Source="
                + servidor + "; User Id=" + usuario + "; Password=" + password ;

            MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
            conexionDB.Open();
            
            return conexionDB;

        }
        
        public List<Cliente> ObtenerlistadoClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM database.clientes;";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();

            MySqlDataReader lectura = comando.ExecuteReader();
            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString("id");
                cliente.Nombre  = lectura.GetString("nombre");
                cliente.Apellido = lectura.GetString("apellido");
                cliente.Telefono = lectura.GetString("telefono");
                cliente.TarjetaCredito = lectura.GetString("tarjeta_de_credito");
                lista.Add(cliente);

            }
            comando.Connection.Close();

            return lista;
        }
        
        public void Guardar(Cliente cliente)
        {
            if (cliente.Id == null)
            {
                insert(cliente);
            }else
            {
                update(cliente);
            }
        }
        
        private void insert(Cliente cliente)
        {
            string consulta = "INSERT INTO `database`.`clientes` (`nombre`, `apellido`, `telefono`, `tarjeta_de_credito`) VALUES ('" +
                cliente.Nombre + "', '" + cliente.Apellido + "', '" + cliente.Telefono + "', '" + cliente.TarjetaCredito + "');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();



            comando.Connection.Close();
        }

        private void update(Cliente cliente)
        {
            string consulta = "UPDATE `database`.`clientes` SET `nombre` = '"+cliente.Nombre+"', `apellido` = '"+
                cliente.Apellido+"', `telefono` = '"+cliente.Telefono+"', `tarjeta_de_credito` = '"+cliente.TarjetaCredito+"' WHERE (`id` = '"+cliente.Id+"');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();



            comando.Connection.Close();
        }

        internal void Eliminar(Cliente cliente)
        {
            //DELETE FROM `database`.`clientes` WHERE (`id` = '5');
            string consulta = "DELETE FROM `database`.`clientes` WHERE (`id` = '"+ cliente.Id+"');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

        }
    }
}
