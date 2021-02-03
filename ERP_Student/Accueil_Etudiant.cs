using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Enseignant
{
    public partial class Accueil_Etudiant : MetroFramework.Forms.MetroForm
    {

        public Accueil_Etudiant()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        private void Accueil_Etudiant_Load(object sender, EventArgs e)
        {
            nom.Text = login.ValidatedEns.nom;
            prenom.Text = login.ValidatedEns.prenom;
            var result = byteArrayToImage(login.ValidatedEns.photo.ToArray());
            photo.Image = result;

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Module AE = new Module();
            AE.Show(); 
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            etud.Remise TAR = new etud.Remise();
            TAR.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            etud.Form3 tr = new etud.Form3 ();
            tr.Show(); 

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            ERP_Student.Informations_pers  info_pers = new ERP_Student.Informations_pers();
            info_pers.Show();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            ERP_Enseignant.Supports EN = new ERP_Enseignant.Supports ();
            EN.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            ERP_Student.Stats s = new ERP_Student.Stats();
            s.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
