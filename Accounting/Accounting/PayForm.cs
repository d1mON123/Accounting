using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Session;

namespace Accounting
{
    public partial class PayForm : Form
    {
        public PayForm()
        {
            InitializeComponent();
        }

        Broker b = new Broker();

        private void PayForm_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            DateTime date = DateTime.Now;
            for (int i = 1900; i <= Convert.ToInt32(date.Year); ++i)
            {
                comboBox4.Items.Add(i);
            }
            for(int i=1; i<=31; ++i)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex ==-1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Не вказані данні");
            } else if(Convert.ToInt32(comboBox1.Text) > Convert.ToInt32(comboBox2.Text))
            {
                MessageBox.Show("Неправильно вказана кількість відпрацьованих днів");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
