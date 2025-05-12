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
    public partial class Form5 : Form
    {
        public Form5()
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
            try
            {
                con.Open();


                MySqlCommand cmd = new MySqlCommand("DELETE FROM kullanici WHERE kullanici_id=@p1", con);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);


                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {

                    MessageBox.Show("kullanicisilindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("kullanicibulunamadi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();

                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listele();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
