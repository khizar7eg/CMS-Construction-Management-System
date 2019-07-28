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
    public partial class Purchase : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public DataTable dt;
        public static string idpurchasedc = null, idpc = null;
        public static int refreshcheck = 0;
        public Purchase()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Purchase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allTables.Purchase' table. You can move, or remove it, as needed.
            this.purchaseTableAdapter.Fill(this.allTables.Purchase);
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Purchase_New form = new Purchase_New();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idpc = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Delete?", "WARNING!", MessageBoxButtons.YesNoCancel,
      MessageBoxIcon.Stop);

            if (dr == DialogResult.Yes)
            {
                QProject qp = new QProject();
                qp.DeletePurchase(idpc);
                this.purchaseTableAdapter.Fill(this.allTables.Purchase);
            }
            

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Purchase_Update form = new Purchase_Update();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [Purchase] where [Project Title] like '" + comboBox1.SelectedItem.ToString() + "%'", conn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [Purchase] where [Date] like '" + bunifuDatepicker1.Value.ToShortDateString() + "%'", conn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idpurchasedc = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Purchase_View frm = new Purchase_View();
            frm.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Purchase_MouseEnter(object sender, EventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.purchaseTableAdapter.Fill(this.allTables.Purchase);
            }
            refreshcheck = 0;
        }

        private void Purchase_MouseMove(object sender, MouseEventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.purchaseTableAdapter.Fill(this.allTables.Purchase);
            }
            refreshcheck = 0;
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
