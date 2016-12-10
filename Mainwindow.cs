using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;// for mail processing
using System.Net;
using System.IO; //for file processing
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace mustafa
{
    public partial class Mainwindow : Form
    {
        
        
        
        public Mainwindow()
        {
            InitializeComponent();
            
            
        }
        SqlConnection baglanti = new SqlConnection(@"server=.\SQLEXPRESS ; database=odev3 ; Trusted_connection=yes");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            paketle();
            String dosyayolu = @"C:\Users\mustafademir\Desktop\KKKLASOR\Belge.txt";
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("xxx.com", "password");


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("xxx.com");
                mail.IsBodyHtml = false;
                mail.To.Add(comboBox1.Text.ToString());
                mail.Subject = richTextBox1.Text.ToString();
                mail.Body = "Bu Mail size USECE-Mail uygulamasıyla gönderilmiştir.."+
                    "Mesaj içeriğini görmek için uygulamamızı indirmelisiniz";
                mail.Attachments.Add(new Attachment(dosyayolu));
                sc.Send(mail);
                MessageBox.Show("Mail Başarıyla GÖnderildi.", "Mail Gönderme");
            }
            catch
            {
                MessageBox.Show("Mail Gönderme İşlemi Başarısız.", "Mail Gönderme");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private void kisigoster()
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from tOgrenci", baglanti);

            SqlDataReader rdr = kmt.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem li = new ListViewItem();
                li.Text = rdr["OgrenciID"].ToString();
                li.SubItems.Add(rdr["ad"].ToString());
                listView1.Items.Add(li);
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kisigoster();
        }
        private void paketle()
        {
            
            StreamWriter sw = new StreamWriter(@"C:\Users\exorion\Desktop\KKKLASOR\Belge.txt");
            sw.WriteLine(cry.SifreleAES(richTextBox2.Text, "12345678901234567890123456789012"));
            sw.Close();
            
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dos = new OpenFileDialog();
            dos.ShowDialog();
            if (dos.FileName != null)
            {
                string yol = dos.FileName;
                StreamReader oku = new StreamReader(yol);

                oku = File.OpenText(yol);
                yol = null;
                string metin = oku.ReadToEnd();

                oku.Close();
                string cozmetin = cry.SifreyiCozAES(metin, "12345678901234567890123456789012");
                richTextBox3.Text = cozmetin;
            }
            else
            {
                MessageBox.Show("don't change file");
            }
        }
    }
}
