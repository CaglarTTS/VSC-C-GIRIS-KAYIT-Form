using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
// CAGLAR TASPINAR YAZILIM ODEVI KAYIT/GIRIS
namespace LOGİN_REGİSTER_CAGLAR_Taspinar
{
    public partial class Form1 : Form
    {

        public static SqlConnection connection=new SqlConnection("Data Source=CAGLAR\\MSSQLSERVER01; Initial Catalog=Test; Integrated Security=TRUE");


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        private int mouse_x;
        private int mouse_y;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
            
            
            

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text=="Kullanıcı İsmi")
            {
                textBox1.Text = ""; 
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox1.Text = "Kullanıcı İsmi";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text=="Sifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '#';
            }
        }
        char? none = null; 
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                textBox2.Text = "Sifre";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Kullanıcı_İsmi = textBox1.Text;
            string Sifre=textBox2.Text;
            bool isthere=false;
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Deneme", connection);
            SqlDataReader reader=command.ExecuteReader();

            while (reader.Read())
            {
                if (Kullanıcı_İsmi == cryptologi.Decryption(reader["Kullanıcı_Ismi"].ToString().TrimEnd(), 2) && Sifre == cryptologi.Decryption(reader["Sifre"].ToString().TrimEnd(), 2)) 
                {
                    isthere = true;
                    break;
                }
                else
                {
                    isthere= false;
                }

            }

            connection.Close();

            if (isthere)
            {
                MessageBox.Show("GİRİS BASARILI !", "Program");
            }

            else
            {
                MessageBox.Show("Sifre yada kullanıcı adı yanlıs", "program");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2=new Form2();
            form2.Show();
        }
    }
}
