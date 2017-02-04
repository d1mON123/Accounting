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
    public partial class PayResForm : Form
    {
        public PayResForm()
        {
            InitializeComponent();
        }

        private void PayResForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Ім'я";
            dataGridView1.Columns[3].HeaderText = "Прізвище";
            dataGridView1.Columns[4].HeaderText = "Відпрацьовано";
            dataGridView1.Columns[5].HeaderText = "з";
            dataGridView1.Columns[6].HeaderText = "Місяць";
            dataGridView1.Columns[7].HeaderText = "Рік";
            dataGridView1.Columns[8].HeaderText = "Неоподаткована зарплата";
            dataGridView1.Columns[9].HeaderText = "ЄСВ";
            dataGridView1.Columns[10].HeaderText = "ПДФО";
            dataGridView1.Columns[11].HeaderText = "Військовий збір";
            dataGridView1.Columns[12].HeaderText = "Оподаткована зарплата";
            dataGridView1.Update();
        }
    }
}
