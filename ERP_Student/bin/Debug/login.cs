using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ERP_Student;
using System.Data.SqlClient;
using Nemiro.OAuth.LoginForms;

namespace ERP_Enseignant
{
    public partial class login : MetroForm
    {
        EtudiantLoginDataContext db;
        // loginteachDataContext db = new loginteachDataContext(@"Data Source = MEDJL47\SQLEXPRESS; Initial Catalog = ERP_Teacher; Integrated Security = True;Pooling=False");
        public static string logintype;
        public static etudiant ValidatedEns;
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ValidatedEns = new etudiant();

        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (cin_tb.Text == "")
                MessageBox.Show("Veuillez remplir cin");
            else if (cin_tb.Text.Length > 8)
                MessageBox.Show("la longueur de cin dépasse les 8 chiffres veuillez vérifier !");
            else if (mdp_tb.Text == "")
                MessageBox.Show("Veuillez remplir mot de passe !");

            else
            {
                try
                {
                    db = new EtudiantLoginDataContext();
                    etudiant en = new etudiant();
                    en.cin = cin_tb.Text.ToString();
                    en.mots_de_passe = mdp_tb.Text.ToString();


                    var query = from enseignant in db.etudiants
                                where enseignant.cin == en.cin
                                select enseignant;
                    List<etudiant> listeEns = query.ToList<etudiant>();
                    if (listeEns.Count == 0)
                    {
                        MessageBox.Show("cin introuvable veuillez vérifier !");
                    }
                    else
                    {
                        etudiant enss = listeEns[0];
                        if (enss.mots_de_passe != en.mots_de_passe)
                        {
                            MessageBox.Show("mot de passe incorrect");
                        }
                        else
                        {

                            ValidatedEns.cin = enss.cin;
                            ValidatedEns.mots_de_passe = enss.mots_de_passe;
                            ValidatedEns.nom = enss.nom;
                            ValidatedEns.prenom = enss.prenom;
                            ValidatedEns.mail = enss.mail;
                            ValidatedEns.photo = enss.photo;
                            ValidatedEns.code_a_bar = enss.code_a_bar;
                            ValidatedEns.NiveauEtud = enss.NiveauEtud;
                            ValidatedEns.Année = enss.Année;
                            Accueil_Etudiant ac = new Accueil_Etudiant();
                            ac.Show();
                            Hide();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur de connection BD " + ex.Message);
                }
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            QrScanner AE = new QrScanner();
            AE.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var login = new FacebookLogin("1435890426686808", "c6057dfae399beee9e8dc46a4182e8fd", true, true);

            login.ShowDialog();
            if (login.IsSuccessfully)
            {
                try
                {
                    db = new EtudiantLoginDataContext();
                    etudiant en = new etudiant();
                    en.mail = login.UserInfo.Email;
                    var query = from enseignant in db.etudiants
                                where enseignant.mail == en.mail
                                select enseignant;
                    List<etudiant> listeEns = query.ToList<etudiant>();
                    if (listeEns.Count == 0)
                    {
                        MessageBox.Show("aucun compte n'est lié à ce compte facebook !");
                    }
                    else
                    {
                        etudiant enss = listeEns[0];
                        ValidatedEns.cin = enss.cin;
                        ValidatedEns.mots_de_passe = enss.mots_de_passe;
                        ValidatedEns.nom = enss.nom;
                        ValidatedEns.prenom = enss.prenom;
                        ValidatedEns.mail = enss.mail;
                        ValidatedEns.photo = enss.photo;
                        ValidatedEns.code_a_bar = enss.code_a_bar;
                        ValidatedEns.NiveauEtud = enss.NiveauEtud;
                        ValidatedEns.Année = enss.Année;
                        Accueil_Etudiant ac = new Accueil_Etudiant();
                        ac.Show();
                    }

                }
                catch (SqlException exx)
                {
                    MessageBox.Show(exx.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FacialRecog fr = new FacialRecog();
            fr.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var Login = new TwitterLogin("RKlFn8Fo0xFxM1xgcaWAg22lK", "6sIGj7PN6DqPM8a7mQ2InpCIl4syZNLImwknedenN3xpfMJkP1", true, true);
                Login.ShowDialog();
                MessageBox.Show(Login.IsSuccessfully.ToString());
                if (Login.IsSuccessfully)
                {
                    try
                    {
                        db = new EtudiantLoginDataContext();
                        etudiant en = new etudiant();
                        en.nom = Login.UserInfo.UserName;
                        var query = from enseignant in db.etudiants
                                    where enseignant.nom == en.nom
                                    select enseignant;
                        List<etudiant> listeEns = query.ToList<etudiant>();
                        if (listeEns.Count == 0)
                        {
                            MessageBox.Show("aucun compte n'est lié à ce twitter !");
                        }
                        else
                        {

                            etudiant enss = listeEns[0];
                            ValidatedEns.cin = enss.cin;
                            ValidatedEns.mots_de_passe = enss.mots_de_passe;
                            ValidatedEns.nom = enss.nom;
                            ValidatedEns.prenom = enss.prenom;
                            ValidatedEns.mail = enss.mail;
                            ValidatedEns.photo = enss.photo;
                            ValidatedEns.code_a_bar = enss.code_a_bar;
                            ValidatedEns.NiveauEtud = enss.NiveauEtud;
                            ValidatedEns.Année = enss.Année;
                            Accueil_Etudiant ac = new Accueil_Etudiant();
                            ac.Show();
                        }

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erreur de connection BD " + ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            FacialRecog fr = new FacialRecog();
            fr.Show();
        }
    }
}


