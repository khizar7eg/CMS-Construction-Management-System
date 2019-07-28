using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CMS
{
    public partial class Material_View : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Material p = new Material();
        public string idmmm = null;

        public Material_View()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Material_View_Load(object sender, EventArgs e)
        {
            idmmm = CMS.Material.idm;


            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT * from Material where ID=" + idmmm + "", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    label13.Text = dr["ID"].ToString();
                    label10.Text = dr["Name"].ToString();
                    label9.Text = dr["Quantity"].ToString();
                    label8.Text = dr["Value"].ToString();
                    label3.Text = dr["Type"].ToString();
                    label11.Text = dr["Comment"].ToString();
                    
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        private void panel1_AutoSizeChanged(object sender, EventArgs e)
        {

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
