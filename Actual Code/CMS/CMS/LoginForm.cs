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
    public partial class LoginForm : Form
    {
        public static string user = null, pass = null;
        public LoginForm()
        {
            InitializeComponent();

            textBox1.Multiline = true;
            textBox1.MinimumSize = new Size(221, 30);
            textBox1.Size = new Size(221, 30);
            textBox1.Multiline = false;
            



        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
            user=bunifuMaterialTextbox1.Text;
            pass=textBox1.Text;
            
            QProject qp = new QProject();
            qp.LoginCheck(user,pass);
            bunifuMaterialTextbox1.Text = "";
            textBox1.Text = "";


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Main form = new Main();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                user = bunifuMaterialTextbox1.Text;
                pass = textBox1.Text;

                QProject qp = new QProject();
                qp.LoginCheck(user, pass);
                bunifuMaterialTextbox1.Text = "";
                textBox1.Text = "";
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
