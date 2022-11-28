using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MessagingToolkit.Barcode;
using BasselTech_CamCapture;
using System.ComponentModel;
using System.Media;
using System.Linq;
using System.Collections.Generic;

namespace JuustoLaskin
{
    public partial class Form1 : Form
    {
        decimal sum = 0;
        string barcode;
        int transbox = 1;
       
        // Juustokilojen tallennus mahdollista korjausta varten
        string[] madrigal;
        string[] vintageCheddar;
        string[] manchego;
        string[] brie;
        string[] chevre;
        string[] appenzeller;
        string[] landana;

        int transBoxAmount;


        public Form1()
        {          
            InitializeComponent();

            label4.Text = DateTime.Now.ToString("dd.MM.yyyy");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button4.Visible = false;
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
           

            if (comboBox1.Text == "MADRIGAL")
            {
                dt = dt.AddDays(21);
                VKP.Text = dt.ToString("dd.MM.yyyy");               
                              
            }

            if (comboBox1.Text == "VINTAGE CHEDDAR")
            {
                dt = dt.AddDays(18);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }

            if (comboBox1.Text == "MANCHEGO")
            {
                dt = dt.AddDays(21);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }

            if (comboBox1.Text == "CHEVRE")
            {
                dt = dt.AddDays(18);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }

            if (comboBox1.Text == "BRIE")
            {
                dt = dt.AddDays(18);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }


            if (comboBox1.Text == "STILTON")
            {
                dt = dt.AddDays(18);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }

            if (comboBox1.Text == "GRUYERE")
            {
                dt = dt.AddDays(21);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }

            if (comboBox1.Text == "APPENZELLER")
            {
                dt = dt.AddDays(21);
                VKP.Text = dt.ToString("dd.MM.yyyy");

            }

            if (comboBox1.Text == "LANDANA")
            {
                dt = dt.AddDays(21);
                VKP.Text = dt.ToString("dd.MM.yyyy");
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            barcode = textBox2.Text;

            if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960010")
            {
                comboBox1.SelectedIndex = 0;
            }
            else if(textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960009")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960004")
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960005")
            {
                comboBox1.SelectedIndex = 3;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960006")
            {
                comboBox1.SelectedIndex = 4;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960007")
            {
                comboBox1.SelectedIndex = 5;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960002")
            {
                comboBox1.SelectedIndex = 6;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960008")
            {
                comboBox1.SelectedIndex = 7;
            }
            else if (textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 8) == "23960015")
            {
                comboBox1.SelectedIndex = 8;
            }

            






            if (textBox2.Text != "" && textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 4) == "2396")
            {
                textBox1.Text = barcode.Substring(8, 1) + "," + barcode.Substring(9, 3);
                
            }

            else if(textBox2.Text.Length == 13 && textBox2.Text.Substring(0, 4) != "2396")
            {
                MessageBox.Show("Paino tai EAN-koodi virheellinen, yritä uudestaan", "Huomio");
                textBox2.Clear();

            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 5 && textBox1.Text != "0,000")
            {
                
                NumeroLista.Items.Insert(0, textBox1.Text);
                
                textBox2.Clear();
                textBox1.Clear();

            }
            else if(textBox1.Text == "0,000")
            {
                textBox2.Clear();
                textBox1.Clear();
                MessageBox.Show("Tyhjä laatikko, yritä uudelleen.", "Huomio");
                textBox2.Focus();
            }
            WeightTextUpdate();
            CountBoxes();
        }

        private void textBox_1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" || textBox1.Text != null)
            {
                textBox1.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = NumeroLista.GetItemText(NumeroLista);
        }

        public void button4_Click(object sender, EventArgs e)
        {
           
            DateTime dt = DateTime.Now;

            if (comboBox1.Text == "MADRIGAL") 
            {
                dt = dt.AddDays(21);                
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226930 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
                
            }

            if (comboBox1.Text == "VINTAGE CHEDDAR") 
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226929 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "MANCHEGO") 
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226914 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "CHEVRE") 
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226915 " + comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "BRIE") 
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226916 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text/*dt.ToString("dd.MM.yyyy")*/
                + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }


            if (comboBox1.Text == "STILTON") 
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226932 " + comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "GRUYERE")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226912 " + comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "APPENZELLER") 
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226928 " + comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);

            }

