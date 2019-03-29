using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp
{
	public partial class Form1 : Form
	{
		private UserControl1 uc1 = new UserControl1();

		public Form1()
		{
			InitializeComponent();

			Controls.Add(uc1);
		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
