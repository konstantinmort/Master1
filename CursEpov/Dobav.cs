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
    public partial class Dobav : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public Dobav()
        {
            con.Open();
            string query;
            OleDbCommand command;
            OleDbDataReader reader;

            InitializeComponent();

            query = "SELECT Drugs FROM Products";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0]);
            }

            query = "SELECT [Price] FROM Products";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }

            query = "SELECT Category FROM Products";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

            query = "SELECT [Title] FROM Suppliers";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox5.Items.Add(reader[0]);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string post = comboBox5.SelectedItem.ToString();
            string prep = comboBox4.SelectedItem.ToString();
            string cat = comboBox1.SelectedItem.ToString();
            string col = numericUpDown1.Value.ToString();
            string sum = comboBox2.SelectedItem.ToString();

            Pechat cS = new Pechat();
            cS.label6.Text = post;
            cS.label9.Text = prep;
            cS.label11.Text = sum.ToString() + " р";
            cS.label18.Text = cat;
            cS.label19.Text = col;
            cS.ShowDialog();
          
        

            //CursEpov.Pechat C = new CursEpov.Pechat();
            //C.ShowDialog();
        
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        public void Dobav_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    }
}
