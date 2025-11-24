using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        double ilkSayi = 0;
        string islem = "";
        bool yeniGiris = true;

        private void Rakam_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (yeniGiris || textBoxResult.Text == "0")
            {
                textBoxResult.Text = btn.Text;
                yeniGiris = false;
            }
            else
            {
                textBoxResult.Text += btn.Text;
            }
        }

        private void Islem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                ilkSayi = Convert.ToDouble(textBoxResult.Text);
                islem = btn.Text;
                yeniGiris = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçersiz sayı girdisi!\n" + ex.Message);
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double ikinciSayi = 0;
            double sonuc = 0;
            try
            {
                ikinciSayi = Convert.ToDouble(textBoxResult.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçersiz sayı girdisi!\n" + ex.Message);
                return;
            }

            switch (islem)
            {
                case "+":
                    sonuc = ilkSayi + ikinciSayi;
                    break;
                case "−":
                    sonuc = ilkSayi - ikinciSayi;
                    break;
                case "×":
                    sonuc = ilkSayi * ikinciSayi;
                    break;
                case "÷":
                    if (ikinciSayi != 0)
                        sonuc = ilkSayi / ikinciSayi;
                    else
                    {
                        MessageBox.Show("Sıfıra bölme hatası!");
                        sonuc = 0;
                    }
                    break;
            }

            textBoxResult.Text = sonuc.ToString();
            yeniGiris = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            ilkSayi = 0;
            islem = "";
            yeniGiris = true;
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            double sayi = 0;
            try
            {
                sayi = Convert.ToDouble(textBoxResult.Text);
                if (sayi < 0)
                {
                    MessageBox.Show("Negatif sayının karekökü alınamaz!");
                    return;
                }
                double sonuc = Math.Sqrt(sayi);
                textBoxResult.Text = sonuc.ToString();
                yeniGiris = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçersiz sayı girdisi!\n" + ex.Message);
            }
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            double taban = 0;
            try
            {
                taban = Convert.ToDouble(textBoxResult.Text);
                string input = Microsoft.VisualBasic.Interaction.InputBox("Üssü giriniz:", "Üst Alma", "2");
                if (string.IsNullOrWhiteSpace(input)) return;
                double us = Convert.ToDouble(input);
                double sonuc = Math.Pow(taban, us);
                textBoxResult.Text = sonuc.ToString();
                yeniGiris = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçersiz sayı girdisi!\n" + ex.Message);
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            double sayi = 0;
            try
            {
                sayi = Convert.ToDouble(textBoxResult.Text);
                if (sayi <= 0)
                {
                    MessageBox.Show("Logaritma için sayı pozitif olmalı!");
                    return;
                }
                double sonuc = Math.Log10(sayi);
                textBoxResult.Text = sonuc.ToString();
                yeniGiris = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçersiz sayı girdisi!\n" + ex.Message);
            }
        }
    }
}
