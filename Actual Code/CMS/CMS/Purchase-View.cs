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
    public partial class Purchase_View : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string idpchs = null;
        public Purchase_View()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Purchase_View_Load(object sender, EventArgs e)
        {
            idpchs = CMS.Purchase.idpurchasedc;


            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT * from Purchase where ID=" + idpchs + "", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    label13.Text = dr["ID"].ToString();
                    label12.Text = dr["Project Title"].ToString();
                    label22.Text = dr["Date"].ToString();
                    label10.Text = dr["Time"].ToString();
                    label7.Text = dr["Status"].ToString();
                    label11.Text = dr["T Date"].ToString();
                    label16.Text = dr["Supplier"].ToString();
                    label15.Text = dr["Material Name"].ToString();
                    label17.Text = dr["MQuantity"].ToString();
                    label23.Text = dr["MPrice"].ToString();
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
            Purchase form = new Purchase();
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
