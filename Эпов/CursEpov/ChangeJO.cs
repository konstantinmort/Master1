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

namespace CursSvet
{
    public partial class ChangeJO : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public ChangeJO()
        {
            InitializeComponent();
            con.Open();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin S = new Admin();
            S.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE JO SET [Date_runtime]='"+textBox1.Text+ "',[Amount]='" + textBox2.Text + "',[ID_products]='" + textBox3.Text + "' WHERE ID_O="+textBox5;

            OleDbCommand command = new OleDbCommand(query, con);

            command.ExecuteNonQuery();
        }
    }
}
