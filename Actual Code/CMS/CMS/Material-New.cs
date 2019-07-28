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
    public partial class Material_New : Form
    {
        string pname, type, comment;
        int value, quantity;
        public Material_New()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
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

        private void bunifuMaterialTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)||char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
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

        private void bunifuMaterialTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar)||char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            pname = bunifuMaterialTextbox2.Text;
            quantity = Convert.ToInt32(bunifuMaterialTextbox3.Text);
            value = Convert.ToInt32(bunifuMaterialTextbox7.Text);
            comment = bunifuMaterialTextbox5.Text;
            type = comboBox1.SelectedItem.ToString();
            qp.AddMaterial(pname,quantity,value,comment,type);
            CMS.Material.refreshcheck = 100;
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
