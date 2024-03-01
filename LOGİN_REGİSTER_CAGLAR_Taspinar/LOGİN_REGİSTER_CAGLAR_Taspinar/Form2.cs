using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
// CAGLAR TASPINAR YAZILIM ODEVI KAYIT/GIRIS
namespace LOGİN_REGİSTER_CAGLAR_Taspinar
{
    public partial class Form2 : Form
    {
        SqlConnection connection=Form1.connection;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı İsmi")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı İsmi";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Sifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '#';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            char? none = null;
            if (textBox2.Text == "")
            {
                textBox2.Text = "Sifre";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Re_Sifre")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
                textBox3.PasswordChar = '#';
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            char? none = null;
            if (textBox3.Text == "")
            {
                textBox3.Text = "Re_Sifre";
                textBox3.ForeColor = Color.Black;
                textBox3.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "e-mail")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "e-Mail";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Telefon No")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Telefon No";
                textBox5.ForeColor = Color.Black;
            }
        }

        bool move;
        private int mouse_x;
        private int mouse_y;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into Deneme (Kullanıcı_Ismi,Sifre,re_Sifre,e_mail,Telefon_No,active) values ('" + cryptologi.Encryption(textBox1.Text,2) + "','" + cryptologi.Encryption(textBox2.Text,2) + "','" + cryptologi.Encryption(textBox3.Text,2) + "','" + cryptologi.Encryption(textBox4.Text,2) + "','" + cryptologi.Encryption(textBox5.Text,2) + "','false')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("KAYIT BASARILI", "Program");
        }
    }
}
