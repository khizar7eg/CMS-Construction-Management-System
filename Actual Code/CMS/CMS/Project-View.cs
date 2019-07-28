using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CMS
{
    public partial class Project_View : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string idd = null;
        public Project_View()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Project_View_Load(object sender, EventArgs e)
        {
            idd=CMS.Project.id;
            
            
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("SELECT * from ProjectContract where ID="+idd+"", conn);

            try { 

                SqlDataReader dr = cm.ExecuteReader();
                    
                while (dr.Read())
                {
                    label18.Text = dr["Project Title"].ToString();
                    label17.Text = dr["Org Name"].ToString();
                    label16.Text = dr["Tender No"].ToString();
                    label15.Text = dr["Entry Date"].ToString();
                    label14.Text = dr["Status"].ToString();
                    label13.Text = dr["Duration"].ToString();
                    label12.Text = dr["Type"].ToString();
                    label10.Text = dr["Budget"].ToString();
                    label19.Text = dr["Comment"].ToString();
                    byte[] img = (byte[])(dr["Image"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
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
