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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            listele();
        }
        public void listele()
        {
            con.Open();
            string query = "SELECT * FROM kitap_kayit where durum = 0";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bitirmeprojesi2;Uid=root;Pwd=123456");

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
                con.Open();
                string query = @"UPDATE kitap_kayit
                     SET durum = true
                     WHERE kayit_id = @id"; 
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                listele();
            
        }
    }
}
