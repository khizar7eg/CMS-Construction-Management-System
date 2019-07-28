using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CMS
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Report_Load(object sender, EventArgs e)
        {
            //ReportDocument Report = new ReportDocument();
            //Report.Load(Server.MapPath("/EmployeeData.rpt"));
            //Report.SetDatabaseLogon("sa", "sa123", "Rakesh-PC", "RakeshData");
            //CrystalReportViewer1.ReportSource = Report;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            mouseDown = false;
        }
    }
}
