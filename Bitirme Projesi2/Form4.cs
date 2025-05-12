using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitirme_Projesi2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bitirmeprojesi2;Uid=root;Pwd=123456");
        public void listele()
        {
            con.Open();
            string query = "SELECT * FROM kullanici";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string query = "INSERT INTO kullanici (kullanici_ad, kullanici_soyad, kullanici_tc, kullanici_mail, kullanici_tel, kullanici_ceza) " +
                           "VALUES (@ad, @soyad, @tc, @mail, @tel, @ceza)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@tc", textBox3.Text);
            cmd.Parameters.AddWithValue("@mail", textBox4.Text);
            cmd.Parameters.AddWithValue("@tel", textBox5.Text);
            cmd.Parameters.AddWithValue("@ceza", float.Parse(textBox6.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Kullanıcı başarıyla eklendi.");
            con.Close();
            listele();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
