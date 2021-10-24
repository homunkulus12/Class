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

namespace wiadcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckAccessibility();
           
        }

        void CheckAccessibility()
        {
            string path = @"C:\Users\Max\source\repos\wiadcode\wiadcode\Abil.json";
            bool Acces = bool.Parse(File.ReadAllText(path));

            if (Acces)
            {
                StartApp();
            }
            else
            {
                MessageBox.Show("App is blocket!");
            }
        }

        void StartApp()
        {
            DataMeth dataMeth = new DataMeth();
            DataUser FirstUser = dataMeth.StartUser();

            lblID.Text = FirstUser.ID.ToString();
            lblName.Text = FirstUser.Name;
            lblMess.Text = FirstUser.Message;
        }

        #region Nothing Special
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        #endregion Nothing Special

        // Next user button.
        private void button2_Click(object sender, EventArgs e)
        {
            DataMeth dataMeth = new DataMeth();
            DataUser NextUser = dataMeth.GiveNextUser(lblMess.Text);

            lblID.Text = NextUser.ID.ToString();
            lblName.Text = NextUser.Name;
            lblMess.Text = NextUser.Message;
        }

        // Last user button.
        private void button1_Click(object sender, EventArgs e)
        {
            DataMeth dataMeth = new DataMeth();
            DataUser LastUser = dataMeth.GiveLastUser(lblMess.Text);

            lblID.Text = LastUser.ID.ToString();
            lblName.Text = LastUser.Name;
            lblMess.Text = LastUser.Message;
        }

        // Save button.
        private void button3_Click(object sender, EventArgs e)
        {
            DataMeth dataMeth = new DataMeth();
            dataMeth.SafeData(lblMess.Text);

            Application.Exit();
        }
    }
}
