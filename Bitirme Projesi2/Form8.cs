using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bitirme_Projesi2
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public void listele()
        {
            con.Open();
            string query = "SELECT * FROM kitap";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bitirmeprojesi2;Uid=root;Pwd=123456");
        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string query = "INSERT INTO kitap (kitap_ad, kitap_yazar, kitap_yayinci, kitap_sayfasayisi, kitap_basimtarihi) " +
                 "VALUES (@ad, @yazar, @yayinci, @sayfasayisi, @basimtarihi)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);              
            cmd.Parameters.AddWithValue("@yazar", textBox2.Text);          
            cmd.Parameters.AddWithValue("@yayinci", textBox3.Text);        
            cmd.Parameters.AddWithValue("@sayfasayisi", Convert.ToInt32(textBox4.Text)); 
            cmd.Parameters.AddWithValue("@basimtarihi", dateTimePicker1.Value);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Kitap başarıyla eklendi.");
            con.Close();
            listele();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
