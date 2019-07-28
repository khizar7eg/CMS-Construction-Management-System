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
using System.Text.RegularExpressions;

namespace CMS
{
    public partial class Construction_Task_New : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        Project p = new Project();
        public string idd = null;
        public string pname = null,qnty=null;
        public int qqqqq;
        public static string materialname = null, materialcount = null, labourcount = null;
        public static int check=0;
        public static string material = null,quantitydg=null;
        
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public Construction_Task_New()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Construction_Task_New_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMSDataSet1CS.ConstructTask' table. You can move, or remove it, as needed.
            this.constructTaskTableAdapter.Fill(this.cMSDataSet1CS.ConstructTask);
            // TODO: This line of code loads data into the 'allTables.Material' table. You can move, or remove it, as needed.
            this.materialTableAdapter.Fill(this.allTables.Material);
            check = 0;
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT [Project Title] from [ProjectContract]", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {

                    comboBox2.Items.Add(dr["Project Title"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox1_Validated(object sender, EventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox3_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
          
            
         
        }

      

      

       

        private void bunifuMaterialTextbox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QProject qp = new QProject();
            
            int Rowcount = dataGridView1.Rows.Count;
            if (comboBox2.SelectedItem != null)
            {

                try
            {
                for (int i = 0; i < (Rowcount + 1); i++)
                {
                    material = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    quantitydg = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    qp.addconttask(material, quantitydg);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            foreach (DataGridViewRow Datarow in dataGridView1.Rows)
            {
                if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null && Datarow.Cells[2].Value != null)
                {

                    materialname = materialname + Datarow.Cells[0].Value.ToString() + "   ";
                    materialcount = materialcount + Datarow.Cells[1].Value.ToString();
                    labourcount = labourcount + Datarow.Cells[2].Value.ToString();

                }
                

            }
            
                qp.conttask(comboBox2.SelectedItem.ToString(), bunifuDatepicker1.Value.ToShortDateString(), bunifuDatepicker2.Value.ToShortDateString(), comboBox1.SelectedItem.ToString(), materialcount, labourcount, materialname);
                CMS.Form7.refreshcheck = 100;
            }
            else
            {
                MessageBox.Show("Fields are empty!");
            }
            

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
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
