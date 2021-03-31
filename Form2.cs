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

namespace Ders15_SiteEmlakKayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DELLG5-5505;Initial Catalog=Siteler;Integrated Security=True");
        private void VerileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from SiteBilgi",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Site"].ToString());
                ekle.SubItems.Add(oku["Oda"].ToString());
                ekle.SubItems.Add(oku["Metre"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["No"].ToString());
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Notlar"].ToString());
                ekle.SubItems.Add(oku["SatKira"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSite.Text=="Zambak Sitesi")
            {
                btnZambak.BackColor = Color.Yellow;
                btnGul.BackColor = Color.Gray;
                btnMenekse.BackColor = Color.Gray;
                btnPapatya.BackColor = Color.Gray;
            }
            if(cmbSite.Text=="Papatya Sitesi")
            {
                btnZambak.BackColor = Color.Gray;
                btnGul.BackColor = Color.Gray;
                btnMenekse.BackColor = Color.Gray;
                btnPapatya.BackColor = Color.Yellow;
            }
            if(cmbSite.Text=="Gül Sitesi")
            {
                btnZambak.BackColor = Color.Gray;
                btnGul.BackColor = Color.Yellow;
                btnMenekse.BackColor = Color.Gray;
                btnPapatya.BackColor = Color.Gray;
            }
            if(cmbSite.Text=="Menekşe Sitesi")
            {
                btnZambak.BackColor = Color.Gray;
                btnGul.BackColor = Color.Gray;
                btnMenekse.BackColor = Color.Yellow;
                btnPapatya.BackColor = Color.Gray;
            }
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into SiteBilgi(Id, Site, Oda, Metre, Fiyat, Blok, No, AdSoyad, Telefon, Notlar, SatKira) values('" + txtId.Text.ToString() + "','" + cmbSite.Text.ToString() + "','" + cmbOdaSayisi.Text.ToString() + "','" + txtMetreKare.Text.ToString() + "','" + txtFiyat.Text.ToString() + "','" + cmbBlok.Text.ToString() + "','" + txtNo.Text.ToString() + "','" + txtAdSoyad.Text.ToString() + "','" + txtTelefon.Text.ToString() + "','" + txtNotlar.Text.ToString() + "','" + cmbSatKira.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        int id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from SiteBilgi where Id='" + id + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            //Id Site Oda Metre Fiyat Blok No AdSoyad Telefon Notlar SatKira
            txtId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cmbSite.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cmbOdaSayisi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtMetreKare.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtFiyat.Text = listView1.SelectedItems[0].SubItems[4].Text;
            cmbBlok.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtAdSoyad.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtTelefon.Text = listView1.SelectedItems[0].SubItems[8].Text;
            txtNotlar.Text = listView1.SelectedItems[0].SubItems[9].Text;
            cmbSatKira.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update SiteBilgi set Id='" + txtId.Text.ToString() + "',Site='" + cmbSite.Text.ToString() + "',Oda='" + cmbOdaSayisi.Text.ToString() + "',Metre='" + txtMetreKare.Text.ToString() + "',Fiyat='" + txtFiyat.Text.ToString() + "',Blok='" + cmbBlok.Text.ToString() + "',No='" + txtNo.Text.ToString() + "',AdSoyad='" + txtAdSoyad.Text.ToString() + "',Telefon='" + txtTelefon.Text.ToString() + "',Notlar='" + txtNotlar.Text.ToString() + "',SatKira='" + cmbSatKira.Text.ToString() + "' where Id='" + id.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }
    }
}
