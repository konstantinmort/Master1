using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CursSvet
{
    public partial class ChangeSli : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public ChangeSli()
        {
            InitializeComponent();
            con.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Suppliers SET [Title]='" + textBox1.Text + "',[Contface]='" + textBox2.Text + "',[Phone]='" + textBox3.Text + "',[Address]='" + textBox4.Text + "' WHERE ID_supplies=" + textBox5.Text;

            OleDbCommand command = new OleDbCommand(query, con);

            command.ExecuteNonQuery();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
