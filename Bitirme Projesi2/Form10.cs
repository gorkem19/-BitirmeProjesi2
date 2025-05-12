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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); 
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
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
        private void Form10_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kitap_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();

            string query = @"UPDATE kitap 
                 SET kitap_ad = @ad, 
                     kitap_yazar = @yazar, 
                     kitap_yayinci = @yayinci, 
                     kitap_sayfasayisi = @sayfasayisi, 
                     kitap_basimtarihi = @basimtarihi
                 WHERE kitap_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text); 
            cmd.Parameters.AddWithValue("@yazar", textBox2.Text); 
            cmd.Parameters.AddWithValue("@yayinci", textBox3.Text);
            cmd.Parameters.AddWithValue("@sayfasayisi", Convert.ToInt32(textBox4.Text)); 
            cmd.Parameters.AddWithValue("@basimtarihi", dateTimePicker1.Value); 
            cmd.Parameters.AddWithValue("@id", kitap_id); 
            int result = cmd.ExecuteNonQuery();
            con.Close();
            listele();
        }
    }
}
