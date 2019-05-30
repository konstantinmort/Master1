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
    public partial class ChangeSale : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public ChangeSale()
        {
            InitializeComponent();
            con.Open();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [Sales] SET [ID_products]='" + textBox1.Text + "',[Amount]='" + textBox2.Text + "',[Price]='" + textBox3.Text + "',[Date]='" + textBox4.Text + "' WHERE ID_JO=" + textBox5.Text;

            OleDbCommand command = new OleDbCommand(query, con);

            command.ExecuteNonQuery();
        }
    }
}
