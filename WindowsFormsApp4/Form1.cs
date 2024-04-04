using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Login;



namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM usuarios", conexion);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            //llenar el datagridview
            DataTable tabla = new DataTable();
           da.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conexion.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion.cadena);
            conexion.Open();
            SqlCommand comando = new SqlCommand("insert into usuarios values (@userName, @password);", conexion);
            comando.Parameters.AddWithValue("@userName", textBox1.Text);
            comando.Parameters.AddWithValue("@password", textBox2.Text);
            comando.ExecuteNonQuery();
            conexion.Close();

            Form1_Load(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

        }
    }
}
