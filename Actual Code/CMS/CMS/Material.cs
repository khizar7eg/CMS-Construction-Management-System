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
    public partial class Material : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public DataTable dt;
        public static string idm = null;
        public static string idmm = null;
        public static int refreshcheck = 0;
        public Material()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Material_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allTables.Material' table. You can move, or remove it, as needed.
            this.materialTableAdapter.Fill(this.allTables.Material);

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Material_New form = new Material_New();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Material_Update form = new Material_Update();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idmm = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idm = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Material_View frm = new Material_View();
            frm.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Delete?", "WARNING!", MessageBoxButtons.YesNoCancel,
       MessageBoxIcon.Stop);

            if (dr == DialogResult.Yes)
            {
                QProject qp = new QProject();
                qp.DeleteMaterial(idmm);
                this.materialTableAdapter.Fill(this.allTables.Material);
            }
           
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            da = new SqlDataAdapter("select * from [Material] where [Name] like '" + bunifuMaterialTextbox1.Text + "%'", conn);
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

        private void panel1_MouseLeave(object sender, EventArgs e)
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

        private void Material_MouseEnter(object sender, EventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.materialTableAdapter.Fill(this.allTables.Material);
            }
            refreshcheck = 0;
        }

        private void Material_MouseMove(object sender, MouseEventArgs e)
        {
            if (refreshcheck == 100)
            {
                this.materialTableAdapter.Fill(this.allTables.Material);
            }
            refreshcheck = 0;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
