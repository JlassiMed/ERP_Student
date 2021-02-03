using ERP_Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace ERP_Enseignant
{
    public partial class Inscription_Etudiant : MetroFramework.Forms.MetroForm 
    {
        bool picturechanged = false;
        bool allgood = false;
        string picture;
        EtudiantLoginDataContext db;
        public Inscription_Etudiant()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Accueil_Etudiant AE = new Accueil_Etudiant();
            AE.Show(); 
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void bt_uploadphoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = @"c:\";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Title = "Selectionner une photo";
            ofd.Filter = "Tous les types d'images|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String f1 = ofd.FileName.ToString();
                photo.ImageLocation = f1;
                photo.Image = Image.FromFile(f1);
                picturechanged = true;
            }
        }

        private void bt_qrcode_Click(object sender, EventArgs e)
        {

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(textBox1.Text.Trim() + textBox4.Text.Trim()));
            pictureBox1.Image = result;
            bt_save.Enabled = true;


        }
        public bool Checkallgood()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                    if (c.Text.Length == 0)
                    {
                        return false;
                    }

            }
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^A-Z,a-z]"))
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.Text.Length;

            }
            if (textBox2.Text.Length == 0)
                textBox2.SelectionStart = 0;

            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox2.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox4.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^A-Z,a-z]"))
            {
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                textBox3.SelectionStart = textBox3.Text.Length;

            }
            if (textBox3.Text.Length == 0)
                textBox3.SelectionStart = 0;

            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox3.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox5.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
                textBox6.SelectionStart = textBox6.Text.Length;

            }
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox6.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
            {
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
                textBox7.SelectionStart = textBox7.Text.Length;

            }
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox7.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void photo_Click(object sender, EventArgs e)
        {

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Selectionner un placement";
            dialog.RestoreDirectory = true;
            dialog.Filter = "Tous les types d'images|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png|" + "Bitmap (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image.Save(dialog.FileName, ImageFormat.Bmp);
            }
        }
        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            allgood = true;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                    if (c.Text.Length == 0)
                    {
                        MessageBox.Show("veuillez remplir tout les champs !");
                        c.Focus();
                        allgood = false;
                        break;
                    }
                    else if (c == textBox1 && textBox1.Text.Length < 8)
                    {
                        MessageBox.Show("cin doit être composé de 8 chiffres !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allgood = false;
                    }
            }
            if (allgood)
            {
                bool emailverif = true;
                try
                {
                    var m = new System.Net.Mail.MailAddress(textBox5.Text);
                }
                catch (System.FormatException f)
                {
                    MessageBox.Show("email incorrect !");
                    emailverif = false;
                }

                if (picturechanged == false && pictureBox1.Image == null)
                    MessageBox.Show("insérer votre image et votre QR code svp !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (picturechanged == false)
                    MessageBox.Show("insérer votre image svp !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (pictureBox1.Image == null)
                    MessageBox.Show("générer votre QR code svp !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    try
                    {
                        db = new EtudiantLoginDataContext();
                        etudiant ens = new etudiant();
                        ens.cin = textBox1.Text;
                        var query = from enseignant in db.etudiants
                                    where enseignant.cin == ens.cin
                                    select enseignant;
                        List<etudiant> listeEns = query.ToList<etudiant>();
                        if (listeEns.Count != 0)
                        {
                            MessageBox.Show("vous êtes déjà inscrit !");
                        }
                        else
                        {
                            ens.mail = textBox5.Text;
                            ens.mots_de_passe = textBox4.Text;
                            ens.nom = textBox2.Text;
                            ens.prenom = textBox3.Text;
                            ens.Année = Int32.Parse(textBox7.Text);
                            ens.NiveauEtud = Int32.Parse(textBox6.Text);
                            MemoryStream ms = new MemoryStream();
                            photo.Image.Save(ms, ImageFormat.Jpeg);
                            byte[] pic_array = new byte[ms.Length];
                            ms.Position = 0;
                            ms.Read(pic_array, 0, pic_array.Length);
                            ens.photo = pic_array;

                            MemoryStream mss = new MemoryStream();
                            pictureBox1.Image.Save(mss, ImageFormat.Bmp);
                            byte[] qr_array = new byte[mss.Length];
                            mss.Position = 0;
                            mss.Read(qr_array, 0, qr_array.Length);
                            ens.code_a_bar = qr_array;

                            db.etudiants.InsertOnSubmit(ens);
                            db.SubmitChanges();
                            // len = ens.photo.ToString().Length;

                            MessageBox.Show("inscription réussite !");
                        }
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show(text: "erreur d'insertion " + exx.Message, caption: "Erreur", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    }

                //MessageBox.Show(len.ToString());
                /*
            var optionss = new ZXing.Common.EncodingOptions
            {
                PureBarcode = true,
            Height = 30,
            Width = 100,
            };

            var writerr = new BarcodeWriter();
            writerr.Format = BarcodeFormat.CODE_128;
            writerr.Options = optionss;
            var qrr = new BarcodeWriter();
            qrr.Options = optionss; 
            qrr.Format = ZXing.BarcodeFormat.CODE_128;
            var resultt = new Bitmap(qrr.Write(textBox1.Text.Trim()));
            pictureBox2.Image = resultt;

            var reader = new BarcodeReader();
            var x=reader.Decode(resultt);
            textBox6.Text= x.ToString();
            */

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;

            }
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox1.Text.Length == 0)
            {
                textBox1.SelectionLength = 0;
                bt_qrcode.Enabled = false;
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
