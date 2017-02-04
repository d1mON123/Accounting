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
    public partial class MainReportForm : Form
    {
        public MainReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet.Table". При необходимости она может быть перемещена или удалена.
            this.TableTableAdapter.Fill(this.DataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet.Table". При необходимости она может быть перемещена или удалена.
            this.TableTableAdapter.Fill(this.DataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet.Table". При необходимости она может быть перемещена или удалена.


            reportViewer1.RefreshReport();
        }
    }
}
