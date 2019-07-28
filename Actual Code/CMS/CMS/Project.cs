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
    public partial class Project : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public DataTable dt;
        public static string id = null;
        public static string iddd = null;
        public static int refreshcheck=0;
        public Project()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Project_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pCDS.ProjectContract' table. You can move, or remove it, as needed.
            this.projectContractTableAdapter.Fill(this.pCDS.ProjectContract);
            // TODO: This line of code loads data into the 'pCDS.ProjectContract' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'allTables.ProjectContract' table. You can move, or remove it, as needed.



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Project_New form = new Project_New();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            Project_Update form = new Project_Update();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs ex)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Project_View frm = new Project_View();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iddd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           
            QProject qp = new QProject();
            DialogResult DDR = MessageBox.Show("Are you sure you want to Delete?", "Delete Project", MessageBoxButtons.YesNoCancel,
      MessageBoxIcon.Stop);

            if (DDR == DialogResult.Yes)
            {
                qp.DeleteProject(iddd);
                
            }
            try
            {
                this.projectContractTableAdapter.FillData(this.pCDS.ProjectContract);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [ProjectContract] where [Project Title] like '" + bunifuMaterialTextbox1.Text + "%'", conn);
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

        private void fillDataToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.projectContractTableAdapter.FillData(this.pCDS.ProjectContract);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Project_MouseEnter(object sender, EventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.projectContractTableAdapter.FillData(this.pCDS.ProjectContract);
            }
            refreshcheck = 0;
        }

        private void Project_MouseMove(object sender, MouseEventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.projectContractTableAdapter.FillData(this.pCDS.ProjectContract);
            }
            refreshcheck = 0;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}

