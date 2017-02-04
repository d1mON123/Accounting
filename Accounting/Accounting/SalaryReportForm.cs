using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class SalaryReportForm : Form
    {
        public SalaryReportForm()
        {
            InitializeComponent();
        }

        private void SalaryReportForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet.Salary". При необходимости она может быть перемещена или удалена.
            //this.SalaryTableAdapter.Fill(this.DataSet.Salary);
            this.reportViewer1.RefreshReport();
        }
    }
}
