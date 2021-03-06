﻿using System;
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
    public partial class Admin : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);

        public Admin()
        {
            InitializeComponent();
            con.Open();
            LoadData();
            LoadData1();
            LoadData2();
            LoadData3();
            LoadData4();

            try
            {
                comboBox2.Items.Clear();
                string query = "SELECT [ID_products] FROM [JO]";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            try
            {
                comboBox3.Items.Clear();
                string query = "SELECT [ID_products] FROM [JO]";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0]);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void LoadData()
        {
           
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM JO ORDER BY ID_O";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void LoadData1()
        {
           
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT Products.ID_products , Products.ID_suppliers, Products.Drugs, Products.Shelflife, " +
                " Products.Dosage, Products.Category, Products.Price, [JO].[Amount]+[Products]![Remainder] AS Remaider" +
                " FROM JO INNER JOIN Products ON JO.ID_products = Products.ID_suppliers";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }

        private void LoadData2()
        {
       
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM Suppliers ORDER BY ID_supplies ";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }

        private void LoadData3()
        {
        
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT Sales.ID_JO, Sales.ID_products, Sales.Amount, Sales.Price,  Sales.Date" +
            " FROM [Sales]";
            
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView4.Rows.Add(s);
        }
        private void LoadData4()
        {
            
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM [Authorization]";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView5.Rows.Add(s);
        }

        private void Manager_Load(object sender, EventArgs e)
        {


        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO JO (ID_O, Date_runtime, Amount, ID_products) VALUES ('" + textBox19.Text + "','" + textBox3.Text + "','" + textBox18.Text + "','" + textBox1.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                dataGridView1.Rows.Clear();
                LoadData();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            con.Close();
        }

        private void FurnitureBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO Suppliers (ID_supplies, Title, Contface, Phone, Address) VALUES ('" + textBox20.Text + "','" + textBox21.Text + "','" + textBox8.Text + "','" + textBox22.Text + "','" + textBox7.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                dataGridView3.Rows.Clear();
                LoadData2();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Products] ([ID_products], [Drugs], [Shelflife], [Dosage], [Category], [Price], [ID_suppliers]) VALUES ('" + comboBox3.Text + "','" + textBox15.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedItem + "','" + textBox24.Text + "','" + textBox25.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();                 

                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                dataGridView2.Rows.Clear();
                LoadData1();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Sales] (ID_JO, ID_products, Amount, Price, [Date]) VALUES ('" + textBox23.Text + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox27.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                dataGridView4.Rows.Clear();
                LoadData3();
            }
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void ПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            ChangeJO cS = new ChangeJO();
            cS.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE from JO where ID_O =" + textBox28.Text;

                OleDbCommand command = new OleDbCommand(query, con);

                command.ExecuteNonQuery();
            }
        }
        private void Button17_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Authorization] ([ID_employees], [Login], [Password], [Preffix]) VALUES ('" + textBox17.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                dataGridView5.Rows.Clear();
                LoadData4();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE from Products where ID_products =" + textBox29.Text;

                OleDbCommand command = new OleDbCommand(query, con);

                command.ExecuteNonQuery();

                dataGridView2.Rows.Clear();
                LoadData1();
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE from Suppliers where ID_supplies =" + textBox30.Text;

                OleDbCommand command = new OleDbCommand(query, con);

                command.ExecuteNonQuery();
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE from [Sales] where ID_JO =" + textBox31.Text;

                OleDbCommand command = new OleDbCommand(query, con);

                command.ExecuteNonQuery();
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE from [Authorization] where ID_employees =" + textBox32.Text;

                OleDbCommand command = new OleDbCommand(query, con);

                command.ExecuteNonQuery();
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            ChangeProd cS = new ChangeProd();
            cS.ShowDialog();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ChangeSli cS = new ChangeSli();
            cS.ShowDialog();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ChangeSale cS = new ChangeSale();
            cS.ShowDialog();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value.ToString() == textBox6.Text)
                    {
                        isVisible = true;
                    }
                }
                dataGridView1.Rows[i].Visible = isVisible;
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (dataGridView2[j, i].Value.ToString() == textBox6.Text)
                    {
                        isVisible = true;
                    }
                }
                dataGridView2.Rows[i].Visible = isVisible;
            }

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    if (dataGridView3[j, i].Value.ToString() == textBox6.Text)
                    {
                        isVisible = true;
                    }
                }
                dataGridView3.Rows[i].Visible = isVisible;
            }

            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView4.Columns.Count; j++)
                {
                    if (dataGridView4[j, i].Value.ToString() == textBox6.Text)
                    {
                        isVisible = true;
                    }
                }
                dataGridView4.Rows[i].Visible = isVisible;
            }

            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView5.Columns.Count; j++)
                {
                    if (dataGridView5[j, i].Value.ToString() == textBox6.Text)
                    {
                        isVisible = true;
                    }
                }
                dataGridView5.Rows[i].Visible = isVisible;
            }

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Dobav cS = new Dobav();
            cS.ShowDialog();
            //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //    printDocument1.Print();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var bitmap = new Bitmap(Width, Height);
            DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            e.Graphics.DrawImage(bitmap, new Point(10, 10));
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
            dataGridView2.Rows.Clear();
            LoadData1();
            dataGridView3.Rows.Clear();
            LoadData2();
            dataGridView4.Rows.Clear();
            LoadData3();
            dataGridView5.Rows.Clear();
            LoadData4();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
            dataGridView2.Rows.Clear();
            LoadData1();
            dataGridView3.Rows.Clear();
            LoadData2();
            dataGridView4.Rows.Clear();
            LoadData3();
            dataGridView5.Rows.Clear();
            LoadData4();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
            dataGridView2.Rows.Clear();
            LoadData1();
            dataGridView3.Rows.Clear();
            LoadData2();
            dataGridView4.Rows.Clear();
            LoadData3();
            dataGridView5.Rows.Clear();
            LoadData4();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
            dataGridView2.Rows.Clear();
            LoadData1();
            dataGridView3.Rows.Clear();
            LoadData2();
            dataGridView4.Rows.Clear();
            LoadData3();
            dataGridView5.Rows.Clear();
            LoadData4();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
            dataGridView2.Rows.Clear();
            LoadData1();
            dataGridView3.Rows.Clear();
            LoadData2();
            dataGridView4.Rows.Clear();
            LoadData3();
            dataGridView5.Rows.Clear();
            LoadData4();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView3.RowCount; i++)
            //    if (dataGridView3[1, i].FormattedValue.ToString().
            //        Contains(textBox6.Text.Trim()))
            //    {
            //        dataGridView3.CurrentCell = dataGridView3[0, i];
            //        return;
            //    }
            //for (int i = 0; i < dataGridView4.RowCount; i++)
            //    if (dataGridView4[2, i].FormattedValue.ToString().
            //        Contains(textBox6.Text.Trim()))
            //    {
            //        dataGridView4.CurrentCell = dataGridView4[0, i];
            //        return;
            //    }
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //    if (dataGridView1[1, i].FormattedValue.ToString().
            //        Contains(textBox6.Text.Trim()))
            //    {
            //        dataGridView1.CurrentCell = dataGridView1[0, i];
            //        return;
            //    }
            //for (int i = 0; i < dataGridView5.RowCount; i++)
            //    if (dataGridView5[1, i].FormattedValue.ToString().
            //        Contains(textBox6.Text.Trim()))
            //    {
            //        dataGridView5.CurrentCell = dataGridView5[0, i];
            //        return;
            //    }
            //for (int i = 0; i < dataGridView2.RowCount; i++)
            //    if (dataGridView2[1, i].FormattedValue.ToString().
            //        Contains(textBox6.Text.Trim()))
            //    {
            //        dataGridView2.CurrentCell = dataGridView2[0, i];
            //        return;
            //    }
    
        }

        private void TextBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void ComboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
