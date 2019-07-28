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
    public partial class Form7 : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public DataTable dt;
        public static string idconstruct = null;
        public static string idconstructing = null;
        public static int refreshcheck = 0;
        public Form7()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMSDataSet1CS.ConstructTask' table. You can move, or remove it, as needed.
            this.constructTaskTableAdapter1.Fill(this.cMSDataSet1CS.ConstructTask);
            // TODO: This line of code loads data into the 'allTables.ConstructTask' table. You can move, or remove it, as needed.
            

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Construction_Task_New form = new Construction_Task_New();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Construction_Task_Update form = new Construction_Task_Update();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Delete?", "WARNING!", MessageBoxButtons.YesNoCancel,
      MessageBoxIcon.Stop);

            if (dr == DialogResult.Yes)
            {
                QProject qp = new QProject();
                qp.DeleteContask(idconstructing);
                this.constructTaskTableAdapter1.Fill(this.cMSDataSet1CS.ConstructTask);
            }
        }
           

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idconstruct = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Construction_Task_View frm = new Construction_Task_View();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idconstructing = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [ConstructTask] where [Date] like '" + bunifuDatepicker1.Value.ToShortDateString() + "%'", conn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [ConstructTask] where [Project Name] like '" + bunifuMaterialTextbox1.Text + "%'", conn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Form7_MouseEnter(object sender, EventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.constructTaskTableAdapter1.Fill(this.cMSDataSet1CS.ConstructTask);
            }
            refreshcheck = 0;
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.constructTaskTableAdapter1.Fill(this.cMSDataSet1CS.ConstructTask);
            }
            refreshcheck = 0;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
