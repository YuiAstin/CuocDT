using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Repositories;
using DAL.Models;
using BUS.Helpers.ExtensionMethods;
using BUS.Views;

namespace TestWindowsFormsApp
{
	public partial class UserControl1 : UserControl
	{
		private BillRepository billRepository;
		private List<BillView> billViews;
		private BindingSource billSource;

		public UserControl1()
		{
			InitializeComponent();

			billRepository = new BillRepository();
			billSource = new BindingSource();

            bindSourceToDataGridView();
        }

		private void bindSourceToDataGridView()
		{
			billViews = billRepository.Bills.ConvertToViews().ToList();
			billSource.DataSource = billViews;
			dataGridView1.DataSource = billSource;			
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindSourceToDataGridView();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentCell != null)
            {
                int a = dataGridView1.CurrentCell.RowIndex;
                billViews[a].PayDate = DateTime.Now.ToString();
                billRepository.AddBill(BillExtensionMethod.ConvertToBill(billViews[a]));
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