            if (comboBox1.Text == "LANDANA") 
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "236525 " + comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;

            }


        }

        public void WeightTextUpdate()
        {
            decimal sum = 0;

            for (int i = 0; i < NumeroLista.Items.Count; i++)
            {
                sum += Convert.ToDecimal(NumeroLista.Items[i]);
                
            }

            if (sum != 0)
                Weight.Text = sum.ToString();
            else
                Weight.Text = "0";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.Enter)
            {

                if (textBox1.Text != "" && textBox1.Text != ",")
                {
                    NumeroLista.Items.Add(textBox1.Text);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

                else
                {
                    e.Handled = false;
                    MessageBox.Show("Syötä kilomäärä numeroin, kiitos");
                }

                

                textBox1.Clear();

                WeightTextUpdate();

                BoxAmount.Text = NumeroLista.Items.Count.ToString();
               
                
                


            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                NumeroLista.Focus();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            BoxAmount.Text = "0";
            NumeroLista.Items.Clear();
            Weight.Text = "0";
            textBox1.Clear();
            comboBox1.Text = "Valitse juusto";
            sum = 0;
            
            transbox = 1;
            TransBoxAmount.Text = transbox.ToString();
            

            textBox2.Focus();

        }

        public void Time()
        {
            DateTime dt = DateTime.Now;
        }

        public void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime dt = DateTime.Now;


            if (comboBox1.Text == "MADRIGAL" || comboBox1.Text == "MANCHEGO" || comboBox1.Text == "GRUYERE" || comboBox1.Text == "APPENZELLER" || comboBox1.Text == "LANDANA")
            {
                dt = dt.AddDays(21);
                e.Graphics.DrawString("VKP " + VKP.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(200, 350));
            }
            else
            {
                dt = dt.AddDays(18);
                e.Graphics.DrawString("VKP " + VKP.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(200, 350));
            }

            if (comboBox1.Text == "MADRIGAL")
            {
                e.Graphics.DrawString("226930 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(150, 200));
            }

            if (comboBox1.Text == "VINTAGE CHEDDAR")
            {
                e.Graphics.DrawString("226929 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            }

            if (comboBox1.Text == "MANCHEGO")
            {
                e.Graphics.DrawString("226914 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(150, 200));
            }

            if (comboBox1.Text == "CHEVRE")
            {
                e.Graphics.DrawString("226915 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(190, 200));
            }

            if (comboBox1.Text == "BRIE")
            {
                e.Graphics.DrawString("226916 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(220, 200));
            }


            if (comboBox1.Text == "STILTON")
            {
                e.Graphics.DrawString("226932 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(200, 200));
            }

            if (comboBox1.Text == "GRUYERE")
            {
                e.Graphics.DrawString("226912 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(180, 200));
            }

            if (comboBox1.Text == "APPENZELLER")
            {
                e.Graphics.DrawString("226928 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(150, 200));

            }

            if (comboBox1.Text == "LANDANA")
            {
                e.Graphics.DrawString("236525 " + comboBox1.Text, new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(180, 200));
            }

            e.Graphics.DrawString(BoxAmount.Text + " LTK /   " + "TransBox " + TransBoxAmount.Text + " KPL /   " + Weight.Text + " Kg", new Font("Calibri", 28, FontStyle.Regular), Brushes.Black, new Point(120, 550));
            e.Graphics.DrawString("1 Eur", new Font("Calibri", 45, FontStyle.Regular), Brushes.Black, new Point(350, 450));

        }


        private void button6_Click(object sender, EventArgs e)
        {
            //Laskee transboxien määrän lopuksi
            if(manualFeed.Checked == false)
            {
                if (NumeroLista.Items.Count % 12 > 0)
                {
                    transBoxAmount = (NumeroLista.Items.Count / 12) + 1;
                }

                else
                {
                    transBoxAmount = (NumeroLista.Items.Count / 12);
                }
                TransBoxAmount.Text = transBoxAmount.ToString();
            }
            



            DateTime dt = DateTime.Now;
            
            

            if (comboBox1.Text == "MADRIGAL")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226930 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);

               

            }

            if (comboBox1.Text == "VINTAGE CHEDDAR")
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226929 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "MANCHEGO")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226914 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "CHEVRE")
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226915 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "BRIE")
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226916 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }


            if (comboBox1.Text == "STILTON")
            {
                dt = dt.AddDays(18);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226932 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "GRUYERE")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226912 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }

            if (comboBox1.Text == "APPENZELLER")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "226928 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);

            }

            if (comboBox1.Text == "LANDANA")
            {
                dt = dt.AddDays(21);
                //string content = comboBox1.Text + Environment.NewLine + "VKP " + dt.ToString("dd.MM.yyyy") + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                email.Text += "236525 " + comboBox1.Text + Environment.NewLine + "VKP " + VKP.Text + Environment.NewLine + BoxAmount.Text + " LTK" + "  /  " + TransBoxAmount.Text + " Transbox" + "  /  " + Weight.Text + " Kg" + Environment.NewLine + Environment.NewLine;
                //File.AppendAllText(thepath, content);
            }
            PrintPreview.Document = PrintDocument;
            PrintPreview.ShowDialog();
            SaveNumeroListaItems();
                   

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (NumeroLista.SelectedIndex != -1)
            {
                string tama = NumeroLista.SelectedItem.ToString();
                NumeroLista.Items.Remove(tama);
                BoxAmount.Text = NumeroLista.Items.Count.ToString();
            }

            else
            {
                MessageBox.Show("Valitse ensin poistettava numero");
            }

            WeightTextUpdate();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Syötä paino")
            {
                textBox1.Clear();
            }

            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }


        private void NumeroLista_KeyDown(object sender, KeyEventArgs e)
        {

        
            if (e.KeyCode == Keys.Delete && NumeroLista.SelectedIndex != -1)
            {              
                string tama = NumeroLista.SelectedItem.ToString();
                NumeroLista.Items.Remove(tama);
                BoxAmount.Text = NumeroLista.Items.Count.ToString();

                e.Handled = true;
                e.SuppressKeyPress = true;
                NumeroLista.Focus();
                
  
            }

            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                NumeroLista.Focus();
            }


            WeightTextUpdate();
            BoxAmount.Text = NumeroLista.Items.Count.ToString();
        }
   

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Haluatko varmasti sulkea Juustolaskimen?", "VAROITUS", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {            
            Clipboard.SetText(email.Text);
            MessageBox.Show("Teksti kopioitu", "Kopioi");
        }


        private void CountBoxes()
        {
            BoxAmount.Text = NumeroLista.Items.Count.ToString();
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }


            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

           
        }

        public void SaveNumeroListaItems()
        {

            
            if(comboBox1.SelectedIndex == 0)
            {
                madrigal = new string[NumeroLista.Items.Count];
                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        madrigal[i] = NumeroLista.Items[i].ToString();
                    }
               

            }
           
            
            if (comboBox1.SelectedIndex == 1)
            {
                vintageCheddar = new string[NumeroLista.Items.Count];
                
                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        vintageCheddar[i] = NumeroLista.Items[i].ToString();
                    }
                
            }

            
            if (comboBox1.SelectedIndex == 2)
            {
                manchego = new string[NumeroLista.Items.Count];

                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        manchego[i] = NumeroLista.Items[i].ToString();
                    }
                
            }

            if (comboBox1.SelectedIndex == 3)
            {
                chevre = new string[NumeroLista.Items.Count];

                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        chevre[i] = NumeroLista.Items[i].ToString();
                    }

            }

            if (comboBox1.SelectedIndex == 4)
            {
                brie = new string[NumeroLista.Items.Count];

                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        brie[i] = NumeroLista.Items[i].ToString();
                    }

            }

            if (comboBox1.SelectedIndex == 7)
            {
                appenzeller = new string[NumeroLista.Items.Count];

                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        appenzeller[i] = NumeroLista.Items[i].ToString();
                    }

            }

            if (comboBox1.SelectedIndex == 8)
            {
                landana = new string[NumeroLista.Items.Count];

                if (NumeroLista.Items.Count >= -1)
                    for (int i = 0; i < NumeroLista.Items.Count; i++)
                    {
                        landana[i] = NumeroLista.Items[i].ToString();
                    }

            }





        }

        public void GetNumeroListaItems()
        {
            if (comboBox1.SelectedIndex == 0 && madrigal != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < madrigal.Length; i++)
                {
                NumeroLista.Items.Add(madrigal[i].ToString());
                }

            if (comboBox1.SelectedIndex == 1 && vintageCheddar != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < vintageCheddar.Length; i++)
                {
                    NumeroLista.Items.Add(vintageCheddar[i].ToString());
                }
            if (comboBox1.SelectedIndex == 2 && manchego != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < manchego.Length; i++)
                {
                    NumeroLista.Items.Add(manchego[i].ToString());
                }

            if (comboBox1.SelectedIndex == 3 && chevre != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < chevre.Length; i++)
                {
                    NumeroLista.Items.Add(chevre[i].ToString());
                }

            if (comboBox1.SelectedIndex == 4 && brie != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < brie.Length; i++)
                {
                    NumeroLista.Items.Add(brie[i].ToString());
                }
            if (comboBox1.SelectedIndex == 7 && appenzeller != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < appenzeller.Length; i++)
                {
                    NumeroLista.Items.Add(appenzeller[i].ToString());
                }

            if (comboBox1.SelectedIndex == 8 && landana != null && comboBox1.Text != "Valitse juusto")
                for (int i = 0; i < landana.Length; i++)
                {
                    NumeroLista.Items.Add(landana[i].ToString());
                }
        }



        private void button4_Click_1(object sender, EventArgs e)
        {

            GetNumeroListaItems();
            button4.Visible = false;
                
        }


        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            button4.Visible = true;
                
        }

        private void manualFeed_CheckedChanged(object sender, EventArgs e)
        {
            if(manualFeed.Checked == true)
            {
                Weight.ReadOnly = false;
                BoxAmount.ReadOnly = false;
            }

            else
            {
                Weight.ReadOnly = true;
                BoxAmount.ReadOnly = true;
            }
        }

        private void tiedot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tämä sovellus on Miika Viinikaisen sooloprojektina työstämä laskin helpottamaan erikoisjuustojen painojen tilastoimista. Vois olla parempikin, mut vois olla huonompikin!! Tsemppiä!", "Info", MessageBoxButtons.OK);
        }
    }
}

