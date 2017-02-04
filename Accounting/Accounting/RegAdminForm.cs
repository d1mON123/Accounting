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
    public partial class RegAdminForm : Form
    {
        public RegAdminForm()
        {
            InitializeComponent();
        }

        Broker b = new Broker();

        private void button1_Click(object sender, EventArgs e)
        {
            if (b.EnterProgram(textBox1.Text) && textBox1.Text != "")
            {
                if (textBox2.Text == textBox3.Text && textBox2.Text != "")
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Неправильно введений пароль");
                }
            }
            else
            {
                MessageBox.Show("Данний логін недоступний");
            }
        }

        private void RegAdminForm_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
