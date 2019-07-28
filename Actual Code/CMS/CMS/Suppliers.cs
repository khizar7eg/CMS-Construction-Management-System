using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class Suppliers : Form
    {
        public static string idsupplier = null;
        public Suppliers()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            qp.AddSupplier(bunifuMaterialTextbox1.Text,bunifuMaterialTextbox2.Text);
            this.suppliersTableAdapter.Fill(this.cMSDataSet1SS.Suppliers);
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMSDataSet1SS.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.cMSDataSet1SS.Suppliers);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idsupplier = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            DialogResult DDR = MessageBox.Show("Are you sure you want to Delete?", "Delete Supplier", MessageBoxButtons.YesNoCancel,
      MessageBoxIcon.Stop);

            if (DDR == DialogResult.Yes)
            {
                qp.DeleteSupplier(idsupplier);

            }
            try
            {
                this.suppliersTableAdapter.Fill(this.cMSDataSet1SS.Suppliers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}
