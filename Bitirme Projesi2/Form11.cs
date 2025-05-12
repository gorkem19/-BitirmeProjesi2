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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        public void listele()
        {
            con.Open();
            string query = "SELECT * FROM kitap_kayit";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bitirmeprojesi2;Uid=root;Pwd=123456");
        private void Form11_Load(object sender, EventArgs e)
        {
            listele();
            listelee();
        }
        public void listelee()
        {
            con.Open();
            string query = "SELECT * FROM kitap";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM kitap WHERE kitap_ad = @ad";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                dataGridView2.DataSource = dt;
                string kitap_id = dt.Rows[0]["kitap_id"].ToString();
                label5.Text = kitap_id;
            }
            else
            {
                MessageBox.Show("Aradığınız isimde kitap bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView2.DataSource = null;
                label5.Text = ""; // veya "Yok" yazılabilir
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT kullanici_id ,kullanici_ad, kullanici_soyad FROM kullanici WHERE kullanici_tc = @tc";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                string ad = dt.Rows[0]["kullanici_ad"].ToString();
                string soyad = dt.Rows[0]["kullanici_soyad"].ToString();
                string kullanici_id = dt.Rows[0]["kullanici_id"].ToString();
                label3.Text = ad + " " + soyad;
                label4.Text = kullanici_id;
            }
            else
            {
                label3.Text = "Kullanıcı bulunamadı.";
            }

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            // kitap_id'yi önce al
            var kitap_id = dataGridView1.Rows[0].Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(kitap_id))
            {
                MessageBox.Show("Kitap seçilmedi!");
                con.Close();
                return;
            }

            string query = "INSERT INTO kitap_kayit (kullanici_id, kitap_id, alis_tarih, son_tarih, durum) " +
                           "VALUES (@kullaniciid, @kitapid, @alistarih, @sontarih, @durum)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@kullaniciid", label4.Text);
            cmd.Parameters.AddWithValue("@kitapid", label5.Text);
            cmd.Parameters.AddWithValue("@alistarih", DateTime.Today);
            cmd.Parameters.AddWithValue("@sontarih", DateTime.Today.AddDays(15));
            cmd.Parameters.AddWithValue("@durum", 0);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Kitap başarıyla verildi.");
            con.Close();
            listele();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
