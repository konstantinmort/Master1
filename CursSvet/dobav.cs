using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CursSvet.Program;

namespace CursSvet
{
    public partial class dobav : Form
    {
        public dobav()
        {
            InitializeComponent();
            Random rnd = new Random();

            label1.Text = "Накладная №" + rnd.Next() + " от " + DateTime.Now.ToString().Substring(0, 11) + " г.";
            label4.Text = Data.Value;
        }

        private void Dobav_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }

            this.Close();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var bitmap = new Bitmap(Width, Height);
            DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            e.Graphics.DrawImage(bitmap, new Point(50, 50));
        }
    }
}
