using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Site_Emlak_Program
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=BERKAN;Initial Catalog=siteler2;Integrated Security=True");

        bool durum;
        void tekrar() // tekrar edeni engelleme
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From sitebilgi where id = '"+ textBox7.Text.ToString()+"'", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            baglan.Close();
        }




        private void verilerigoster()
           
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Zambak Sitesi")
            {
                BtnZambak.BackColor = Color.Yellow;
                BtnPapatya.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Gray;
            }

            if (comboBox1.Text == "Papatya Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Yellow;
                BtnMenekse.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Gray;
            }

            if (comboBox1.Text == "Gül Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Gray;
                BtnGul.BackColor = Color.Yellow;
            }

            if (comboBox1.Text == "Menekşe Sitesi")
            {
                BtnZambak.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Yellow;
                BtnGul.BackColor = Color.Gray;
            }


        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            tekrar();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) " +
                "values('" + textBox7.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" 
                + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" +
                textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoster();
            }

            else
            {
                MessageBox.Show("Bu kayıt zaten var ekleyemezsiniz.");
            }
        }
       
        int id = 0;

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from sitebilgi where id =(" +id+ ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

             id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
             textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
             comboBox1.Text= listView1.SelectedItems[0].SubItems[1].Text;
             comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
             textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
             textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
             comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
             textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
             textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
             textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
             textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;
             comboBox2.Text= listView1.SelectedItems[0].SubItems[10].Text;
           

        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id='" + textBox7.Text.ToString() + "',site='" + comboBox1.Text.ToString() + "',oda='" + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',no='" + textBox6.Text.ToString() + "',adsoyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() + "',notlar='" + textBox3.Text.ToString() + "',satkira='"+ comboBox2.Text.ToString()+"' where id =" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 sirala = new Form3();
            sirala.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
        
    }

