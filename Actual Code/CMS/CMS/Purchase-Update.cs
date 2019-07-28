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
    public partial class Purchase_Update : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string idchase = null;
        public Purchase_Update()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Purchase_Update_Load(object sender, EventArgs e)
        {
            idchase = CMS.Purchase.idpc;

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT * from Purchase where ID=" + idchase + "", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {

                    bunifuMaterialTextbox1.Text = dr["Project Title"].ToString();
                    bunifuMaterialTextbox4.Text = dr["Date"].ToString();
                    bunifuMaterialTextbox6.Text = dr["Time"].ToString();
                    bunifuMaterialTextbox9.Text = dr["Status"].ToString();
                    bunifuMaterialTextbox5.Text = dr["T Date"].ToString();
                    bunifuMaterialTextbox2.Text = dr["Supplier"].ToString();
                    bunifuMaterialTextbox3.Text = dr["Material Name"].ToString();
                    bunifuMaterialTextbox7.Text = dr["MQuantity"].ToString();
                    bunifuMaterialTextbox8.Text = dr["MPrice"].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            qp.UpdatePurchase(bunifuMaterialTextbox1.Text,bunifuMaterialTextbox4.Text,bunifuMaterialTextbox6.Text,bunifuMaterialTextbox9.Text,bunifuMaterialTextbox5.Text,bunifuMaterialTextbox2.Text,bunifuMaterialTextbox3.Text,bunifuMaterialTextbox7.Text,bunifuMaterialTextbox8.Text);
            CMS.Purchase.refreshcheck = 100;
        }

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)||char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "Enter only 0-9,A-Z,a-z, or -,_");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 47 || e.KeyChar == 92 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox4, "Enter only 0-9,\\,/");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 47 || e.KeyChar == 92 || e.KeyChar == 58 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox6, "Enter only 0-9,\\,/,:,AM,PM");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
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

        private void bunifuMaterialTextbox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 47 || e.KeyChar == 92 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox5, "Enter only 0-9,\\,/");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
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
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox3, "Enter only A-z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox7, "Enter only 0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox8, "Enter only 0-9");
                e.Handled = true;

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
