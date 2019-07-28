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
    public partial class Purchase_New : Form
    {
        public SqlCommand cm;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        
        public string idd = null;
        public string pname = null, qnty = null,balance=null;
        public int qqqqq,bbbbb;
        public static string materialname = "Materials ", materialcount = "Quantity ", price = "Price ",supplier="supplier ",material=null,quantitydg=null;
        public static int check = 0;
        public static long budget = 0;

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
                        material = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        quantitydg = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        budget = budget + Convert.ToInt64(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        qp.addpurchase(material, quantitydg);
                        qp.purchases(budget, comboBox2.SelectedItem.ToString(), bunifuDatepicker2.Value.ToShortDateString());

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }



                foreach (DataGridViewRow Datarow in dataGridView1.Rows)
                {
                    if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null && Datarow.Cells[2].Value != null && Datarow.Cells[3].Value != null)
                    {

                        supplier = supplier + Datarow.Cells[0].Value.ToString() + "     ";
                        materialname = materialname + Datarow.Cells[1].Value.ToString() + "     ";
                        materialcount = materialcount + Datarow.Cells[2].Value.ToString() + "     ";
                        price = price + Datarow.Cells[3].Value.ToString() + "     ";

                    }

                }

                qp.Addpurchasing(comboBox2.SelectedItem.ToString(), bunifuDatepicker1.Value.ToShortDateString(), comboBox1.SelectedItem.ToString(), bunifuDatepicker2.Value.ToShortDateString(), supplier, materialname, materialcount, price);
                CMS.Purchase.refreshcheck = 100;
            }
            else
            {
                MessageBox.Show("Fields are empty!");
            }

        }

        public Purchase_New()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
     


        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Purchase_New_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMSDataSet1SS.Material' table. You can move, or remove it, as needed.
            this.materialTableAdapter.Fill(this.cMSDataSet1SS.Material);
            // TODO: This line of code loads data into the 'cMSDataSet1SS.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.cMSDataSet1SS.Suppliers);
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT [Project Title] from ProjectContract", conn);

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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Purchase form = new Purchase();
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
