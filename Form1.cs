using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ders15_SiteEmlakKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="siteadmin" && textBox2.Text=="12345")
            {
                Form2 emlakKayit = new Form2();
                emlakKayit.Show();
                this.Hide();
            }
        }
    }
}
