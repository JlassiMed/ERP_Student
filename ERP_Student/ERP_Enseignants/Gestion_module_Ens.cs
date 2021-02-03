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
namespace ERP_Enseignant
{
    public partial class GestModule : MetroForm
    {
        public GestModule()
        {
            InitializeComponent();
        }

        private void GestModule_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TAR t = new TAR();
            t.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Assiduite a = new Assiduite();
            a.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Telechargement t = new Telechargement();
            t.Show();
        }
    }
}
