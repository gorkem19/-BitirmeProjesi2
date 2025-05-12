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
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace Bitirme_Projesi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bitirmeprojesi2;Uid=root;Pwd=123456");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from personel where personel_kullaniciad=@p1 and personel_sifre=@p2", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

              
                con.Close();
                Form2 anaForm = new Form2();
                anaForm.Show();
                this.Hide();

            }
            else
            {
                con.Close();
                MessageBox.Show("giris basarısız");
            }
;
        }
    }
}
