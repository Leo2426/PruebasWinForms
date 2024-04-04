using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (UserRepository.ValidateUser(textBox1.Text, textBox2.Text))
            //{
            //    MessageBox.Show("Usuario correcto");
            //}
            //else
            //{
            //    MessageBox.Show("Usuario incorrecto");
            //}
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = UserRepository.GetAllUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //agegar imagen y guardar en base de datos username , password y imagen de pictureBox
            MemoryStream ms = new MemoryStream();
            UserRepository.InsertUser(new User() { UserName = textBox1.Text, Password = textBox2.Text});
            LoginForm_Load(sender, e);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //actulizar usuario seleccionado en dataGridView
            UserRepository.UpdateUser(new User() { UserName = textBox1.Text, Password = textBox2.Text });
            LoginForm_Load(sender, e);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            User user = UserRepository.GetUserbyUsername(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = user.UserName;
            textBox2.Text = user.Password;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cargar imagen en pictureBox
   


        }
    }
}
    