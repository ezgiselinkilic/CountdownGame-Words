using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirKelimeYarışma
{   
    public partial class YarısmaForm : Form
     {
        private List<Word> kelimelistdata = new List<Word>();
        public List<string> result2 = new List<string>();
        public List<string> myWords = new List<string>();
        public static ResultWords _resultWords = new ResultWords();
        string rndharfler;
        int toplampuan = 0;
        public YarısmaForm()
        {
            InitializeComponent();
        }
        int counter = 0;
        Random r = new Random();
        private void btnHarfAl_Click(object sender, EventArgs e)

        {
            counter++;
            btnHarfAl.Enabled = false;
            string[] sessizharfler = { "B", "C", "Ç", "D", "F", "G", "Ğ", "H", "J", "K", "L", "M", "N", "P", "R", "S", "Ş", "T", "V", "Y", "Z" };
            string[] sesliharfler = { "A", "I", "O", "U", "E", "İ", "Ö", "Ü" };
            string harf1, harf2, harf3, harf4, harf5, harf6, harf7, harf8, harf9;
            int harfsayi;
            if (counter == 1)
            {
                harfsayi = r.Next(0, sessizharfler.Length);
                harf1 = sessizharfler[harfsayi].ToString();
                rndharfler += harf1;
                harfbtn1.Text = harf1;
                lblharf1.Text = harfbtn1.Text;
                btnHarfAl.Enabled = true;
            }


            if (counter == 2)
            {
                harfsayi = r.Next(0, sesliharfler.Length);
                harf2 = sesliharfler[harfsayi].ToString();
                rndharfler += harf2;
                harfbtn2.Text = harf2;
                lblharf2.Text = harfbtn2.Text;
                btnHarfAl.Enabled = true;

            }

            if (counter == 3)
            {
                harfsayi = r.Next(0, sessizharfler.Length);
                harf3 = sessizharfler[harfsayi].ToString();
                rndharfler += harf3;
                harfbtn3.Text = harf3;
                lblharf3.Text = harfbtn3.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 4)
            {
                harfsayi = r.Next(0, sesliharfler.Length);
                harf4 = sesliharfler[harfsayi].ToString();
                rndharfler += harf4;
                harfbtn4.Text = harf4;
                lblharf4.Text = harfbtn4.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 5)
            {
                harfsayi = r.Next(0, sessizharfler.Length);
                harf5 = sessizharfler[harfsayi].ToString();
                rndharfler += harf5;
                harfbtn5.Text = harf5;
                lblharf5.Text = harfbtn5.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 6)
            {
                harfsayi = r.Next(0, sesliharfler.Length);
                harf6 = sesliharfler[harfsayi].ToString();
                rndharfler += harf6;
                harfbtn6.Text = harf6;
                lblharf6.Text = harfbtn6.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 7)
            {
                harfsayi = r.Next(0, sessizharfler.Length);
                harf7 =sessizharfler[harfsayi].ToString();
                rndharfler += harf7;
                harfbtn7.Text = harf7;
                lblharf7.Text = harfbtn7.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 8)
            {
                harfsayi = r.Next(0, sesliharfler.Length);
                harf8 = sesliharfler[harfsayi].ToString();
                rndharfler += harf8;
                harfbtn8.Text = harf8;
                lblharf8.Text = harfbtn8.Text;
                btnHarfAl.Enabled = true;
            }

            if (counter == 9)
            {
                harfsayi = r.Next(0, sessizharfler.Length);
                harf9 = sessizharfler[harfsayi].ToString();
                rndharfler += harf9;
                txtjokerharf.Text = harf9;
                lblharf9.Text = txtjokerharf.Text;
                btnHarfAl.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnHarfAl.Enabled = false;
            label1.Text = rndharfler;
        }
        private Task task;
        public void KelimeUret()
        {
            Random rastgele = new Random();
            string uret = "";
            bool bitti_mi;
            int sayac = 0;
            int t_gezme = 1;
            string temp_harfler;
            char harf;

            for (int i = 3; i < 9; i++)
            {
                uret = "";
                bitti_mi = false;
                sayac = 0;
                t_gezme = 1;

                for (int l = 0; l < i; l++)
                {
                    int k = 9;
                    t_gezme *= k - l;
                }
                while (bitti_mi == false)
                {
                    temp_harfler = rndharfler;
                    uret = "";
                    for (int j = 0; j < i; j++)
                    {

                        harf = temp_harfler[rastgele.Next(temp_harfler.Length)];
                        for (int k = 0; k < temp_harfler.Length; k++)
                        {
                            if (temp_harfler[k] == harf)
                            {
                                temp_harfler = temp_harfler.Remove(k, 1);
                                break;
                            }
                        }
                        uret += harf;
                    }
                    sayac++;
                    if (!myWords.Contains(uret))
                    {
                        myWords.Add(uret);
                    }
                    if (sayac == t_gezme)
                    {
                        Task.Run(() => AddWordsTest(myWords, i)).Wait();

                        myWords.Clear();
                        bitti_mi = true;
                        if (i == 8)
                        {
                            bitti_mi = false;
                            sayac = 0;
                            i++;

                        }
                        if (i == 9)
                        {

                            MessageBox.Show("Bütün kelimeler bulundu");
                        }

                    }
                }

            }
            AddList();
        }
        public void AddWordsTest(List<string> mySwords, int i)
        {
            WordProvider provider = new WordProvider();
         
                List<string> localWord = mySwords;
                if (provider.Eslesti_miTest(localWord, i).Count != 0)
                {
                    var A_words = provider.Eslesti_miTest(localWord, i);

                    _resultWords.r_word.Add(new wordss(
                       i,
                      A_words
                     ));

                    MessageBox.Show(i + " haneli " + A_words.Count + " anlamlı kelime bulundu");
                }
                else
                {
                    MessageBox.Show(i + " haneli  anlamlı kelime bulunamadı");
                }
            
            
        }

        private static readonly object _lockSync = new object();
        public void AddList()
        {

            var w = _resultWords.r_word.ToList();

            var w3 = w.Where(x => x.hane == 3).FirstOrDefault();
            if (list3harfli.Items.Count == 0 && w3 != null)
            {
                foreach (var item in w3.word)
                {
                    list3harfli.Items.Add(item);
                }
            }

            var w4 = w.Where(x => x.hane == 4).FirstOrDefault();
            if (list4harfli.Items.Count == 0 && w4 != null)
            {
                foreach (var item in w4.word)
                {
                    list4harfli.Items.Add(item);
                }
            }

            var w5 = w.Where(x => x.hane == 5).FirstOrDefault();
            if (list5harfli.Items.Count == 0 && w5 != null)
            {
                foreach (var item in w5.word)
                {
                    list5harfli.Items.Add(item);
                }
            }

            var w6 = w.Where(x => x.hane == 6).FirstOrDefault();
            if (list6harfli.Items.Count == 0 && w6 != null)
            {
                foreach (var item in w6.word)
                {
                    list6harfli.Items.Add(item);
                }
            }

            var w7 = w.Where(x => x.hane == 7).FirstOrDefault();
            if (list7harfli.Items.Count == 0 && w7 != null)
            {
                foreach (var item in w7.word)
                {
                    list7harfli.Items.Add(item);
                }
            }

            var w8 = w.Where(x => x.hane == 8).FirstOrDefault();
            if (list8harfli.Items.Count == 0 && w8 != null)
            {
                foreach (var item in w8.word)
                {
                    list8harfli.Items.Add(item);
                }
            }

            var w9 = w.Where(x => x.hane == 9).FirstOrDefault();
            if (list9harfli.Items.Count == 0 && w9 != null)
            {
                foreach (var item in w9.word)
                {
                    list9harfli.Items.Add(item);
                }
            }



        }

        private void btnkelimebul_Click(object sender, EventArgs e)
        {

            KelimeUret();
            var w = _resultWords.r_word.ToList();
            var p = _resultWords.r_word.Where(x => x.word != null).OrderByDescending(x => x.hane).FirstOrDefault();

            if (p != null)
            {
                toplampuan = p.hane;
            }
            MessageBox.Show("Puan: " + toplampuan);
        }

        private void btnyenioyun_Click(object sender, EventArgs e)
        {
            counter = 0;
            harfbtn1.Text = " ";
            harfbtn2.Text = " ";
            harfbtn3.Text = " ";
            harfbtn4.Text = " ";
            harfbtn5.Text = " ";
            harfbtn6.Text = " ";
            harfbtn7.Text = " ";
            harfbtn8.Text = " ";
            txtjokerharf.Text = " ";
            label1.Text = "";
            lblharf1.Text = " ";
            lblharf2.Text = " ";
            lblharf3.Text = " ";
            lblharf4.Text = " ";
            lblharf5.Text = " ";
            lblharf6.Text = " ";
            lblharf7.Text = " ";
            lblharf8.Text = " ";
            lblharf9.Text = " ";
            btnHarfAl.Enabled = true;

            rndharfler = "";

            result2 = new List<string>();
            myWords = new List<string>();
            _resultWords = new ResultWords();
            toplampuan = 0;
            kelimelistdata = new List<Word>();
            list3harfli.Items.Clear();
            list4harfli.Items.Clear();
            list5harfli.Items.Clear();
            list6harfli.Items.Clear();
            list7harfli.Items.Clear();
            list8harfli.Items.Clear();
            list9harfli.Items.Clear();
        }
    }
}
