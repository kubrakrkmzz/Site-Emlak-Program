using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Site_Emlak_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text=="admin" && textBox2.Text == "12345")
            {
                MessageBox.Show("Giriş Başarılı");
                Form2 emlakkayit = new Form2();
                emlakkayit.Show();
                this.Hide();
              
            }
            else
            {
                MessageBox.Show("Hatalı giriş lütfen tekrar deneyin");

            }

        }
    }
}
