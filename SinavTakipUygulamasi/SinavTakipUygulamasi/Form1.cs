using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SinavTakipUygulamasi
{
    public partial class Form1 : Form
    {
        private List<Sinav> sinavListesi = new List<Sinav>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dersAdi = textBox1.Text;
            DateTime sinavTarihi;

            // Tarih doğrulaması
            if (DateTime.TryParse(textBox2.Text, out sinavTarihi))
            {
                // Listeye sınav ekleme
                sinavListesi.Add(new Sinav(dersAdi, sinavTarihi));
                // Listeyi güncelleme
                listBox1.Items.Add($"{dersAdi} - {sinavTarihi:dd/MM/yyyy}");
                // TextBoxları temizleme
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tarih girin! (gg.aa.yyyy)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Now;
            var yaklasanSinavlar = sinavListesi.Where(s => s.Tarih >= bugun).OrderBy(s => s.Tarih).ToList();

            if (yaklasanSinavlar.Any())
            {
                string mesaj = "Yaklaşan Sınavlar:\n";
                foreach (var sinav in yaklasanSinavlar)
                {
                    mesaj += $"{sinav.DersAdi} - {sinav.Tarih:dd/MM/yyyy}\n";
                }
                MessageBox.Show(mesaj, "Yaklaşan Sınavlar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yaklaşan sınav yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class Sinav
    {
        public string DersAdi { get; set; }
        public DateTime Tarih { get; set; }

        public Sinav(string dersAdi, DateTime tarih)
        {
            DersAdi = dersAdi;
            Tarih = tarih;
        }
    }
}
