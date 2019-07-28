using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CMS
{
    public partial class Project_Update : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string idd = null;
        public Project_Update()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Project_Update_Load(object sender, EventArgs e)
        {
            idd = CMS.Project.iddd;

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT * from ProjectContract where ID=" + idd + "", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {

                        bunifuMaterialTextbox1.Text = dr["Project Title"].ToString();
                        bunifuMaterialTextbox2.Text = dr["Org Name"].ToString();
                        bunifuMaterialTextbox3.Text = dr["Tender No"].ToString();
                        bunifuMaterialTextbox7.Text = dr["Entry Date"].ToString();
                        bunifuMaterialTextbox8.Text = dr["Status"].ToString();
                        bunifuMaterialTextbox6.Text = dr["Duration"].ToString();
                        bunifuMaterialTextbox4.Text = dr["Type"].ToString();
                        bunifuMaterialTextbox9.Text = dr["Budget"].ToString();
                        bunifuMaterialTextbox5.Text = dr["Comment"].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            QProject qp = new QProject();
            qp.UpdateProject(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text, bunifuMaterialTextbox3.Text, bunifuMaterialTextbox7.Text, bunifuMaterialTextbox8.Text, bunifuMaterialTextbox4.Text, bunifuMaterialTextbox6.Text, bunifuMaterialTextbox5.Text, Convert.ToInt64(bunifuMaterialTextbox9.Text));
            CMS.Project.refreshcheck = 100;
        }

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "Enter only A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox2, "Enter only A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuMaterialTextbox8_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuMaterialTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == 46 || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox6, "A-Z,a-z,0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox9, "A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Project form = new Project();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 500;
                mouseY = MousePosition.Y - 20;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
