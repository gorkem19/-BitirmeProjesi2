using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bitirme_Projesi2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Visible == false)
            {
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            Form3 klisteform = new Form3();
            klisteform.MdiParent = this;
            klisteform.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            this.IsMdiContainer = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 kullanıcıekleform = new Form4();
            kullanıcıekleform.MdiParent = this;
            kullanıcıekleform.Show();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 kullanicisilform = new Form5();
            kullanicisilform.MdiParent = this;
            kullanicisilform.Show();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 kullaniciguncelleform = new Form6();
            kullaniciguncelleform.MdiParent = this;
            kullaniciguncelleform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 kaynakform = new Form7();
            kaynakform.MdiParent = this;
            kaynakform.Show();

            if (button8.Visible == false)
            {
                button8.Visible = true;
                button7.Visible = true;
                button6.Visible = true;
            }
            else
            {
                button8.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 kitapekleform = new Form8();
            kitapekleform.MdiParent = this;
            kitapekleform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 kitapguncelleform = new Form9();
            kitapguncelleform.MdiParent = this;
            kitapguncelleform.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.MdiParent = this;
            form10.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.MdiParent = this;
            form11.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.MdiParent = this;
            form12.Show();
        }
    }
}
