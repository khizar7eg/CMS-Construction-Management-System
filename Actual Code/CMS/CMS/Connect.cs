using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class Connect
    {
        SqlConnection con;
        string connetionString=null;
        public void ConnectDb()
        {
            connetionString = "Server= 127.0.0.1; Database= CMS; Integrated Security = SSPI;";
            con = new SqlConnection(connetionString);
            try
            {
                con.Open();
                
                Console.WriteLine("Connection Open! ");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! "+ex);
            }
            
        }
        
    }
}
