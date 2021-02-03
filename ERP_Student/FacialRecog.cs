using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using ERP_Enseignant;
using MetroFramework.Forms;
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


namespace ERP_Student
{
    public partial class FacialRecog : MetroForm
    {
        VideoCapture capture;
        CascadeClassifier cascadeClassifier = new CascadeClassifier("C:\\Users\\Mohamed\\Desktop\\7ama\\9raya\\projet c#\\ERP_Teacher\\ERP_Teacher\\haarcascade_frontalface_alt2.xml");
        EtudiantLoginDataContext db;
        List<etudiant> faces;
        FaceRecognizer recognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);

        public FacialRecog()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        private void FacialRecog_Load(object sender, EventArgs e)
        {
            db = new EtudiantLoginDataContext();
            faces = new List<etudiant>();
            var query = from enseignant in db.etudiants
                        where enseignant.photo != null
                        select enseignant;
            faces = query.ToList();

        }
        public bool learn()
        {
            //List<Faces> allFaces = recognizer.Predict();
            if (faces.Count > 0)
            {
                var faceImages = new Image<Gray, byte>[faces.Count];
                var faceLabels = new int[faces.Count];
                for (int i = 0; i < faces.Count; i++)
                {
                    Stream stream = new MemoryStream();

                    stream.Write(faces[i].photo.ToArray(), 0, faces[i].photo.Length);

                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));

                    faceImages[i] = faceImage.Resize(300, 500, interpolationType: Inter.Cubic);
                    faceLabels[i] = Int32.Parse(faces[i].cin);
                }

                recognizer.Train(faceImages, faceLabels);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture();
            }
            Application.Idle += ProcessFrame;
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            imageBox1.Image = capture.QueryFrame();
        }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                imageBox1.Image = m.ToImage<Bgr, Byte>();

            }
            catch (Exception)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            learn();
            string name;
            int resultat = 0;
            using (var imageFrame = capture.QuerySmallFrame().ToImage<Bgr, Byte>())
            {

                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    var Faces = cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                    var grayframe2 = grayframe.Resize(300, 500, interpolationType: Inter.Cubic);
                    bool found = false;
                    foreach (var face in Faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                        FaceRecognizer.PredictionResult pre = recognizer.Predict(grayframe2);

                        MessageBox.Show(pre.Label.ToString());



                        for (int j = 0; j < faces.Count; j++)
                        {

                            if (Int32.Parse(faces[j].cin) == pre.Label)
                            {

                                login.ValidatedEns.cin = faces[j].cin;
                                login.ValidatedEns.mots_de_passe = faces[j].mots_de_passe;
                                login.ValidatedEns.nom = faces[j].nom;
                                login.ValidatedEns.prenom = faces[j].prenom;
                                login.ValidatedEns.mail = faces[j].mail;
                                login.ValidatedEns.photo = faces[j].photo;
                                login.ValidatedEns.code_a_bar = faces[j].code_a_bar;
                                login.ValidatedEns.Année = faces[j].Année;
                                login.ValidatedEns.NiveauEtud = faces[j].NiveauEtud;

                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            Accueil_Etudiant ac = new Accueil_Etudiant();
                            ac.Show();
                            break;
                        }
                    }

                    pictureBox2.Image = imageFrame.ToBitmap();
                }
            }

        }
    }
}
