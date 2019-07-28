using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CMS
{
    public class QProject
    {
       public SqlCommand cm;
       public SqlConnection conn;
        public SqlDataAdapter da;
        public string timepc, idup,idmaterial,idbudget,idct,idpce,username,password,quantitydb=null,balancedb=null, bdgblnce=null;
        public int x, y;
        public static int quantity,qntty,blnce=0;

        
        public void AddProject(string name,string orgname,string tender,string entry,string status,string Type,string duration,string comment,long budget,byte[] img)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();
               
               
                cm = new SqlCommand("insert into [ProjectContract]([Project Title],[Org Name],[Tender No],[Entry Date],Status,Duration,Budget,Type,Comment,Image) values ('" + name + "','" + orgname + "','" + tender + "','" + entry + "','" + status + "','" + duration + "'," + budget + ",'" + Type + "','" + comment + "',@img)", conn);
                cm.Parameters.Add(new SqlParameter("@img", img));
                cm.ExecuteNonQuery();
                
                conn.Close();
               
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("insert into [Budget]([Project Title],Date,Balance,Credit,Debit,Status) values ('" + name + "','" + entry + "'," + budget + ",0,0,'" + name + "')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            DialogResult DDR = MessageBox.Show("Project Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);

        }
        public void AddMaterial(string pname, int quantity,int value,string comment,string type)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("insert into [Material](Name,Quantity,Value,Type,Comment) values ('" + pname + "'," + quantity + "," + value + ",'" + type + "','" + comment + "')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Material Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void AddSupplier(string name, string type)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("insert into [Suppliers]([Supplier Name],Type) values ('" + name + "','" + type + "')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Supplier Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void addconttask(string materialname,string quantitydg)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT [Quantity] from Material where [Name]='" + materialname + "'", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    quantitydb = dr["Quantity"].ToString();

                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
             qntty= Convert.ToInt32(quantitydb) - Convert.ToInt32(quantitydg);

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("UPDATE [Material] SET [Quantity]=" + qntty + " where [Name]='" + materialname + "'", conn);

            try
            {

                cm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void purchases(long budget,string name,string date)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            
            cm = new SqlCommand("SELECT [Balance] from [Budget] where [Project Title]='" + name + "'", conn);
            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    balancedb = dr["Balance"].ToString();

                }
                
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            blnce = Convert.ToInt32(balancedb) - Convert.ToInt32(budget);

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("insert into [Budget]([Project Title],Date,Balance,Credit,Debit,Status) values ('" + name + "','" + date + "'," + blnce + ",0," + budget + ",'Material Purchasing')", conn);

            try
            {

                cm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Budgetbalance(string name)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();


            cm = new SqlCommand("SELECT [Balance] from [Budget] where [Project Title]='" + name + "'", conn);
            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                   bdgblnce = dr["Balance"].ToString();

                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        public void addpurchase(string materialname, string quantitydg)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("SELECT [Quantity] from Material where [Name]='" + materialname + "'", conn);

            try
            {

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    quantitydb = dr["Quantity"].ToString();

                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            qntty = Convert.ToInt32(quantitydb) + Convert.ToInt32(quantitydg);

            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();

            cm = new SqlCommand("UPDATE [Material] SET [Quantity]=" + qntty + " where [Name]='" + materialname + "'", conn);

            try
            {

                cm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void conttask(string task,string date,string tdate,string status,string mcount,string lcount,string materialn)
        {
            try
            {
                timepc = DateTime.Now.ToString("HH:mm:ss tt");
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("INSERT into [ConstructTask]([Project Name],Date,Time,Status,[T Date],MaterialName,[Labour Count],[Material Count]) values ('" + task + "','" + date + "','" + timepc + "','" + status + "','" + tdate + "','" + materialn + "','" + lcount + "','" + mcount + "')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Task Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void Addpurchasing(string title, string date, string status, string pdate, string supplier, string materialn, string quantity,string price)
        {
            timepc = DateTime.Now.ToString("HH:mm:ss tt");
            try
            {
                
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("INSERT into [Purchase]([Project Title], Date, Time, Status, [T Date], Supplier, [Material Name], MQuantity, MPrice) values ('" + title + "','" + date + "','" + timepc + "','" + status + "','" + pdate + "','" + supplier + "','" + materialn + "','" + quantity + "','"+price+"')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Purchase Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void Addbudget(string title,long balance,long credit,long debit,string status,string date)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("insert into [Budget]([Project Title],Date,Balance,Credit,Debit,Status) values ('" + title + "','"+date+"'," + balance + "," + credit + "," + debit + ",'" + status + "')", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Budget Details Added Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void DeleteProject(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from ProjectContract where ID="+id+"", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteContask(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from ConstructTask where ID=" + id + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteBudget(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from Budget where ID=" + id + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteSupplier(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from Suppliers where ID=" + id + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeletePurchase(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from Purchase where ID=" + id + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteMaterial(string id)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Delete from Material where ID=" + id + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Deleted Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void UpdateProject(string name, string orgname, string tender, string entry, string status, string Type, string duration, string comment, long budget)
        {

            idup = CMS.Project.iddd;
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Update [ProjectContract] SET [Project Title]='" + name + "', [Org Name]='" + orgname + "', [Tender No]='" + tender + "', [Entry Date]='" + entry + "', Status='" + status + "', Duration='" + duration + "', Budget=" + budget + ", Type='" + Type + "', Comment='" + comment + "' where ID=" + idup + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Project Updated Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void UpdatePurchase(string name, string date, string time, string status, string tdate, string supplier, string mn, string mquantity, string mprice)
        {

            
            idpce = CMS.Purchase.idpc;
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Update [Purchase] SET [Project Title]='" + name + "', [Date]='" + date + "', [Time]='" + time + "', [Status]='" + status + "', [T Date]='" + tdate + "', [Supplier]='" + supplier + "', [Material Name]='" + mn + "', [MQuantity]='" + mquantity + "', [MPrice]='" + mprice + "' where ID=" + idpce + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Purchase Details Updated Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void UpdateCT(string name, string date, string time, string status, string tdate, string mn, string mcount, string lcount)
        {

            idct = CMS.Form7.idconstructing;
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Update [ConstructTask] SET [Project Name]='" + name + "', [Date]='" + date + "', [Time]='" + time + "', [Status]='" + status + "', [T Date]='" + tdate + "', [MaterialName]='" + mn + "', [Material Count]='" + Convert.ToInt32(mcount) + "', [Labour Count]='" + Convert.ToInt32(lcount) + "' where ID=" + idct + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Task Updated Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void UpdateMaterial(string pname, string value, string comment, string type)
        {
            idmaterial = CMS.Material.idmm;
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Update [Material] SET [Name]='" + pname + "', [Value]=" + value + ", [Type]='" + type + "', [Comment]='" + comment + "' where ID=" + idmaterial + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Material Updated Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void UpdateBudget(string title, string date, string balance, string credit, string debit, string status)
        {

            idbudget = CMS.Budget.idbbb;
            try
            {
                conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
                conn.Open();

                cm = new SqlCommand("Update [Budget] SET [Project Title]='" + title + "', [Date]='" + date + "', [Balance]=" + balance + ", [Credit]=" + credit + ", [Debit]=" + debit + ", Status='" + status + "' where ID=" + idbudget + "", conn);

                cm.ExecuteNonQuery();
                conn.Close();
                DialogResult DDR = MessageBox.Show("Budget Details Updated Successfully!", "Dynamic Engineering", MessageBoxButtons.OK,
MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void LoginCheck(string user,string pass)
        {
            conn = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CMS;Integrated Security=True");
            conn.Open();
            try { 
            da = new SqlDataAdapter("SELECT * from [Login] where [Username]='"+user+"' and [Password]='"+pass+"'", conn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                    Dashboard form = new Dashboard();
                    LoginForm lf = new LoginForm();
                    lf.Hide();
                    lf.FormClosed += new FormClosedEventHandler(delegate { lf.Close(); });
                    form.Show();
                    
                }
            else
            {
                DialogResult DDR = MessageBox.Show("Incorrect Username or Password!", "Dynamic Engineering", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
