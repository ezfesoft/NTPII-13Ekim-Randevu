using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTP_II_12Ekim_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _saat = "";
            int _tc ;
            string _ad = "";
            string _soyad = "";
            
            _saat = listBox1.SelectedItem.ToString();
            _tc = Int32.Parse(textBox1TC.Text);
            _ad = textBox1Ad.Text;
            _soyad = textBox1Soyad.Text;

            int _seciliIndexNo;
            _seciliIndexNo = listBox1.SelectedIndex;

            string _TekSatir;



            bool _kayitDurumu = false;
            string[] dizi;
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                dizi = listBox3.Items[i].ToString().Split(';');
                if (_tc.ToString() == dizi[0])
                {
                    _kayitDurumu = true;
                    MessageBox.Show("Zaten Kayıt Yapıldı!");
                    textBox1TC.Text = "";
                    textBox1Ad.Text = "";
                    textBox1Soyad.Text="";
                    listBox1.SelectedIndex = 0;
                }
            }
            if (_kayitDurumu==false)
            {
                if (_tc % 2 == 0 && _tc.ToString().Length > 3)
                {
                    if (_ad.Length >= 2)
                    {
                        if (_soyad.Length >= 2)
                        {
                            _TekSatir = _tc + ";" + _ad + ";" + _soyad + ";" + _saat;
                            listBox3.Items.Add(_TekSatir);
                            listBox1.Items.RemoveAt(_seciliIndexNo);
                            textBox1TC.Text = "";
                            textBox1Ad.Text = "";
                            textBox1Soyad.Text = "";
                            listBox1.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli TC Giriniz!");

                    textBox1TC.Text = "";
                    textBox1Ad.Text = "";
                    textBox1Soyad.Text = "";
                    listBox1.SelectedIndex = 0;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _list3sayi = listBox3.Items.Count;
            string[] dizi;
            for (int i = 0; i < _list3sayi; i++)
            {
                dizi = listBox3.Items[i].ToString().Split(';');
                listBox2.Items.Add(dizi[3]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _list2Index = listBox2.SelectedIndex;

            string[] dizi;
            dizi = listBox3.Items[_list2Index].ToString().Split(';');

            textBox2TC.Text = dizi[0];
            textBox2Ad.Text = dizi[1];
            textBox2Soyad.Text = dizi[2];
            textBox2Saat.Text = dizi[3];

        }
    }
}
