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
using BUS.Helpers;

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
                int at = dataGridView1.CurrentCell.RowIndex;
                billViews[at].PayDate = DateTime.Now.ToString();
                billRepository.AddBill(BillExtensionMethod.ConvertToBill(billViews[at]));
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime a, b;
            if(dataGridView1.CurrentCell != null)
            {
                int id = int.Parse(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                int at = dataGridView1.CurrentCell.RowIndex;
                double tong = 0;
                PhoneChargesCalculator why = new PhoneChargesCalculator();
                Bill biru = BillExtensionMethod.ConvertToBill(billViews[at]);
                PhoneCallsRepository prep = new PhoneCallsRepository();
                List<PhoneCall> phonelist = prep.FindSimID(int.Parse(billViews[at].SIMId));
                for(int i = 0; i<phonelist.Count;i++)
                {
                    a = phonelist[i].StartingTime;
                    b = phonelist[i].EndingTime;
                    tong += why.Calculate(a, b);
                }
                biru.Value = decimal.Parse(tong.ToString());
                
            }
        }

        
    }
}
