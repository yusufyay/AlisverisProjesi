using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlisverisProjesi
{
    public partial class Form1 : Form
    {
        float entotal = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void labelpersonelindirimi_Click(object sender, EventArgs e)
        {

        }

        private void buttonurunekle_Click(object sender, EventArgs e)
        {
            /*
            1 - satış ile ilgili hiç alan boş geçilemez, ancak null değer alabılır ve bu durum hesaplamaya dahil edilmeyecek sekılde mantıklı algorıtma kurulmalıdır.
            2 - kdv zorunlu, iskonto istege bağlı olabilir yukarıdakı case geçerli.
            3 - ürün ekle dedıgımde sepete bir satıs numarasıda verecek sekılde bir numara fiş numarası gıbı ekleyecek.
            4 - aynı numara uzerınde bırden fazla kez ürün ekleyebılırım.
            5 - yenı urune gecıldıgınde sıstem gunluk cıroyu hesaplaycak, yanı her farklı alış veriş, her ayrı fiş bir satış demek ve gunluk cıroyu değiştirmesi gerek.
            6 - ürünler satış sırasında silinebilir.bu durumda ilgili tüm rakamlar güncellenmeli
            7 - ciro hedefı sabittir. fakat ciro hedefıne aylık satıs hedefı esıt veya buyukse satıs ıslemlerınde en altta bu durum buyuk harfle olacak sekılde belırtılmelıdır.
            8 - kesıntıler coktan secmelı olacak.
             */
            if (String.IsNullOrEmpty(textBoxurundeger.Text))
            {
                textBoxurundeger.Text="ürün";
            }
            if (String.IsNullOrEmpty(textBoxfiyatdeger.Text))
            {
                textBoxfiyatdeger.Text="0";
                
            }
            if (String.IsNullOrEmpty(textBoxmiktardeger.Text))
            {
                textBoxmiktardeger.Text="0";
            }



            float secilentutar = float.Parse(textBoxfiyatdeger .Text) * float.Parse(textBoxmiktardeger.Text);
            float kdvorani = (float.Parse(comboBoxkdv.Text) * secilentutar / 100);
            float iskontoorani = (float.Parse(comboBoxiskonto.Text) * secilentutar / 100);
            float personelindirimorani = (float.Parse(comboBoxpersonelindirimi.Text) * secilentutar / 100);
            float etotal = secilentutar + kdvorani - iskontoorani - personelindirimorani;
            entotal = entotal + (etotal);
            labeltoplamtutardegeri.Text = (entotal).ToString();
            

           listBox1.Items.Add(textBoxurundeger.Text +" - "+ textBoxmiktardeger .Text + " adet - " + etotal +" tl ").ToString();
            labelgunlukcirodegeri.Text = labeltoplamtutardegeri.Text;



            textBoxurundeger.Clear();
            textBoxmiktardeger.Clear();
            textBoxfiyatdeger.Clear();

            comboBoxkdv.Text = null;
            comboBoxiskonto.Text = null;
            comboBoxpersonelindirimi.Text = null;

            //labeltoplamtutardegeri.Text = (int.Parse(labeltoplamtutardegeri.Text) + int.Parse(labeltoplamtutardegeri.Text) ).ToString();
            
        }

        private void buttonurunsil_Click(object sender, EventArgs e)
        {
            int secili = listBox1.SelectedIndex;
            var a = listBox1.SelectedItem.ToString();
            var falan = a.Split('-');
            var deger = falan[2];
            var finalDeger = float.Parse(deger.Remove(deger.Length - 4, 3));

            listBox1.Items.RemoveAt(secili);

            entotal -= finalDeger;
            
            labeltoplamtutardegeri.Text = entotal.ToString();
            labelgunlukcirodegeri.Text = labeltoplamtutardegeri.Text;

        }
        //test
        private void buttonyenikayıt_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            labeltoplamtutardegeri.Text = 0.ToString(); 
        }
    }
}
