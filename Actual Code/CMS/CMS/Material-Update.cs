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
    public partial class Material_Update : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string Materialid = null;
        public Material_Update()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Material_Update_Load(object sender, EventArgs e)
        {
            Materialid = CMS.Material.idmm;

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT * from Material where ID=" + Materialid + "", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    bunifuMaterialTextbox1.Text = dr["ID"].ToString();
                    bunifuMaterialTextbox2.Text = dr["Name"].ToString();
                    bunifuMaterialTextbox7.Text = dr["Value"].ToString();
                    
                    bunifuMaterialTextbox4.Text = dr["Type"].ToString();
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
            qp.UpdateMaterial(bunifuMaterialTextbox2.Text,bunifuMaterialTextbox7.Text,bunifuMaterialTextbox5.Text,bunifuMaterialTextbox4.Text);
            CMS.Material.refreshcheck = 100;
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox2, "A-Z,a-z,0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox7, "0-9");
                e.Handled = true;

            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Material form = new Material();
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
