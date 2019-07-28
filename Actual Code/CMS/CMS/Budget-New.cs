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
    public partial class Budget_New : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public string title, status,date;
        public int balance, credit, debit;
        public Budget_New()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Budget_New_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT [Project Title] from ProjectContract", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {

                    comboBox1.Items.Add(dr["Project Title"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)||char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox3, "0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox4, "0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox6, "0-9");
                e.Handled = true;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            qp.Budgetbalance(comboBox1.SelectedItem.ToString());
            bunifuMaterialTextbox3.Text =qp.bdgblnce;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            title = comboBox1.SelectedItem.ToString();
            balance = Convert.ToInt32(bunifuMaterialTextbox3.Text);
            credit = Convert.ToInt32(bunifuMaterialTextbox4.Text);
            debit = Convert.ToInt32(bunifuMaterialTextbox6.Text);
            status = bunifuMaterialTextbox5.Text;
            date = bunifuDatepicker1.Value.ToShortDateString();
            balance = balance + credit;
            balance = balance - debit;
            qp.Addbudget(title,balance,credit,debit,status,date);
            CMS.Budget.refreshcheck = 100;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Budget form = new Budget();
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
