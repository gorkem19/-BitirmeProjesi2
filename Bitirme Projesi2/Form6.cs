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
    public partial class Form6 : Form
    {
        public Form6()
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
        private void Form6_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kullanici_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            con.Open();
            string query = @"UPDATE kullanici 
                SET kullanici_ad = @ad, 
                    kullanici_soyad = @soyad, 
                    kullanici_tc = @tc, 
                    kullanici_mail = @mail, 
                    kullanici_tel = @tel, 
                    kullanici_ceza = @ceza
                WHERE kullanici_id = @id";  // DÜZELTİLDİ

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@tc", textBox3.Text);
            cmd.Parameters.AddWithValue("@mail", textBox4.Text);
            cmd.Parameters.AddWithValue("@tel", textBox5.Text);
            cmd.Parameters.AddWithValue("@ceza", textBox6.Text);
            cmd.Parameters.AddWithValue("@id", kullanici_id);  // KULLANILDI

            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0)
                MessageBox.Show("Kullanıcı başarıyla güncellendi.");
            else
                MessageBox.Show("Güncelleme başarısız.");

            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value).ToString();


        }
    }
}
