using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class Project_New : Form
    {
        string title, orgname, tender, entrydate, status, type, duration, comment,imgloc="";

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == 8 ||e.KeyChar==32||e.KeyChar==45||e.KeyChar==95)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "Enter only A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)||char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar==32)
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
           
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)||char.IsLetterOrDigit(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar==46 || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox6, "A-Z,a-z,0-9");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox4, "A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuMaterialTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)|| char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                errorProvider1.Clear();
                e.Handled = false;

            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox7, "A-Z,a-z");
                e.Handled = true;

            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        long budget;

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public Project_New()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                dlg.Title = "Select";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        bool mouseDown;
        private void Project_New_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            title = bunifuMaterialTextbox1.Text;
            orgname = bunifuMaterialTextbox2.Text;
            tender = bunifuMaterialTextbox3.Text;
            entrydate = bunifuDatepicker1.Value.ToShortDateString();
            status = comboBox1.SelectedItem.ToString();
            type = bunifuMaterialTextbox4.Text;
            duration = bunifuMaterialTextbox6.Text;
            comment = bunifuMaterialTextbox5.Text;
            budget = Convert.ToInt32(bunifuMaterialTextbox7.Text);

            if (title==string.Empty || orgname == null || tender == null || entrydate == null || status == null || duration == null || budget == 0) 
            {
                DialogResult DDR = MessageBox.Show("Fields are Empty!", "Dynamic Engineering", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                qp.AddProject(title, orgname, tender, entrydate, status, type, duration, comment, budget,img);
                CMS.Project.refreshcheck = 100;
            }
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Project form = new Project();
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
