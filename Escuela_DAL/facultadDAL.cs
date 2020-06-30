using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        public DataTable cargarFacultades()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultades";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultades);

            connection.Close();

            return dtFacultades;
        }

        public void agregarfacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_agregarFacultad";
            command.Connection = connection;

            command.Parameters.AddWithValue("pCodigo", codigo);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fechaCreacion);
            command.Parameters.AddWithValue("pUniversidad", universidad);
            command.Parameters.AddWithValue("pCiudad", ciudad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public DataTable cargarFacultad(int idFacultad)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultadId"; 
            command.Connection = connection;

            command.Parameters.AddWithValue("pId", idFacultad);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultad = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultad);

            connection.Close();

            return dtFacultad;
        }

        public DataTable cargarFacultadcod(string codigo)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultadCodigo";
            command.Connection = connection;

            command.Parameters.AddWithValue("pCodigo", codigo);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultad = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultad);

            connection.Close();

            return dtFacultad;
        }

        public void modificarFacultad(int id, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_modificarFacultad";
            command.Connection = connection;

            command.Parameters.AddWithValue("pId", id);
            command.Parameters.AddWithValue("pCodigo", codigo);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fechaCreacion);
            command.Parameters.AddWithValue("pUniversidad", universidad);
            command.Parameters.AddWithValue("pCiudad", ciudad);
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void eliminarFacultad(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-1NP1QCU\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarFacultad";
            command.Connection = connection;

            command.Parameters.AddWithValue("pId", id);
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
