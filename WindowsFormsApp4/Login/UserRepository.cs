using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Login
{
    public class UserRepository
    {
        string connectionString = Conexion.cadena;

        public static void InsertUser(User usuario)
        {
            //insertar usuario en la base de datos con userName password y imagen

            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("insert into usuarios values (@userName, @password, @image);", conexion);
            comando.Parameters.AddWithValue("@userName", usuario.UserName);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.ExecuteNonQuery();
            conexion.Close();





        }

        public static bool ValidateUser(User usuario)
        {
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM usuarios WHERE userName = @userName AND password = @password", conexion);
            comando.Parameters.AddWithValue("@userName", usuario.UserName);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            SqlDataReader reader = comando.ExecuteReader();
            bool result = reader.HasRows;
            conexion.Close();
            return result;


        }

        public static void DeleteUser(User usuario)
        {
            //borrar usuario seleccionado en dataGridView
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("DELETE FROM usuarios WHERE userName = @userName", conexion);
            comando.Parameters.AddWithValue("@userName", usuario.UserName);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public static void UpdateUser(User usuario)
        {
            //actualizar usuario seleccionado en dataGridView
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("UPDATE usuarios SET password = @password WHERE userName = @userName", conexion);
            comando.Parameters.AddWithValue("@userName", usuario.UserName);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<User> GetAllUsers()
        {
            //traer todos los usuarios de la base de datos
            List<User> users = new List<User>();
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM usuarios", conexion);
            SqlDataReader reader = comando.ExecuteReader();

            //traer todos los datos de reader y guardarlos en la lista de usuarios
            while (reader.Read())
            {
                User user = new User();
                user.UserName = reader["userName"].ToString();
                user.Password = reader["password"].ToString();                users.Add(user);
            }

            conexion.Close();
            return users;
        }

        public static User GetUserbyUsername(string userName)
        {
            //traer usuario por nombre de usuario
            User user = new User();
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM usuarios WHERE userName = @userName", conexion);
            comando.Parameters.AddWithValue("@userName", userName);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                user.UserName = reader["userName"].ToString();
                user.Password = reader["password"].ToString();
            }
            conexion.Close();
            return user;


        }



    }
}
